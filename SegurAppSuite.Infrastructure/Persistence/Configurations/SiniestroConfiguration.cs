using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SegurAppSuite.Domain.Entities;

namespace SegurAppSuite.Infrastructure.Persistence.Configurations;

public class SiniestroConfiguration : IEntityTypeConfiguration<Siniestro>
{
    public void Configure(EntityTypeBuilder<Siniestro> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Fecha)
               .IsRequired();

        builder.Property(s => s.Descripcion)
               .HasMaxLength(500);

        // Si Siniestro está dentro del agregado Poliza,
        // no necesita FK explícita: EF lo mapeará como colección.
        builder.ToTable("Siniestros");
    }
}
