namespace SegurAppSuite.Domain.ValueObjects;

//public record PeriodoCobertura(DateTime Inicio, DateTime Fin)
//{
//    public bool EstaDentroDelPeriodo(DateTime fecha)
//    {
//        return fecha >= Inicio && fecha <= Fin;
//    }
//}
public record PeriodoCobertura
{
    public DateTime FechaInicio { get; init; }
    public DateTime FechaFin { get; init; }

    private PeriodoCobertura() { } // EF Core necesita un ctor vacío

    public PeriodoCobertura(DateTime inicio, DateTime fin)
    {
        FechaInicio = inicio;
        FechaFin = fin;
    }

    public bool EstaDentroDelPeriodo(DateTime fecha)
    {
        return fecha >= FechaInicio && fecha <= FechaFin;
    }
}

