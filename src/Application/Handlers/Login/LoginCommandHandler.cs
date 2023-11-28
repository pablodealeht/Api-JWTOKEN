using Application.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Login;
public class LoginCommandHandler
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<LoginCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly string secretKey;

    public LoginCommandHandler(IApplicationDbContext context,
        ILogger<LoginCommandHandler> logger,
        IMapper mapper,
        IConfiguration config)
    {
        secretKey = config.GetSection("settings").GetSection("KeySecret").ToString();
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    //public async Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
    //{
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


    //        return Unit.Value;

    //        //    return StatusCodes(StatusCodes.Status200OK, new { token = tokenCreado });
    //        //}
    //        //else
    //        //{
    //        //    return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
    //        //}
    //    }
    }
//}
