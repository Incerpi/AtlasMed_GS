using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtlasMed_GS.Models;
using AtlasMed_GS.Persistence;

namespace AtlasMed_GS.Controllers
{
    public class ProntuariosController : Controller
    {
        private readonly DatabaseContext _context;

        public ProntuariosController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Prontuarios
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Prontuario.Include(p => p.Medicacao);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Prontuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prontuario == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario
                .Include(p => p.Medicacao)
                .FirstOrDefaultAsync(m => m.IdProntuario == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // GET: Prontuarios/Create
        public IActionResult Create()
        {
            ViewData["IdMedicacao"] = new SelectList(_context.Medicacao, "IdMedicacao", "Nome");
            return View();
        }

        // POST: Prontuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProntuario,Descricao,Diagnostico,Alergias,IdMedicacao")] Prontuario prontuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prontuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedicacao"] = new SelectList(_context.Medicacao, "IdMedicacao", "Nome", prontuario.IdMedicacao);
            return View(prontuario);
        }

        // GET: Prontuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prontuario == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario.FindAsync(id);
            if (prontuario == null)
            {
                return NotFound();
            }
            ViewData["IdMedicacao"] = new SelectList(_context.Medicacao, "IdMedicacao", "Nome", prontuario.IdMedicacao);
            return View(prontuario);
        }

        // POST: Prontuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProntuario,Descricao,Diagnostico,Alergias,IdMedicacao")] Prontuario prontuario)
        {
            if (id != prontuario.IdProntuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prontuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProntuarioExists(prontuario.IdProntuario))
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
            ViewData["IdMedicacao"] = new SelectList(_context.Medicacao, "IdMedicacao", "Nome", prontuario.IdMedicacao);
            return View(prontuario);
        }

        // GET: Prontuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prontuario == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario
                .Include(p => p.Medicacao)
                .FirstOrDefaultAsync(m => m.IdProntuario == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // POST: Prontuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prontuario == null)
            {
                return Problem("Entity set 'DatabaseContext.Prontuario'  is null.");
            }
            var prontuario = await _context.Prontuario.FindAsync(id);
            if (prontuario != null)
            {
                _context.Prontuario.Remove(prontuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProntuarioExists(int id)
        {
          return (_context.Prontuario?.Any(e => e.IdProntuario == id)).GetValueOrDefault();
        }
    }
}
