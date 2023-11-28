
using Application.Handlers.Terceros;
using Application.Handlers.Terceros.Command.Create;
using Application.Handlers.Terceros.Command.Delete;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TercerosController : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    public TercerosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<TerceroDto>> CreateTercero2(CreateTercerosCommand command,
       CancellationToken cancellationToken)
    {
        return await Mediator.Send(command, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Tercero>> DeleteTercero(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new DeleteTerceroCommand
        {
            Id = id
        }, cancellationToken));
    }
}
