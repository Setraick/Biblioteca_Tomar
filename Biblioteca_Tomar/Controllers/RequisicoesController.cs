using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca_Tomar.Data;
using Biblioteca_Tomar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Biblioteca_Tomar.Controllers
{
    //[Authorize]
    public class RequisicoesController : Controller
    {
        /// <summary>
        /// referência à base de dados
        /// </summary>
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// objeto que sabe interagir com os dados do utilizador que se autêntica
        /// </summary>
        public RequisicoesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Requisicoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requisicoes
                .Include(r => r.FuncionarioInicioRequisicao)
                .Include(r => r.FuncionarioFimRequisicao)
                .Include(r => r.Requisitante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Requisicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicoes = await _context.Requisicoes
                .Include(r => r.FuncionarioInicioRequisicao)
                .Include(r => r.FuncionarioFimRequisicao)
                .Include(r => r.Requisitante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisicoes == null)
            {
                return NotFound();
            }

            return View(requisicoes);
        }

        // GET: Requisicoes/Create
        public IActionResult Create()
        {
            var listaUtilizadores = _context.Utilizadores.OrderBy(u => u.Nome);

            ViewData["FuncionarioInicioRequisicaoFK"] = new SelectList(listaUtilizadores, "Id", "Nome");
            ViewData["RequisitanteFK"] = new SelectList(listaUtilizadores, "Id", "Nome");
            return View();
        }

        // POST: Requisicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RequisitanteFK,FuncionarioInicioRequisicaoFK,FuncionarioFimRequisicaoFK,Data,DataDevol,Multa")] Requisicoes requisicao)
        {
            requisicao.Data = DateTime.Now;
            requisicao.FuncionarioInicioRequisicaoFK = _context.Utilizadores.Where(u => u.UserId == _userManager.GetUserId(User)).FirstOrDefault().Id;
            requisicao.FuncionarioFimRequisicaoFK = null;

            if (requisicao.RequisitanteFK > 0)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Add(requisicao);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Ocorreu um erro...");

                    }
                }
            }
            else
            {
                // não foi escolhido um requisitante válido 
                ModelState.AddModelError("", "Não se esqueça de escolher o requisitante...");
            }

            ViewData["RequisitanteFK"] = new SelectList(_context.Utilizadores.OrderBy(u => u.Nome), "Id", "Nome", requisicao.RequisitanteFK);

            return View(requisicao);
        }

        // GET: Requisicoes/Revoke
        public async Task<IActionResult> Revoke(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicoes
              .Include(r => r.FuncionarioInicioRequisicao)
              .Include(r => r.Requisitante)
              .Include(r => r.ListaLivros)
              .ThenInclude(rl => rl.Livro)
              .FirstOrDefaultAsync(m => m.Id == id);

            if (requisicao == null)
            {
                return NotFound();
            }

            // avaliar se há multa
            requisicao.Multa = 0;
            int numDias = (DateTime.Now - requisicao.Data).Days;
            if (numDias > 7)
            {
                requisicao.Multa = (numDias-7) * 0.25M;
            }


            return View(requisicao);
        }

        // POST: Requisicoes/Revoke
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Revoke(int id, [Bind("Id,Multa")] Requisicoes requisicao)
        {
            //var ID = requisicao.Id;
            //requisicao.Data = _context.Requisicoes;
            if (id != requisicao.Id)
            {
                return NotFound();
            }

            Requisicoes requisicaoAntiga = await _context.Requisicoes.AsNoTracking().Where(r=>r.Id==id).FirstOrDefaultAsync();
            if (requisicaoAntiga == null)
            {
                return NotFound();
            }

            //Os dados que estão a vir da requisicaoAntiga não vão ser alterados com o revoke.
            requisicao.RequisitanteFK = requisicaoAntiga.RequisitanteFK;
            requisicao.FuncionarioInicioRequisicaoFK = requisicaoAntiga.FuncionarioInicioRequisicaoFK;
            requisicao.FuncionarioFimRequisicaoFK = 1; // _context.Utilizadores.Where(u => u.UserId == _userManager.GetUserId(User)).FirstOrDefault().Id;
            requisicao.Data = requisicaoAntiga.Data;

            //A dataDevol é a data do revoke
            requisicao.DataDevol = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisicao);
                    await _context.SaveChangesAsync(); 
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisicoesExists(requisicao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
              
            }
           
            return RedirectToAction("Revoke", new { id = id });
        }

        // GET: Requisicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicoes = await _context.Requisicoes.FindAsync(id);
            if (requisicoes == null)
            {
                return NotFound();
            }
            var listaUtilizadores = _context.Utilizadores.OrderBy(u => u.Nome);
            ViewData["FuncionarioInicioRequisicaoFK"] = new SelectList(listaUtilizadores, "Id", "Nome", requisicoes.FuncionarioInicioRequisicaoFK);
            ViewData["FuncionarioFimRequisicaoFK"] = new SelectList(listaUtilizadores, "Id", "Nome", requisicoes.FuncionarioFimRequisicaoFK);
            ViewData["RequisitanteFK"] = new SelectList(listaUtilizadores, "Id", "Nome", requisicoes.RequisitanteFK);
            return View(requisicoes);
        }

        // POST: Requisicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RequisitanteFK,FuncionarioInicioRequisicaoFK,FuncionarioFimRequisicaoFK,Data,DataDevol,Multa")] Requisicoes requisicoes)
        {
            if (id != requisicoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisicoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisicoesExists(requisicoes.Id))
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
            var listaUtilizadores = _context.Utilizadores.OrderBy(u => u.Nome);
            ViewData["FuncionarioInicioRequisicaoFK"] = new SelectList(listaUtilizadores, "Id", "Nome", requisicoes.FuncionarioInicioRequisicaoFK);
            ViewData["FuncionarioFimRequisicaoFK"] = new SelectList(listaUtilizadores, "Id", "Nome", requisicoes.FuncionarioFimRequisicaoFK);
            ViewData["RequisitanteFK"] = new SelectList(listaUtilizadores, "Id", "Nome", requisicoes.RequisitanteFK);
            return View(requisicoes);
        }

        // GET: Requisicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicoes = await _context.Requisicoes
                .Include(r => r.FuncionarioInicioRequisicao)
                .Include(r => r.FuncionarioFimRequisicao)
                .Include(r => r.Requisitante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisicoes == null)
            {
                return NotFound();
            }

            return View(requisicoes);
        }

        // POST: Requisicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requisicoes = await _context.Requisicoes.FindAsync(id);
            _context.Requisicoes.Remove(requisicoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisicoesExists(int id)
        {
            return _context.Requisicoes.Any(e => e.Id == id);
        }
    }
}
