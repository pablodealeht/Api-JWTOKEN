using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("USUARIOS", "USUARIOS");

        builder.HasKey(prop => prop.Id);

        builder.Property(x => x.Numero).ValueGeneratedOnAdd();

    }
}
