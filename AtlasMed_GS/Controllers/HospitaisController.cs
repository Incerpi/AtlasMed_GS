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
    public class HospitaisController : Controller
    {
        private readonly DatabaseContext _context;

        public HospitaisController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Hospitais
        public async Task<IActionResult> Index()
        {
              return _context.Hospital != null ? 
                          View(await _context.Hospital.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.Hospital'  is null.");
        }

        // GET: Hospitais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital
                .FirstOrDefaultAsync(m => m.IdHospital == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }

        // GET: Hospitais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hospitais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHospital,Nome,Telefone,Rua,Numero,Bairro,Cidade,Estado,Cep")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospital);
        }

        // GET: Hospitais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital);
        }

        // POST: Hospitais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHospital,Nome,Telefone,Rua,Numero,Bairro,Cidade,Estado,Cep")] Hospital hospital)
        {
            if (id != hospital.IdHospital)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalExists(hospital.IdHospital))
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
            return View(hospital);
        }

        // GET: Hospitais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital
                .FirstOrDefaultAsync(m => m.IdHospital == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }

        // POST: Hospitais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hospital == null)
            {
                return Problem("Entity set 'DatabaseContext.Hospital'  is null.");
            }
            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital != null)
            {
                _context.Hospital.Remove(hospital);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospitalExists(int id)
        {
          return (_context.Hospital?.Any(e => e.IdHospital == id)).GetValueOrDefault();
        }
    }
}
