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
    public class EstadoTerapiasController : Controller
    {
        private readonly RehabilitacionContext _context;

        public EstadoTerapiasController(RehabilitacionContext context)
        {
            _context = context;
        }

        // GET: EstadoTerapias
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoTerapias.ToListAsync());
        }

        // GET: EstadoTerapias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTerapia = await _context.EstadoTerapias
                .FirstOrDefaultAsync(m => m.IdEstadoTerapia == id);
            if (estadoTerapia == null)
            {
                return NotFound();
            }

            return View(estadoTerapia);
        }

        // GET: EstadoTerapias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoTerapias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoTerapia,Descripcion")] EstadoTerapia estadoTerapia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoTerapia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoTerapia);
        }

        // GET: EstadoTerapias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTerapia = await _context.EstadoTerapias.FindAsync(id);
            if (estadoTerapia == null)
            {
                return NotFound();
            }
            return View(estadoTerapia);
        }

        // POST: EstadoTerapias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoTerapia,Descripcion")] EstadoTerapia estadoTerapia)
        {
            if (id != estadoTerapia.IdEstadoTerapia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoTerapia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoTerapiaExists(estadoTerapia.IdEstadoTerapia))
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
            return View(estadoTerapia);
        }

        // GET: EstadoTerapias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTerapia = await _context.EstadoTerapias
                .FirstOrDefaultAsync(m => m.IdEstadoTerapia == id);
            if (estadoTerapia == null)
            {
                return NotFound();
            }

            return View(estadoTerapia);
        }

        // POST: EstadoTerapias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoTerapia = await _context.EstadoTerapias.FindAsync(id);
            if (estadoTerapia != null)
            {
                _context.EstadoTerapias.Remove(estadoTerapia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoTerapiaExists(int id)
        {
            return _context.EstadoTerapias.Any(e => e.IdEstadoTerapia == id);
        }
    }
}
