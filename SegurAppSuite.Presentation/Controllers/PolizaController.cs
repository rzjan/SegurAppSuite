using Microsoft.AspNetCore.Mvc;
using SegurAppSuite.Application.DTOs;
using SegurAppSuite.Application.UseCases;

namespace SegurAppSuite.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PolizaController:ControllerBase
{
    private readonly CrearPolizaHandler _crearPolizaHandler;
    private readonly ActivarPolizaHandler _activarPolizaHandler;

    public PolizaController(CrearPolizaHandler crearPolizaHandler, ActivarPolizaHandler activarPolizaHandler)
    {
        _crearPolizaHandler = crearPolizaHandler;
        _activarPolizaHandler = activarPolizaHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] PolizaDto dto) {
        var polizaId = await _crearPolizaHandler.Handle(dto);
        return Ok(new { PolizaId = polizaId });
    }

    [HttpPut]
    public async Task<IActionResult> Activar(Guid id)
    {
        await _activarPolizaHandler.Handle(id);
        return (Ok($"Poliza {id} acivada correctamente"));
    }
}