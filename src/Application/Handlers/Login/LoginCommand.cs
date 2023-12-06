using Application.Handlers.Login;
using MediatR;

public class LoginCommand : IRequest<LoginResult>
{
    public string User { get; }
    public string Password { get; }

    public LoginCommand(string user, string password)
    {
        User = user;
        Password = password;
    }
}
