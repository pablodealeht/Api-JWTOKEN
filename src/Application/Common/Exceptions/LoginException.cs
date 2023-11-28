namespace Application.Common.Exceptions;

public class LoginException : Exception
{
    public LoginException() : base("No se pudo autenticar el usuario")
    {
    }
}