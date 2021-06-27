using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca_Tomar.Data;
using Biblioteca_Tomar.Models;

namespace Biblioteca_Tomar.Controllers
{
    public class ReqLivrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReqLivrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReqLivros
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReqLivros.Include(r => r.Livro).Include(r => r.Req);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReqLivros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reqLivros = await _context.ReqLivros
                .Include(r => r.Livro)
                .Include(r => r.Req)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reqLivros == null)
            {
                return NotFound();
            }

            return View(reqLivros);
        }

        // GET: ReqLivros/Create
        public IActionResult Create()
        {
            ViewData["LivroFK"] = new SelectList(_context.Livros, "Id", "Autor");
            ViewData["ReqFK"] = new SelectList(_context.Requisicoes, "Id", "Id");
            return View();
        }

        // POST: ReqLivros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReqFK,LivroFK")] ReqLivros reqLivros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reqLivros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LivroFK"] = new SelectList(_context.Livros, "Id", "Autor", reqLivros.LivroFK);
            ViewData["ReqFK"] = new SelectList(_context.Requisicoes, "Id", "Id", reqLivros.ReqFK);
            return View(reqLivros);
        }

        // GET: ReqLivros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reqLivros = await _context.ReqLivros.FindAsync(id);
            if (reqLivros == null)
            {
                return NotFound();
            }
            ViewData["LivroFK"] = new SelectList(_context.Livros, "Id", "Autor", reqLivros.LivroFK);
            ViewData["ReqFK"] = new SelectList(_context.Requisicoes, "Id", "Id", reqLivros.ReqFK);
            return View(reqLivros);
        }

        // POST: ReqLivros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReqFK,LivroFK")] ReqLivros reqLivros)
        {
            if (id != reqLivros.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reqLivros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReqLivrosExists(reqLivros.Id))
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
            ViewData["LivroFK"] = new SelectList(_context.Livros, "Id", "Autor", reqLivros.LivroFK);
            ViewData["ReqFK"] = new SelectList(_context.Requisicoes, "Id", "Id", reqLivros.ReqFK);
            return View(reqLivros);
        }

        // GET: ReqLivros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reqLivros = await _context.ReqLivros
                .Include(r => r.Livro)
                .Include(r => r.Req)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reqLivros == null)
            {
                return NotFound();
            }

            return View(reqLivros);
        }

        // POST: ReqLivros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reqLivros = await _context.ReqLivros.FindAsync(id);
            _context.ReqLivros.Remove(reqLivros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReqLivrosExists(int id)
        {
            return _context.ReqLivros.Any(e => e.Id == id);
        }
    }
}
