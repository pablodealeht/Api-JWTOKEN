using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Personal.Average;

public class CalculateAverageCommand : IRequest<Dictionary<Sucursal, Dictionary<string, PromedioSexo>>>
{
}
