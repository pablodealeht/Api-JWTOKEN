using Application.Handlers.Siniestros.Commands.Create;
using Application.Handlers.Terceros.Command.Create;
using Application.Handlers.Terceros;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Handlers.Personal;
using Application.Handlers.Siniestros.Queries.GetAll;
using Application.Handlers.Personal.Commands.Create;
using Application.Handlers.Personal.Queries;
using Application.Handlers.Personal.Average;
using Domain;

namespace WebApi.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class PersonalController : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    public PersonalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[HttpPost]
    //public async Task<IActionResult> RegisterPersonal([FromBody] CreatePersonalCommand command)
    //{
    //    return Created("", await _mediator.Send(command));
    //}


    [HttpPost]
    public async Task<ActionResult<PersonalDto>> RegisterPersonal(CreatePersonalCommand command,
    CancellationToken cancellationToken)
    {
        return await Mediator.Send(command, cancellationToken);
    }

    [HttpGet("/RangoFechas/")]
    public async Task<IActionResult> GetDate([FromQuery] GetDatePersonalQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("/Promedio/")]
    public async Task<ActionResult<Dictionary<Sucursal, Dictionary<Mes, PromedioSexo>>>> ObtenerPromedio()
    {
        var promedioCommand = new CalculateAverageCommand();
        var resultado = await _mediator.Send(promedioCommand);

        return Ok(resultado);
    }

}
