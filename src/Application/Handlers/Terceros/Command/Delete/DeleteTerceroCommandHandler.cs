using Application.Common.Exceptions;
using Application.Services;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Terceros.Command.Delete;

public class DeleteTerceroCommandHandler : IRequestHandler<DeleteTerceroCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteTerceroCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteTerceroCommand request, CancellationToken cancellationToken)
    {
        var tercero = await _context.Terceros.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                       ?? throw new NotFoundException<Tercero>(request.Id);

        _context.Terceros.Remove(tercero);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

}
