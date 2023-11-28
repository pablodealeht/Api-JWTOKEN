using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class SiniestrosConfiguration : IEntityTypeConfiguration<Siniestro>
{
    public void Configure(EntityTypeBuilder<Siniestro> builder)
    {
        builder.ToTable("SINIESTROS", "SINIESTROS");
        
        builder.HasKey(prop => prop.Id);

        builder.Property(x => x.Numero).ValueGeneratedOnAdd();

    }
}