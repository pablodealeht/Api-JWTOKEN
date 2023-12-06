using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Handlers.Login;
using Application.Handlers.Personal.Commands.Create;
using Application.Handlers.Personal;
using MediatR;

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

    //[HttpPost]
    //[Route("Validar")]
    //public IActionResult Validar([FromBody] Usuario request)
    //{

    //    //TODO: Se implementaria esta parte en CQRS
    //    if(request.User == "a@a.com" && request.Password == "123")
    //    {
    //        var keyBytes = Encoding.ASCII.GetBytes(secretKey);
    //        var claims = new ClaimsIdentity();

    //        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.User));
    //        var tokenDescriptor = new SecurityTokenDescriptor
    //        {
    //            Subject = claims,
    //            Expires = DateTime.UtcNow.AddMinutes(5),
    //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
    //        };
    //        var tokenHandler = new JwtSecurityTokenHandler();
    //        var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
    //        string tokenCreado = tokenHandler.WriteToken(tokenConfig);
    //        return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });
    //    }
    //    else
    //    {
    //        return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
    //    }

    //}



    [HttpPost]
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
