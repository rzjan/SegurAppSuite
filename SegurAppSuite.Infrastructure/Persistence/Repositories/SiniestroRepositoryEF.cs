using SegurAppSuite.Domain.Entities;
using SegurAppSuite.Domain.Interfaces;

namespace SegurAppSuite.Infrastructure.Persistence.Repositories;

public class SiniestroRepositoryEF:ISiniestroRepository
{
    private readonly AppDbContext _context;

    public SiniestroRepositoryEF(AppDbContext context)
    {
        _context = context;
    }

    public Siniestro ObtenerPorId(Guid id) => _context.Siniestros.Find(id);

    public void Guardar(Siniestro siniestro)
    {
        _context.Siniestros.Update(siniestro);
        _context.SaveChanges();
    }
}
