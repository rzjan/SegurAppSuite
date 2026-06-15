namespace SegurAppSuite.Domain.Entities;

public class Siniestro
{
    public Guid Id { get; private set; }
    public DateTime Fecha { get; private set; }
    public string Descripcion { get; private set; }
    public string Estado { get; private set; }

    public Siniestro() { } // Constructor para EF Core
    public Siniestro(Guid id, DateTime fecha, string descripcion)
    {
        Id = id;
        Fecha = fecha;
        Descripcion = descripcion;
        Estado = "Registrado";
    }

    public void Evaluar()
    {
        if (Estado != "Registrado")
            throw new InvalidOperationException("El siniestro no puede evaluarse en este estado.");
        Estado = "EnEvaluacion";
    }
}
