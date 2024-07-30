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
    public class TerapiasController : Controller
    {
        private readonly RehabilitacionContext _context;

        public TerapiasController(RehabilitacionContext context)
        {
            _context = context;
        }

        // GET: Terapias
        public async Task<IActionResult> Index()
        {
            var rehabilitacionContext = _context.Terapias.Include(t => t.IdEmpleadoNavigation).Include(t => t.IdEstadoTerapiaNavigation).Include(t => t.IdPacienteNavigation);
            return View(await rehabilitacionContext.ToListAsync());
        }

        // GET: Terapias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terapia = await _context.Terapias
                .Include(t => t.IdEmpleadoNavigation)
                .Include(t => t.IdEstadoTerapiaNavigation)
                .Include(t => t.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdTerapia == id);
            if (terapia == null)
            {
                return NotFound();
            }

            return View(terapia);
        }

        // GET: Terapias/Create
        public IActionResult Create()
        {
            ViewBag.IdEmpleado = _context.Empleados;
            ViewBag.IdEstadoTerapia = _context.EstadoTerapias;
            ViewBag.IdPaciente = _context.Pacientes;

            ViewBag.IdEstadoPaciente = _context.EstadoPacientes;
            ViewBag.IdTerapia = _context.Terapias;
            return View();
        }

        // POST: Terapias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            DateTime Fecha,
            string Diagnostico,
            string NecesidadDelPaciente,
            int IdPaciente,
            int IdEstadoTerapia,
            int IdEmpleado,
            string Sensacion,
            string Observaciones,
            int Dolor,
            int IdEstadoPaciente
            )
        {
            
            //if (ModelState.IsValid)
            //{
            //    _context.Add(terapia);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}


            ViewBag.IdEmpleado = _context.Empleados;
            ViewBag.IdEstadoTerapia = _context.EstadoTerapias;
            ViewBag.IdPaciente = _context.Pacientes;

            return View();
        }

        //// GET: Terapias/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var terapia = await _context.Terapias.FindAsync(id);
        //    if (terapia == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", terapia.IdEmpleado);
        //    ViewData["IdEstadoTerapia"] = new SelectList(_context.EstadoTerapias, "IdEstadoTerapia", "IdEstadoTerapia", terapia.IdEstadoTerapia);
        //    ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", terapia.IdPaciente);
        //    return View(terapia);
        //}

        //// POST: Terapias/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("IdTerapia,Fecha,Diagnostico,Historial,NecesidadDelPaciente,CantidadDeTerapias,IdPaciente,IdEstadoTerapia,IdEmpleado")] Terapia terapia)
        //{
        //    if (id != terapia.IdTerapia)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(terapia);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TerapiaExists(terapia.IdTerapia))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", terapia.IdEmpleado);
        //    ViewData["IdEstadoTerapia"] = new SelectList(_context.EstadoTerapias, "IdEstadoTerapia", "IdEstadoTerapia", terapia.IdEstadoTerapia);
        //    ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", terapia.IdPaciente);
        //    return View(terapia);
        //}

        // GET: Terapias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terapia = await _context.Terapias
                .Include(t => t.IdEmpleadoNavigation)
                .Include(t => t.IdEstadoTerapiaNavigation)
                .Include(t => t.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdTerapia == id);
            if (terapia == null)
            {
                return NotFound();
            }

            return View(terapia);
        }

        // POST: Terapias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var terapia = await _context.Terapias.FindAsync(id);
            if (terapia != null)
            {
                _context.Terapias.Remove(terapia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerapiaExists(int id)
        {
            return _context.Terapias.Any(e => e.IdTerapia == id);
        }
    }
}
