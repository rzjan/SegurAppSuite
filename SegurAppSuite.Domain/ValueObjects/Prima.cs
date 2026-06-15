namespace SegurAppSuite.Domain.ValueObjects;

public record Prima
{
    public decimal Monto { get; init; }
    public string Moneda { get; init; }

    private Prima() { } // EF Core necesita un ctor vacío

    public Prima(decimal monto, string moneda)
    {
        Monto = monto;
        Moneda = moneda;
    }
}
