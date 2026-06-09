using MediatR;
using SegurAppSuite.Domain.Entities;
using SegurAppSuite.Domain.Events;
using SegurAppSuite.Domain.Interfaces;

namespace SegurAppSuite.Application.UseCases;

public class RegistrarSiniestroHandler
{
    private readonly IPolizaRepository _polizaRepository;
    private readonly IMediator _mediator;

    public RegistrarSiniestroHandler(IPolizaRepository polizaRepository, IMediator mediator)
    {
        _polizaRepository = polizaRepository;
        _mediator = mediator;
    }

    public async Task Handle(Guid polizaId, Siniestro siniestro) 
    {
        var poliza = _polizaRepository.ObtenerPorId(polizaId);
        if (poliza == null) {
            throw new InvalidOperationException("La Póliza n existe.");
        }
        poliza.RegistrarSiniestro(siniestro);
        _polizaRepository.Guardar(poliza);

        await _mediator.Publish(new SiniestroRegistrado(poliza.Id, siniestro.Id) );
    }
}
