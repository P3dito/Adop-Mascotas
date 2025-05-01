using Microsoft.AspNetCore.Mvc;
using Adop_mascotas.Data;
using Adop_mascotas.Models;

public class AdoptantesController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdoptantesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Adoptantes/Crear
    public IActionResult CrearAdop()
    {
        return View();
    }

    // POST: Adoptantes/Crear
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Adoptante adoptante)
    {
        if (ModelState.IsValid)
        {
            _context.Adoptantes.Add(adoptante);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home"); // Puedes cambiar redirección si deseas
        }

        return View(adoptante);
    }
}
