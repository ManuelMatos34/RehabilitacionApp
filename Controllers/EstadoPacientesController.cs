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
    public class EstadoPacientesController : Controller
    {
        private readonly RehabilitacionContext _context;

        public EstadoPacientesController(RehabilitacionContext context)
        {
            _context = context;
        }

        // GET: EstadoPacientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoPacientes.ToListAsync());
        }

        // GET: EstadoPacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPaciente = await _context.EstadoPacientes
                .FirstOrDefaultAsync(m => m.IdEstadoPaciente == id);
            if (estadoPaciente == null)
            {
                return NotFound();
            }

            return View(estadoPaciente);
        }

        // GET: EstadoPacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoPacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoPaciente,Descripcion")] EstadoPaciente estadoPaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoPaciente);
        }

        // GET: EstadoPacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPaciente = await _context.EstadoPacientes.FindAsync(id);
            if (estadoPaciente == null)
            {
                return NotFound();
            }
            return View(estadoPaciente);
        }

        // POST: EstadoPacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoPaciente,Descripcion")] EstadoPaciente estadoPaciente)
        {
            if (id != estadoPaciente.IdEstadoPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoPacienteExists(estadoPaciente.IdEstadoPaciente))
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
            return View(estadoPaciente);
        }

        // GET: EstadoPacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPaciente = await _context.EstadoPacientes
                .FirstOrDefaultAsync(m => m.IdEstadoPaciente == id);
            if (estadoPaciente == null)
            {
                return NotFound();
            }

            return View(estadoPaciente);
        }

        // POST: EstadoPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoPaciente = await _context.EstadoPacientes.FindAsync(id);
            if (estadoPaciente != null)
            {
                _context.EstadoPacientes.Remove(estadoPaciente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoPacienteExists(int id)
        {
            return _context.EstadoPacientes.Any(e => e.IdEstadoPaciente == id);
        }
    }
}
