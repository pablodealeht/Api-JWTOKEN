using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AutenticacionController : Controller
{
    private readonly string secretKey;
    private readonly IMediator _mediator;

    public AutenticacionController(IMediator mediator, IConfiguration config)
    {
        secretKey = config.GetSection("settings").GetSection("KeySecret").ToString();
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginCommand request)
    {
        try
        {
            var result = await _mediator.Send(request);
            return Ok(new { Message = "Inicio de sesión exitoso", Token = result.Token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = $"Error al iniciar sesión: {ex.Message}" });
        }
    }
}
