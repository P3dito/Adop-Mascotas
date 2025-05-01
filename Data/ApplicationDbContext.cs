using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Adop_mascotas.Data;

public class ApplicationDbContext : IdentityDbContext
{


    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<Adoptante> Adoptantes { get; set; }
    public DbSet<Adopcion> Adopciones { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Mascota>()
            .HasOne(m => m.Adopcion)
            .WithOne(a => a.Mascota)
            .HasForeignKey<Adopcion>(a => a.MascotaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Adoptante>()
            .HasMany(a => a.Adopciones)
            .WithOne(ad => ad.Adoptante)
            .HasForeignKey(ad => ad.AdoptanteId);
    }

}
