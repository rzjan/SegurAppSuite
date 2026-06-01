namespace SegurAppSuite.Domain.ValueObjects;

public record PeriodoCobertura(DateTime Inicio, DateTime Fin)
{
    public bool EstaDentroDelPeriodo(DateTime fecha)
    {
        return fecha >= Inicio && fecha <= Fin;
    }
}

