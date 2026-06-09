using MediatR;
using SegurAppSuite.Domain.Events;
using SegurAppSuite.Domain.Interfaces;

namespace SegurAppSuite.Application.UseCases;

public class ActivarPolizaHandler
{
    private readonly IPolizaRepository _polizaRepository;
    private readonly IMediator _mediator;

    public ActivarPolizaHandler(IPolizaRepository polizaRepository, IMediator mediator)
    {
        _polizaRepository = polizaRepository;
        _mediator = mediator;
    }

    public async Task Handle(Guid polizaId) 
    {
        var poliza = _polizaRepository.ObtenerPorId(polizaId);
        if (poliza == null) {
            throw new InvalidOperationException("La Póliza n existe.");
        }
        poliza.Activar();
        _polizaRepository.Guardar(poliza);
        await _mediator.Publish(new PolizaActivada(poliza.Id) );
    }
}
