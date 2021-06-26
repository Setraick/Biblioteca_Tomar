using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca_Tomar.Data;
using Biblioteca_Tomar.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Biblioteca_Tomar.Controllers
{
    //[Authorize]
    public class LivrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Atributo que guarda nele os dados do Servidor
        /// </summary>
        private readonly IWebHostEnvironment _dadosServidor;

        /// <summary>
        /// Atributo que irá receber todos os dados referentes à
        /// pessoa q se autenticou no sistema
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        public LivrosController(ApplicationDbContext context, IWebHostEnvironment dadosServidor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _dadosServidor = dadosServidor;
            _userManager = userManager;
        }

        [AllowAnonymous]
        // GET: Livros
        public async Task<IActionResult> Index()
        {
            //var listaFotosCaes = await _context.Fotografias.Include(f => f.Cao)
            //                                      .OrderByDescending(f => f.DataFoto)  // LINQ
            //                                      .ToListAsync();
            //// var. auxiliar
            //string username = _userManager.GetUserId(User);

            //// quais o(s) cão/cães da pessoa q se autenticou?
            //var listaCaes = await (from c in _context.Caes
            //                       join cc in _context.CriadoresCaes on c.Id equals cc.CaoFK
            //                       join cr in _context.Criadores on cc.CriadorFK equals cr.Id
            //                       where cr.UserNameId == username
            //                       select c.Id)
            //                      .ToListAsync();

            //// é uma opção, mas não a vamos usar...
            //// ViewBag.caes = listaCaes;

            //// vamos usar um 'ViewModel'
            //// para o transporte
            //var listaFotos = new ListarFotosViewModel
            //{
            //    ListaFotos = listaFotosCaes,
            //    ListaCaes = listaCaes
            //};
            var fotos = _context.Livros.Include(v => v.FotoCapa);
            var applicationDbContext = _context.Livros.Include(l => l.Categoria);
            return View(await applicationDbContext.ToListAsync());
        }

        [AllowAnonymous]
        // GET: Livros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var livros = await _context.Livros
                .Include(l => l.Categoria)
                //.ThenInclude(uv => uv.Id.LivroFK == _userManager.GetUserId(User))
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livros == null)
            {
                return RedirectToAction("Index");
            }

            return View(livros);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Designacao");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,CategoriaFK,Autor,ISBN,FotoCapa")] Livros livros, IFormFile fotoLivro)
        {
            // var auxiliar
            string nomeImagem = "";

            if (fotoLivro == null)
            {
                //não ha ficheiro
                ModelState.AddModelError("", "Adicione por favor a capa do Livro");
                ViewData["Id"] = new SelectList(_context.Livros.OrderBy(v => v.Titulo), "Id", "Titulo", livros.Id);
                return View(livros);
            }
            else
            {
                //ha ficheiro mas sera valido
                if (fotoLivro.ContentType == "image/jpeg" || fotoLivro.ContentType == "image/png")
                {

                    // definir o novo nome da fotografia     
                    Guid g;
                    g = Guid.NewGuid();
                    nomeImagem = livros.Id + "_" + g.ToString(); // tb, poderia ser usado a formatação da data atual
                                                                      // determinar a extensão do nome da imagem
                    string extensao = Path.GetExtension(fotoLivro.FileName).ToLower();
                    // agora, consigo ter o nome final do ficheiro
                    nomeImagem = nomeImagem + extensao;

                    // associar este ficheiro aos dados da Fotografia do Livro
                    livros.FotoCapa = nomeImagem;

                    // localização do armazenamento da imagem
                    string localizacaoFicheiro = _dadosServidor.WebRootPath;
                    nomeImagem = Path.Combine(localizacaoFicheiro, "Images", nomeImagem);
                }

                else
                {
                    //ficheiro não valido
                    ModelState.AddModelError("", "Apenas pode associar uma imagem a um livro.");
                    return View(livros);

                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //adicionar dados do novo video
                    _context.Add(livros);
                    //
                    await _context.SaveChangesAsync();

                    //se cheguei, tudo correu bem
                    using var stream = new FileStream(nomeImagem, FileMode.Create);
                    await fotoLivro.CopyToAsync(stream);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro...");
                }
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Designacao", livros.CategoriaFK);
            return View(livros);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livros = await _context.Livros.FindAsync(id);
            if (livros == null)
            {
                return NotFound();
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Designacao", livros.CategoriaFK);
            return View(livros);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,CategoriaFK,Autor,ISBN,FotoCapa")] Livros livros)
        {
            if (id != livros.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivrosExists(livros.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Designacao", livros.CategoriaFK);
            return View(livros);
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livros = await _context.Livros
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livros == null)
            {
                return NotFound();
            }

            return View(livros);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livros = await _context.Livros.FindAsync(id);
            _context.Livros.Remove(livros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivrosExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}
