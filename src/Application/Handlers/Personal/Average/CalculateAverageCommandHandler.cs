using Application.Services;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

using System.Globalization;


namespace Application.Handlers.Personal.Average
{
    public class CalculateAverageCommandHandler : IRequestHandler<CalculateAverageCommand, Dictionary<Sucursal, Dictionary<string, PromedioSexo>>>
    {
        private readonly IApplicationDbContext _context;

        public CalculateAverageCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<Sucursal, Dictionary<string, PromedioSexo>>> Handle(CalculateAverageCommand request, CancellationToken cancellationToken)
        {
            var promedioPorSucursal = new Dictionary<Sucursal, Dictionary<string, PromedioSexo>>();

            var registros = await _context.Personales.ToListAsync(cancellationToken);

            var registrosAgrupados = registros.GroupBy(r => new { r.businessLocation, Mes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(r.FechaCreacion.Month) });

            foreach (var grupo in registrosAgrupados)
            {
                var sucursal = grupo.Key.businessLocation;
                var mes = grupo.Key.Mes;

                if (!promedioPorSucursal.ContainsKey(sucursal))
                {
                    promedioPorSucursal[sucursal] = new Dictionary<string, PromedioSexo>();
                }

                if (!promedioPorSucursal[sucursal].ContainsKey(mes))
                {
                    promedioPorSucursal[sucursal][mes] = new PromedioSexo();
                }

                var totalHombres = grupo.Count(r => r.Sexo == Sexo.Masculino);
                var totalMujeres = grupo.Count(r => r.Sexo == Sexo.Femenino);

                var promedio = promedioPorSucursal[sucursal][mes];
                promedio.Hombres = totalHombres / (double)grupo.Count();
                promedio.Mujeres = totalMujeres / (double)grupo.Count();
            }

            return promedioPorSucursal;
        }
    }


}
