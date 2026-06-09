using MediatR;
using SegurAppSuite.Application.DTOs;
using SegurAppSuite.Domain.Entities;
using SegurAppSuite.Domain.Events;
using SegurAppSuite.Domain.Interfaces;
using SegurAppSuite.Domain.ValueObjects;

namespace SegurAppSuite.Application.UseCases;

public class CrearPolizaHandler
{
    private readonly IPolizaRepository _polizaRepository;
    private readonly IMediator _mediator;

    public CrearPolizaHandler(IPolizaRepository polizaRepository, IMediator mediatir)
    {
        _polizaRepository = polizaRepository;
        _mediator = mediatir;
    }

    public async Task<Guid> Handler(PolizaDto dto)
    {
        var poliza = new Poliza(
              Guid.NewGuid(),
              dto.ClienteId,
              new Prima(dto.Prima, dto.Moneda),
              new PeriodoCobertura(dto.InicioCobertura, dto.FinCobertura)
        );
        _polizaRepository.Guardar(poliza);
        //Disparar evento de dominio
        await _mediator.Publish(new PolizaActivada(poliza.Id));

        return poliza.Id;
    }
}
