using MediatR;

namespace Application.Handlers.Login;
//public record LoginResult(bool Success, string? Token, string? RefreshToken);

public class LoginCommand : IRequest<Unit>
{
    public string User { get; }
    public string Password { get; }



    //public readonly IPAddress? RemoteIpAddress;

    //public LoginCommand(IPAddress? remoteIpAddress, string username, string password)
    //{
    //    RemoteIpAddress = remoteIpAddress;
    //    Username = username;
    //    Password = password;
    //}

    //public string Password { get; }
    //public string Username { get; }
}