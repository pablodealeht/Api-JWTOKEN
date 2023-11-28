

using MediatR;

namespace Application.Handlers.Siniestros.Commands.Delete;

public class DeleteSiniestroCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
