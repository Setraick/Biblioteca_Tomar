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
    public class RequisicoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequisicoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Requisicoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requisicoes.Include(r => r.FuncionarioInicioRequisicao).Include(r => r.FuncionarioFimRequisicao).Include(r => r.Requisitante);
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
            ViewData["FuncionarioInicioRequisicaoFK"] = new SelectList(_context.Utilizadores, "Id", "Email");
            //ViewData["FuncionarioFimRequisicaoFK"] = new SelectList(_context.Utilizadores, "Id", "Email");
            ViewData["RequisitanteFK"] = new SelectList(_context.Utilizadores.OrderBy(c => c.Nome), "Id", "Nome");
            return View();
        }

        // POST: Requisicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RequisitanteFK,FuncionarioInicioRequisicaoFK,FuncionarioFimRequisicaoFK,Data,DataDevol,Multa")] Requisicoes requisicao)
        {
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

            ViewData["RequisitanteFK"] = new SelectList(_context.Utilizadores.OrderBy(c => c.Nome), "Id", "Nome", requisicao.RequisitanteFK);

            return View(requisicao);
        }

        // GET: Requisicoes/Revoke
        public IActionResult Revoke()
        {
            //ViewData["FuncionarioInicioRequisicaoFK"] = new SelectList(_context.Utilizadores, "Id", "Email");
            ViewData["FuncionarioFimRequisicaoFK"] = new SelectList(_context.Utilizadores, "Id", "Email");
            //ViewData["RequisitanteFK"] = new SelectList(_context.Utilizadores.OrderBy(c => c.Nome), "Id", "Nome");
            return View();
        }

        // POST: Requisicoes/Revoke
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Revoke([Bind("Id,RequisitanteFK,FuncionarioInicioRequisicaoFK,FuncionarioFimRequisicaoFK,Data,DataDevol,Multa")] Requisicoes requisicao)
        {
            if (requisicao.FuncionarioFimRequisicaoFK > 0)
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

            ViewData["FuncionarioFimRequisicaoFK"] = new SelectList(_context.Utilizadores.OrderBy(c => c.Nome), "Id", "Nome", requisicao.FuncionarioFimRequisicaoFK);

            return View(requisicao);
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
            ViewData["FuncionarioInicioRequisicaoFK"] = new SelectList(_context.Utilizadores, "Id", "Email", requisicoes.FuncionarioInicioRequisicaoFK);
            ViewData["FuncionarioFimRequisicaoFK"] = new SelectList(_context.Utilizadores, "Id", "Email", requisicoes.FuncionarioFimRequisicaoFK);
            ViewData["RequisitanteFK"] = new SelectList(_context.Utilizadores.OrderBy(c => c.Nome), "Id", "Nome", requisicoes.RequisitanteFK);
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
            ViewData["FuncionarioInicioRequisicaoFK"] = new SelectList(_context.Utilizadores, "Id", "Email", requisicoes.FuncionarioInicioRequisicaoFK);
            ViewData["FuncionarioFimRequisicaoFK"] = new SelectList(_context.Utilizadores, "Id", "Email", requisicoes.FuncionarioFimRequisicaoFK);
            ViewData["RequisitanteFK"] = new SelectList(_context.Utilizadores, "Id", "Email", requisicoes.RequisitanteFK);
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
