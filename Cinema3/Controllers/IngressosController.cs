using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema3.Data;
using Cinema3.Models;

namespace Cinema3.Controllers
{
    public class IngressosController : Controller
    {
        private readonly Cinema3Context _context;

        public IngressosController(Cinema3Context context)
        {
            _context = context;
        }

        // GET: Ingressos
        public async Task<IActionResult> Index()
        {
            var cinema3Context = _context.Ingressos.Include(i => i.Filme).Include(i => i.Periodo).Include(i => i.Sala);
            return View(await cinema3Context.ToListAsync());
        }

        // GET: Ingressos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingressos = await _context.Ingressos
                .Include(i => i.Filme)
                .Include(i => i.Periodo)
                .Include(i => i.Sala)
                .FirstOrDefaultAsync(m => m.IngressosId == id);
            if (ingressos == null)
            {
                return NotFound();
            }

            return View(ingressos);
        }

        // GET: Ingressos/Create
        public IActionResult Create()
        {
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "Nome");
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "PeriodoId", "PeriodoTurno");
            ViewData["SalaId"] = new SelectList(_context.Sala, "SalaId", "SalaId");
            return View();
        }

        // POST: Ingressos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngressosId,Nome,CPF,FilmeId,PeriodoId,SalaId,DataTime,Valor")] Ingressos ingressos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingressos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "Nome", ingressos.FilmeId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "PeriodoId", "PeriodoTurno", ingressos.PeriodoId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "SalaId", "SalaId", ingressos.SalaId);
            return View(ingressos);
        }

        // GET: Ingressos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingressos = await _context.Ingressos.FindAsync(id);
            if (ingressos == null)
            {
                return NotFound();
            }
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "Nome", ingressos.FilmeId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "PeriodoId", "PeriodoTurno", ingressos.PeriodoId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "SalaId", "SalaId", ingressos.SalaId);
            return View(ingressos);
        }

        // POST: Ingressos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngressosId,Nome,CPF,FilmeId,PeriodoId,SalaId,DataTime,Valor")] Ingressos ingressos)
        {
            if (id != ingressos.IngressosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingressos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngressosExists(ingressos.IngressosId))
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
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "Nome", ingressos.FilmeId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "PeriodoId", "PeriodoTurno", ingressos.PeriodoId);
            ViewData["SalaId"] = new SelectList(_context.Sala, "SalaId", "SalaId", ingressos.SalaId);
            return View(ingressos);
        }

        // GET: Ingressos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingressos = await _context.Ingressos
                .Include(i => i.Filme)
                .Include(i => i.Periodo)
                .Include(i => i.Sala)
                .FirstOrDefaultAsync(m => m.IngressosId == id);
            if (ingressos == null)
            {
                return NotFound();
            }

            return View(ingressos);
        }

        // POST: Ingressos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingressos = await _context.Ingressos.FindAsync(id);
            _context.Ingressos.Remove(ingressos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngressosExists(int id)
        {
            return _context.Ingressos.Any(e => e.IngressosId == id);
        }
    }
}
