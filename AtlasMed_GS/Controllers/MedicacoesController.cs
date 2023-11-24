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
    public class MedicacoesController : Controller
    {
        private readonly DatabaseContext _context;

        public MedicacoesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Medicacoes
        public async Task<IActionResult> Index()
        {
              return _context.Medicacao != null ? 
                          View(await _context.Medicacao.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.Medicacao'  is null.");
        }

        // GET: Medicacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicacao == null)
            {
                return NotFound();
            }

            var medicacao = await _context.Medicacao
                .FirstOrDefaultAsync(m => m.IdMedicacao == id);
            if (medicacao == null)
            {
                return NotFound();
            }

            return View(medicacao);
        }

        // GET: Medicacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedicacao,Nome,Descricao,PrincipioAtivo,Dosagem")] Medicacao medicacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicacao);
        }

        // GET: Medicacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicacao == null)
            {
                return NotFound();
            }

            var medicacao = await _context.Medicacao.FindAsync(id);
            if (medicacao == null)
            {
                return NotFound();
            }
            return View(medicacao);
        }

        // POST: Medicacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedicacao,Nome,Descricao,PrincipioAtivo,Dosagem")] Medicacao medicacao)
        {
            if (id != medicacao.IdMedicacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicacaoExists(medicacao.IdMedicacao))
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
            return View(medicacao);
        }

        // GET: Medicacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicacao == null)
            {
                return NotFound();
            }

            var medicacao = await _context.Medicacao
                .FirstOrDefaultAsync(m => m.IdMedicacao == id);
            if (medicacao == null)
            {
                return NotFound();
            }

            return View(medicacao);
        }

        // POST: Medicacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicacao == null)
            {
                return Problem("Entity set 'DatabaseContext.Medicacao'  is null.");
            }
            var medicacao = await _context.Medicacao.FindAsync(id);
            if (medicacao != null)
            {
                _context.Medicacao.Remove(medicacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicacaoExists(int id)
        {
          return (_context.Medicacao?.Any(e => e.IdMedicacao == id)).GetValueOrDefault();
        }
    }
}
