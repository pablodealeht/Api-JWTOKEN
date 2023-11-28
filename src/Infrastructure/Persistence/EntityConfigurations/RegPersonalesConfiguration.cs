using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class RegPersonalesConfiguration : IEntityTypeConfiguration<RegPersonal>
{
    public void Configure(EntityTypeBuilder<RegPersonal> builder)
    {
        builder.ToTable("PERSONAL", "USUARIOS");
        builder.HasKey(prop => prop.Id);
    }

}
