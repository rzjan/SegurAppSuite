using SegurAppSuite.Domain.Entities;

namespace SegurAppSuite.Domain.Interfaces;

public interface IPolizaRepository
{
    Poliza ObtenerPorId(Guid id);
    void Guardar(Poliza poliza);
}
