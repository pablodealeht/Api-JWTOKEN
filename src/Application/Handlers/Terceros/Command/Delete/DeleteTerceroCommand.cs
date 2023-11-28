using MediatR;

namespace Application.Handlers.Terceros.Command.Delete;

public class DeleteTerceroCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
