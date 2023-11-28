using Domain;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.DefaultData;
public static class UsuariosDataSeeder
{
    public static void Seed(ModelBuilder builder)
    {
        var usuarios = new List<Usuario>()
        {
            new("a@a.com","1234", 1)
           
        };

        builder.Entity<Usuario>().HasData(usuarios);
    }
}