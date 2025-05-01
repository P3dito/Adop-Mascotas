using Microsoft.AspNetCore.Mvc;
using Adop_mascotas.Data;
using Adop_mascotas.Models;

public class MascotasController : Controller
{
    private readonly ApplicationDbContext _context;

    public MascotasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Mascotas/Crear
    public IActionResult Crear()
    {
        return View();
    }

    // POST: Mascotas/Crear
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Mascota mascota)
    {
        if (ModelState.IsValid)
        {
            _context.Mascotas.Add(mascota);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        return View(mascota);
    }
}
