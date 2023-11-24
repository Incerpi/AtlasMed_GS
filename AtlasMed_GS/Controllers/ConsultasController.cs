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
    public class ConsultasController : Controller
    {
        private readonly DatabaseContext _context;

        public ConsultasController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Consulta.Include(c => c.Hospital).Include(c => c.Medico).Include(c => c.Paciente).Include(c => c.Prontuario);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.Hospital)
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .Include(c => c.Prontuario)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["IdHospital"] = new SelectList(_context.Hospital, "IdHospital", "Nome");
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "Nome");
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "Nome");
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "Descricao");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsulta,IdPaciente,IdMedico,IdProntuario,IdHospital,Horario")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHospital"] = new SelectList(_context.Hospital, "IdHospital", "Nome", consulta.IdHospital);
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "Nome", consulta.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "Nome", consulta.IdPaciente);
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "Descricao", consulta.IdProntuario);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["IdHospital"] = new SelectList(_context.Hospital, "IdHospital", "Nome", consulta.IdHospital);
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "Nome", consulta.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "Nome", consulta.IdPaciente);
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "Descricao", consulta.IdProntuario);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsulta,IdPaciente,IdMedico,IdProntuario,IdHospital,Horario")] Consulta consulta)
        {
            if (id != consulta.IdConsulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.IdConsulta))
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
            ViewData["IdHospital"] = new SelectList(_context.Hospital, "IdHospital", "Nome", consulta.IdHospital);
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "Nome", consulta.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "Nome", consulta.IdPaciente);
            ViewData["IdProntuario"] = new SelectList(_context.Prontuario, "IdProntuario", "Descricao", consulta.IdProntuario);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.Hospital)
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .Include(c => c.Prontuario)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consulta == null)
            {
                return Problem("Entity set 'DatabaseContext.Consulta'  is null.");
            }
            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta != null)
            {
                _context.Consulta.Remove(consulta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
          return (_context.Consulta?.Any(e => e.IdConsulta == id)).GetValueOrDefault();
        }
    }
}
