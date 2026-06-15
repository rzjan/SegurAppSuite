using SegurAppSuite.Domain.ValueObjects;

namespace SegurAppSuite.Domain.Entities;

public class Poliza
{
    public Guid Id { get; private set; }
    public Guid ClienteId { get; private set; }
    public Prima Prima { get; private set; }
    public PeriodoCobertura Cobertura { get; private set; }
    public string Estado { get; private set; }

    private readonly List<Siniestro> _siniestros = new();
    public IReadOnlyCollection<Siniestro> Siniestros => _siniestros.AsReadOnly();

    public Poliza() { } // Constructor para EF Core
    public Poliza(Guid id, Guid clienteId, Prima prima, PeriodoCobertura cobertura)
    {
        Id = id;
        ClienteId = clienteId;
        Prima = prima;
        Cobertura = cobertura;
        Estado = "Pendiente";
    }

    public void Activar()
    {
        if (Estado != "Pendiente")
            throw new InvalidOperationException("La póliza ya está activa o expirada.");
        Estado = "Activa";
    }

    public void RegistrarSiniestro(Siniestro siniestro)
    {
        if (Estado != "Activa")
            throw new InvalidOperationException("No se puede registrar siniestro en póliza inactiva.");
        if (!Cobertura.EstaDentroDelPeriodo(siniestro.Fecha))
            throw new InvalidOperationException("El siniestro está fuera del periodo de cobertura.");
        _siniestros.Add(siniestro);
    }
}
