using DES_AR201154_RM220242_VM220243_Desafio1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DES_AR201154_RM220242_VM220243_Desafio1.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly DBContext _context;

        public EmpleadosController(DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var empleados = await _context.Empleados.Include(e => e.Departamento).ToListAsync();
            return View(empleados);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.Empleados
                .Include(e => e.Departamento)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (empleado == null) return NotFound();

            return View(empleado);
        }

        public IActionResult Create()
        {
            ViewData["Departamentos"] = _context.Departamentos.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Departamentos"] = _context.Departamentos.ToList();
            return View(empleado);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return NotFound();

            ViewData["Departamentos"] = _context.Departamentos.ToList();
            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Empleado empleado)
        {
            if (id != empleado.ID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Empleados.Any(e => e.ID == empleado.ID)) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["Departamentos"] = _context.Departamentos.ToList();
            return View(empleado);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.Empleados
                .Include(e => e.Departamento)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (empleado == null) return NotFound();

            return View(empleado);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
