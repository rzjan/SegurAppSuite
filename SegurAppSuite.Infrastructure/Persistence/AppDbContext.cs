using Microsoft.EntityFrameworkCore;
using SegurAppSuite.Domain.Entities;

namespace SegurAppSuite.Infrastructure.Persistence;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Poliza> Polizas { get; set; }
    public DbSet<Siniestro> Siniestros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configuración basicas de entidades
        modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
        modelBuilder.Entity<Poliza>().HasKey(p => p.Id);
        modelBuilder.Entity<Siniestro>().HasKey(s => s.Id);

        //Relación Cliente > Polizas
        modelBuilder.Entity<Poliza>()
            .HasOne<Cliente>()
            .WithMany()
            .HasForeignKey(p => p.ClienteId);

        //Relación Cliente > Poliza
        modelBuilder.Entity<Poliza>()
            .HasMany(p=> p.Siniestros)
            .WithOne()
            .HasForeignKey("PolizaId");
    }

}
