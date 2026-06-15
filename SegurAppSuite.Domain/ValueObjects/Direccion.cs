namespace SegurAppSuite.Domain.ValueObjects;

public class Direccion
{
    public string Calle { get; private set; }
    public string Ciudad { get; private set; }
    public string Provincia { get; private set; }

    public Direccion() { } // Constructor para EF Core
    public Direccion(string calle, string ciudad, string provincia)
    {
        Calle = calle;
        Ciudad = ciudad;
        Provincia = provincia;
    }
}
