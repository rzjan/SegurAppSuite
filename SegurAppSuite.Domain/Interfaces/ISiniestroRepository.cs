using SegurAppSuite.Domain.Entities;

namespace SegurAppSuite.Domain.Interfaces;

public interface ISiniestroRepository
{
    Siniestro ObtenerPorId(Guid id);
    void Guardar(Siniestro siniestro);
}
