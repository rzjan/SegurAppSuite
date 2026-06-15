using Microsoft.EntityFrameworkCore;
using SegurAppSuite.Domain.Entities;
using SegurAppSuite.Infrastructure.Persistence.Configurations;

namespace SegurAppSuite.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Poliza> Polizas { get; set; }
    public DbSet<Siniestro> Siniestros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 🔹 Aplica todas las configuraciones
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new PolizaConfiguration());
        modelBuilder.ApplyConfiguration(new SiniestroConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

