using Application.Common.Exceptions;
using Application.Services;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Siniestros.Commands.Delete;

public class DeleteSiniestroCommandHandler : IRequestHandler<DeleteSiniestroCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteSiniestroCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteSiniestroCommand request, CancellationToken cancellationToken)
    {
        var siniestro = await _context.Siniestros.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                       ?? throw new NotFoundException<Siniestro>(request.Id);

        _context.Siniestros.Remove(siniestro);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
