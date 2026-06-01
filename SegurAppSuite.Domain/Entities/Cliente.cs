using SegurAppSuite.Domain.ValueObjects;

namespace SegurAppSuite.Domain.Entities;

public class Cliente
{
    // Propiedades del cliente
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set;} = string.Empty;

    // Relación uno a muchos con Direccion
    private readonly List<Direccion> _direcciones = new();

    // Método para agregar una dirección al cliente
    public IReadOnlyCollection<Direccion> Direcciones => _direcciones.AsReadOnly();

    public Cliente(Guid id, string nombre, string email)
    {
        Id = id;
        Nombre = nombre;
        Email = email;    
    }

    public void AgregarDireccion(Direccion direccion)
    {
        if (direccion == null)
            throw new ArgumentNullException(nameof(direccion));
        _direcciones.Add(direccion);
    }
}
