

namespace Domain;

public class Usuario
{
    public Usuario(string user, string password,
        int numero)
    {
        Id = Guid.NewGuid();
        User = user;
        Password = password;
        Numero = numero;
    }

    public Guid Id { get; set; }
    public string User {get; set;}
    public string Password { get; set;}
    public int Numero { get; set; }
}
