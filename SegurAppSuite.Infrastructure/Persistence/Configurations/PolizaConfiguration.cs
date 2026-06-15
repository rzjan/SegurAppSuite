using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SegurAppSuite.Domain.Entities;

namespace SegurAppSuite.Infrastructure.Persistence.Configurations;

public class PolizaConfiguration : IEntityTypeConfiguration<Poliza>
{
    public void Configure(EntityTypeBuilder<Poliza> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ClienteId)
               .IsRequired();

        builder.OwnsOne(p => p.Prima, prima =>
        {
            prima.Property(pr => pr.Monto)
                 .HasColumnName("PrimaValor")
                 .HasPrecision(18,2)
                 .IsRequired();

            prima.Property(pr => pr.Moneda)
                 .HasColumnName("PrimaMoneda")
                 .HasMaxLength(10)
                 .IsRequired();
        });

        builder.OwnsOne(p => p.Cobertura, cobertura =>
        {
            cobertura.Property(c => c.FechaInicio)
                     .HasColumnName("CoberturaInicio")
                     .IsRequired();

            cobertura.Property(c => c.FechaFin)
                     .HasColumnName("CoberturaFin")
                     .IsRequired();
        });


        builder.ToTable("Polizas");
    }
}
