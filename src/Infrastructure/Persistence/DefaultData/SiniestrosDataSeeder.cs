using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DefaultData;

public static class SiniestrosDataSeeder
{
    public static void Seed(ModelBuilder builder)
    {
        var siniestros = new List<Siniestro>()
        {
            new(
                "Me chocaron 😔",
                new DateTime(2023, 03, 01),
                "Av. Corrientes 1234",
                "CABA",
                "CABA",
                "Argentina"
            )
            {
                FechaCreacion = new DateTime(2023, 03, 02),
                Estado = EstadoSinistro.Finalizado
            },
            new(
                "Lo choqué 😨",
                new DateTime(2023, 03, 01),
                "Av. Corrientes 1234",
                "CABA",
                "CABA",
                "Argentina"
            )
            {
                FechaCreacion = new DateTime(2023, 03, 02),
                Estado = EstadoSinistro.Finalizado
            }
        };

        builder.Entity<Siniestro>().HasData(siniestros);
    }
}