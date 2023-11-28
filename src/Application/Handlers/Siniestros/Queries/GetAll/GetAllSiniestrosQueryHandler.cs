using Application.Services;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Siniestros.Queries.GetAll;

public class GetAllSiniestrosQueryHandler : IRequestHandler<GetAllSiniestrosQuery, List<SiniestroDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllSiniestrosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SiniestroDto>> Handle(GetAllSiniestrosQuery request, CancellationToken cancellationToken)
    {
        var estadoSiniestro = (EstadoSinistro)request.Estado;

        var siniestrosQuery = _context.Siniestros
        .Where(x =>
        (request.FechaDesde == null || x.Fecha >= request.FechaDesde) &&
        (request.FechaHasta == null || x.Fecha <= request.FechaHasta));

        if (request.Num != 0)
        {
            siniestrosQuery = siniestrosQuery.Where(x => x.Numero == request.Num);
        }

        if (estadoSiniestro != 0)
        {
            siniestrosQuery = siniestrosQuery.Where(x => x.Estado == estadoSiniestro);
        }

        var siniestros = await siniestrosQuery.ToListAsync();

        return _mapper.Map<List<SiniestroDto>>(siniestros);
    }
}