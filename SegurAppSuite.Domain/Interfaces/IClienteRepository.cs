using SegurAppSuite.Domain.Entities;

namespace SegurAppSuite.Domain.Interfaces;

public interface IClienteRepository
{
    Cliente ObtenerPorId(Guid id);
    void Guardar(Cliente cliente);
}