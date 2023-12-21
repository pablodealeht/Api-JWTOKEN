using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace Application.Handlers.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly IApplicationDbContext _context;
    private readonly IConfiguration _config;
    private readonly ILogger<LoginCommandHandler> _logger;
    private readonly IMapper _mapper;

    public LoginCommandHandler(IApplicationDbContext context, IConfiguration config,IMapper mapper,
        ILogger<LoginCommandHandler> logger)
    {
        _context = context;
        _config = config;
        _logger = logger;
        _mapper = mapper;

    }

    public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var usuarioValidado = await _context.Usuarios
            .FirstOrDefaultAsync(x => request.User == x.User && request.Password == x.Password, cancellationToken);

        if (usuarioValidado != null)
        {
            var keyBytes = Encoding.ASCII.GetBytes(_config.GetSection("settings").GetSection("KeySecret").ToString());
            var claims = new ClaimsIdentity();

        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.User));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claims,
            Expires = DateTime.UtcNow.AddMinutes(1), //Tiempo Logueo
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
        string tokenCreado = tokenHandler.WriteToken(tokenConfig);

        return new LoginResult { Token = tokenCreado };
        }
        _logger.LogError("Usuario no validado");
        throw new InvalidOperationException("Usuario no validado");
    }
}
public class LoginResult
{
    public string Token { get; set; }
}
