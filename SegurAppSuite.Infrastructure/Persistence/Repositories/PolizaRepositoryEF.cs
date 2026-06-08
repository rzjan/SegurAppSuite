using Microsoft.EntityFrameworkCore;
using SegurAppSuite.Domain.Entities;
using SegurAppSuite.Domain.Interfaces;

namespace SegurAppSuite.Infrastructure.Persistence.Repositories;

public class PolizaRepositoryEF:IPolizaRepository
{
    private readonly AppDbContext _context;

    public PolizaRepositoryEF(AppDbContext context)
    {
        _context = context;
    }

    public Poliza ObtenerPorId(Guid id)
    {
        return _context.Polizas.Include(p => p.Siniestros).FirstOrDefault(p => p.Id == id);
    }

    public void Guardar(Poliza poliza)
    {
        _context.Polizas.Update(poliza);
        _context.SaveChanges();
    }
}
