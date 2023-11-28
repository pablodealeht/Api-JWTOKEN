using Application.Services;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Personal.Commands.Create;

public class CreatePersonalCommandHandler : IRequestHandler<CreatePersonalCommand, PersonalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<CreatePersonalCommandHandler> _logger;

    public CreatePersonalCommandHandler(IApplicationDbContext context, IMapper mapper,
        ILogger<CreatePersonalCommandHandler> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<PersonalDto> Handle(CreatePersonalCommand request, CancellationToken cancellationToken)
    {
        var personalExistente = await _context.Personales.AnyAsync(a => a.idEmployee == request.idEmployee, cancellationToken);
        if (personalExistente) throw new InvalidOperationException("Existe el Empleado.");

        var personal = _mapper.Map<RegPersonal>(request);

        _context.Personales.Add(personal);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<PersonalDto>(personal);
    }
}
