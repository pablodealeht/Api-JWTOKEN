
using Application.Services;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Terceros.Command.Create;

public class CreateTercerosCommandHandler : IRequestHandler<CreateTercerosCommand, TerceroDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateTercerosCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TerceroDto> Handle(CreateTercerosCommand request, CancellationToken cancellationToken)
    {
        var siniestroExistente = await _context.Siniestros.AnyAsync(a => a.Id == request.SiniestroId, cancellationToken);
        if (!siniestroExistente) throw new InvalidOperationException("No existe el siniestro.");

        var tercero = _mapper.Map<Tercero>(request);

        _context.Terceros.Add(tercero);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TerceroDto>(tercero);
    }
}
