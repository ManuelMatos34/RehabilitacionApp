using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FisioTerapias.Models;

namespace FisioTerapias.Controllers
{
    public class SeguimientoesController : Controller
    {
        private readonly RehabilitacionContext _context;

        public SeguimientoesController(RehabilitacionContext context)
        {
            _context = context;
        }

        // GET: Seguimientoes
        public async Task<IActionResult> Index()
        {
            var rehabilitacionContext = _context.Seguimientos.Include(s => s.IdEstadoPacienteNavigation).Include(s => s.IdTerapiaNavigation);
            return View(await rehabilitacionContext.ToListAsync());
        }

        // GET: Seguimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguimiento = await _context.Seguimientos
                .Include(s => s.IdEstadoPacienteNavigation)
                .Include(s => s.IdTerapiaNavigation)
                .FirstOrDefaultAsync(m => m.IdSeguimiento == id);
            if (seguimiento == null)
            {
                return NotFound();
            }

            return View(seguimiento);
        }

        // GET: Seguimientoes/Create
        public IActionResult Create()
        {
            ViewBag.IdEstadoPaciente = _context.EstadoPacientes;
            ViewBag.IdTerapia = _context.Terapias;
            return View();
        }

        // POST: Seguimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSeguimiento,FechaSeguimiento,Sensacion,TomoMedicamentos,Hielo,Observaciones,Dolor,IdEstadoPaciente,IdTerapia")] Seguimiento seguimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seguimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdEstadoPaciente = _context.EstadoPacientes;
            ViewBag.IdTerapia = _context.Terapias;
            return View(seguimiento);
        }

        // GET: Seguimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguimiento = await _context.Seguimientos.FindAsync(id);
            if (seguimiento == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoPaciente"] = new SelectList(_context.EstadoPacientes, "IdEstadoPaciente", "IdEstadoPaciente", seguimiento.IdEstadoPaciente);
            ViewData["IdTerapia"] = new SelectList(_context.Terapias, "IdTerapia", "IdTerapia", seguimiento.IdTerapia);
            return View(seguimiento);
        }

        // POST: Seguimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSeguimiento,FechaSeguimiento,Sensacion,TomoMedicamentos,Hielo,Observaciones,Dolor,IdEstadoPaciente,IdTerapia")] Seguimiento seguimiento)
        {
            if (id != seguimiento.IdSeguimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seguimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeguimientoExists(seguimiento.IdSeguimiento))
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
            ViewData["IdEstadoPaciente"] = new SelectList(_context.EstadoPacientes, "IdEstadoPaciente", "IdEstadoPaciente", seguimiento.IdEstadoPaciente);
            ViewData["IdTerapia"] = new SelectList(_context.Terapias, "IdTerapia", "IdTerapia", seguimiento.IdTerapia);
            return View(seguimiento);
        }

        // GET: Seguimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguimiento = await _context.Seguimientos
                .Include(s => s.IdEstadoPacienteNavigation)
                .Include(s => s.IdTerapiaNavigation)
                .FirstOrDefaultAsync(m => m.IdSeguimiento == id);
            if (seguimiento == null)
            {
                return NotFound();
            }

            return View(seguimiento);
        }

        // POST: Seguimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seguimiento = await _context.Seguimientos.FindAsync(id);
            if (seguimiento != null)
            {
                _context.Seguimientos.Remove(seguimiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeguimientoExists(int id)
        {
            return _context.Seguimientos.Any(e => e.IdSeguimiento == id);
        }
    }
}
