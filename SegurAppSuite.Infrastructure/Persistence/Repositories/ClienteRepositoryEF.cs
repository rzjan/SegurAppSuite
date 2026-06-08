using SegurAppSuite.Domain.Entities;
using SegurAppSuite.Domain.Interfaces;

namespace SegurAppSuite.Infrastructure.Persistence.Repositories;

public class ClienteRepositoryEF:IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepositoryEF(AppDbContext context)
    {
        _context = context;
    } 

    public Cliente ObtenerPorId(Guid id) => _context.Clientes.Find(id);

    public void Guardar(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        _context.SaveChanges();
    }
}
