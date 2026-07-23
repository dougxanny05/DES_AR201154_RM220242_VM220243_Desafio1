using DES_AR201154_RM220242_VM220243_Desafio1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DES_AR201154_RM220242_VM220243_Desafio1.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly DBContext _context;

        public DepartamentosController(DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? selectedId)
        {
            var lista = await _context.Departamentos.ToListAsync();

            if (selectedId.HasValue)
            {
                var seleccionado = await _context.Departamentos
                    .Include(d => d.Empleado)
                    .FirstOrDefaultAsync(d => d.ID == selectedId.Value);

                ViewData["SelectedDepartamento"] = seleccionado;
            }

            return View(lista);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var departamento = await _context.Departamentos
                .Include(d => d.Empleado)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (departamento == null) return NotFound();

            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(departamento);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null) return NotFound();
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Departamento departamento)
        {
            if (id != departamento.ID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.ID)) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(departamento);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var departamento = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.ID == id);

            if (departamento == null) return NotFound();

            return View(departamento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento != null)
            {
                _context.Departamentos.Remove(departamento);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.ID == id);
        }
    }
}
