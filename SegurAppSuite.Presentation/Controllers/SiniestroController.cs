using Microsoft.AspNetCore.Mvc;
using SegurAppSuite.Application.DTOs;
using SegurAppSuite.Application.UseCases;
using SegurAppSuite.Domain.Entities;

namespace SegurAppSuite.Presentation.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class SiniestroController: ControllerBase
{
    private readonly RegistrarSiniestroHandler _registrarSiniestroHandler;

    public SiniestroController(RegistrarSiniestroHandler registrarSiniestroHandler)
    {
        _registrarSiniestroHandler = registrarSiniestroHandler;
    }

    [HttpPost("{polizaId}")]
    public async Task<IActionResult> Registrar(Guid polizaId, [FromBody] SiniestroDto dto)
    {
        var siniestro = new Siniestro(Guid.NewGuid(), dto.Fecha, dto.Descripcion);
        return Ok("Siniestro registrado correctamente");
    }

}
