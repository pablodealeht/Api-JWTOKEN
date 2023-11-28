using Application.Handlers.Siniestros.Queries.GetAll;
using Application.Handlers.Siniestros.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Application.Handlers.Personal.Queries;

public class GetDatePersonalQueryHandler : IRequestHandler<GetDatePersonalQuery, List<PersonalDto>>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDatePersonalQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PersonalDto>> Handle(GetDatePersonalQuery request, CancellationToken cancellationToken)
    {
        var estadobusinessLocation = (Sucursal)request.businessLocation;

        var personalQuery = _context.Personales
        .Where(x =>
        (request.FechaDesde == null || x.FechaCreacion >= request.FechaDesde) &&
        (!request.FechaHasta.HasValue || x.FechaCreacion <= request.FechaHasta) &&
        (string.IsNullOrEmpty(request.registerType) || x.registerType.Contains(request.registerType)));


        if (estadobusinessLocation != 0)
        {
            personalQuery = personalQuery.Where(x => x.businessLocation == estadobusinessLocation);
        }

        var personales = await personalQuery.ToListAsync();

        return _mapper.Map<List<PersonalDto>>(personales);
    }
}
