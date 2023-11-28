using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Handlers.Login;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AutenticacionController : Controller
{
    private readonly string secretKey;

    public AutenticacionController(IConfiguration config)
    {
        secretKey = config.GetSection("settings").GetSection("KeySecret").ToString();
    }

    [HttpPost]
    [Route("Validar")]
    public IActionResult Validar([FromBody] Usuario request)
    {

        //TODO: Se implementaria esta parte en CQRS
        if(request.User == "a@a.com" && request.Password == "123")
        {
            var keyBytes = Encoding.ASCII.GetBytes(secretKey);
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.User));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string tokenCreado = tokenHandler.WriteToken(tokenConfig);
            return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });
        }
        else
        {
            return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
        }

    }

    //[HttpPost]
    //[Route("Validar")]
    //public async Task<IActionResult> Login([FromBody] LoginCommand request)
    //{

    //    //TODO: Se implementaria esta parte en CQRS
    //    if (request.User == "a@a.com" && request.Password == "123")
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

}
