using Application.Handlers.Siniestros.Commands.Create;
using Application.Handlers.Siniestros.Commands.Delete;
using Application.Handlers.Siniestros.Queries.GetAll;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SiniestrosController : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    public SiniestrosController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllSiniestrosQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Siniestro>> DeleteSiniestro(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new DeleteSiniestroCommand
        {
            Id = id
        }, cancellationToken));
    }

   

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSiniestroCommand command)
    {
        return Created("", await _mediator.Send(command));
    }
}