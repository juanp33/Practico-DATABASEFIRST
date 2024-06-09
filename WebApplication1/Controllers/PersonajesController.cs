using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonajesController : Controller
    {
        private readonly BibliotecaContext _context;

        public PersonajesController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Personajes
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Personajes.Include(p => p.PerLib).Include(p => p.PerRol);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Personajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaje = await _context.Personajes
                .Include(p => p.PerLib)
                .Include(p => p.PerRol)
                .FirstOrDefaultAsync(m => m.PerId == id);
            if (personaje == null)
            {
                return NotFound();
            }

            return View(personaje);
        }

        // GET: Personajes/Create
        public IActionResult Create()
        {
            ViewData["PerLibId"] = new SelectList(_context.Libros, "LibId", "LibId");
            ViewData["PerRolId"] = new SelectList(_context.Roles, "RolId", "RolId");
            return View();
        }

        // POST: Personajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerId,PerLibId,PerRolId,PerNombre,PerApellido,PerDescripcion,PerFechaNacimiento,PerLugarNacimiento,PerStatus")] Personaje personaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerLibId"] = new SelectList(_context.Libros, "LibId", "LibId", personaje.PerLibId);
            ViewData["PerRolId"] = new SelectList(_context.Roles, "RolId", "RolId", personaje.PerRolId);
            return View(personaje);
        }

        // GET: Personajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaje = await _context.Personajes.FindAsync(id);
            if (personaje == null)
            {
                return NotFound();
            }
            ViewData["PerLibId"] = new SelectList(_context.Libros, "LibId", "LibId", personaje.PerLibId);
            ViewData["PerRolId"] = new SelectList(_context.Roles, "RolId", "RolId", personaje.PerRolId);
            return View(personaje);
        }

        // POST: Personajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerId,PerLibId,PerRolId,PerNombre,PerApellido,PerDescripcion,PerFechaNacimiento,PerLugarNacimiento,PerStatus")] Personaje personaje)
        {
            if (id != personaje.PerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonajeExists(personaje.PerId))
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
            ViewData["PerLibId"] = new SelectList(_context.Libros, "LibId", "LibId", personaje.PerLibId);
            ViewData["PerRolId"] = new SelectList(_context.Roles, "RolId", "RolId", personaje.PerRolId);
            return View(personaje);
        }

        // GET: Personajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaje = await _context.Personajes
                .Include(p => p.PerLib)
                .Include(p => p.PerRol)
                .FirstOrDefaultAsync(m => m.PerId == id);
            if (personaje == null)
            {
                return NotFound();
            }

            return View(personaje);
        }

        // POST: Personajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personaje = await _context.Personajes.FindAsync(id);
            if (personaje != null)
            {
                _context.Personajes.Remove(personaje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonajeExists(int id)
        {
            return _context.Personajes.Any(e => e.PerId == id);
        }
    }
}
