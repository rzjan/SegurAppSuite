using MediatR;
using SegurAppSuite.Domain.Entities;
using SegurAppSuite.Domain.Events;
using SegurAppSuite.Domain.Interfaces;

namespace SegurAppSuite.Domain.Services;

public class ServicioDeReclamos
{
    private readonly IPolizaRepository _polizaRepository;
    private readonly IMediator _mediator;

    public ServicioDeReclamos(IPolizaRepository polizaRepository, IMediator mediator)
    {
        _polizaRepository = polizaRepository;
        _mediator = mediator;
    }

    public async Task RegistrarReclamo(Guid polizaId, Siniestro siniestro)
    {
        var poliza = _polizaRepository.ObtenerPorId(polizaId);
        if (poliza == null)
            throw new InvalidOperationException("La póliza no existe.");
                poliza.RegistrarSiniestro(siniestro);
                _polizaRepository.Guardar(poliza);
        // Disparar evento con MediatR
        await _mediator.Publish(new SiniestroRegistrado(siniestro.Id, poliza.Id));
    }
}