using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adop_mascotas.Data;
using Adop_mascotas.Models;

public class AdopcionesController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdopcionesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Adopciones/Crear
    public IActionResult Crear(){
        ViewBag.Mascotas = _context.Mascotas
            .Where(m => !m.EstaAdoptada)
            .ToList();

        ViewBag.Adoptantes = _context.Adoptantes.ToList();
        return View();
    }

    // POST: Adopciones/Crear
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(int mascotaId, int adoptanteId)
    {
        var mascota = await _context.Mascotas.FindAsync(mascotaId);
        if (mascota == null || mascota.EstaAdoptada)
        {
            return NotFound();
        }

        var adopcion = new Adopcion
        {
            MascotaId = mascotaId,
            AdoptanteId = adoptanteId,
            FechaAdopcion = DateTime.UtcNow
        };

        mascota.EstaAdoptada = true;
        _context.Adopciones.Add(adopcion);
        _context.Mascotas.Update(mascota);

        await _context.SaveChangesAsync();
        return RedirectToAction("Lista");
    }

    // GET: Adopciones/Lista
    public IActionResult Lista()
    {
        var adopciones = _context.Adopciones
            .Include(a => a.Mascota)
            .Include(a => a.Adoptante)
            .ToList();

        return View(adopciones);
    }
}
