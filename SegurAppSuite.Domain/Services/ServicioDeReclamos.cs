using SegurAppSuite.Domain.Entities;
using SegurAppSuite.Domain.Events;
using SegurAppSuite.Domain.Interfaces;

namespace SegurAppSuite.Domain.Services;

public class ServicioDeReclamos
{
    private readonly IPolizaRepository _polizaRepository;

    public ServicioDeReclamos(IPolizaRepository polizaRepository)
    {
        _polizaRepository = polizaRepository;
    }

    public void RegistrarReclamo(Guid polizaId, Siniestro siniestro)
    {
        var poliza = _polizaRepository.ObtenerPorId(polizaId);
        if (poliza == null)
            throw new InvalidOperationException("La póliza no existe.");

        poliza.RegistrarSiniestro(siniestro);
        _polizaRepository.Guardar(poliza);

        DomainEvents.Raise(new SiniestroRegistrado(siniestro.Id, poliza.Id));
    }
}
