namespace SegurAppSuite.Application.DTOs;

public class PolizaDto
{
    public Guid ClienteId { get; set; }
    public decimal Prima { get; set; }
    public string Moneda { get; set; }
    public DateTime InicioCobertura { get; set; }
    public DateTime FinCobertura { get; set; }
}
