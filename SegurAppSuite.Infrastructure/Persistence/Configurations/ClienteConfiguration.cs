using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SegurAppSuite.Domain.Entities;

namespace SegurAppSuite.Infrastructure.Persistence.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nombre)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(c => c.Email)
               .HasMaxLength(200)
               .IsRequired();

        // 🔹 Configurar Direcciones como colección de Owned Types
        builder.OwnsMany(c => c.Direcciones, direccion =>
        {
            direccion.WithOwner().HasForeignKey("ClienteId"); // FK implícita

            direccion.Property(d => d.Calle)
                     .HasColumnName("Calle")
                     .HasMaxLength(200)
                     .IsRequired();           

            direccion.Property(d => d.Ciudad)
                     .HasColumnName("Ciudad")
                     .HasMaxLength(100)
                     .IsRequired();

            direccion.Property(d => d.Provincia)
                     .HasColumnName("Provincia")
                     .HasMaxLength(100)
                     .IsRequired();

            // Opcional: nombre de la tabla para la colección
            direccion.ToTable("Direcciones");
        });

        builder.ToTable("Clientes");
    }
}
