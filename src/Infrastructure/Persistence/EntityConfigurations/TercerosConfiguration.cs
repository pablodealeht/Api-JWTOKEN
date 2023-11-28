using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class TercerosConfiguration : IEntityTypeConfiguration<Tercero>
{
    public void Configure(EntityTypeBuilder<Tercero> builder)
    {
        builder.ToTable("TERCEROS", "SINIESTROS");
        
        builder.HasKey(prop => prop.Id);

        builder.HasOne(tercero => tercero.Siniestros)
             .WithMany(siniestro => siniestro.Terceros)
             .HasForeignKey(tercero => tercero.SiniestroId);

    }
}
