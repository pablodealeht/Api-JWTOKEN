using Application.Services;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Siniestros.Commands.Create;

public class CreateSiniestroCommandHandler : IRequestHandler<CreateSiniestroCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateSiniestroCommandHandler> _logger;

    public CreateSiniestroCommandHandler(IApplicationDbContext context, IMapper mapper,
        ILogger<CreateSiniestroCommandHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateSiniestroCommand request, CancellationToken cancellationToken)
    {
        var siniestro = _mapper.Map<Siniestro>(request);
        
        _context.Siniestros.Add(siniestro);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Siniestro {Id} creado", siniestro.Id);
        
        return siniestro.Id;
    }
}