

namespace Domain;

public class Usuario
{
    public Usuario() //Fundamental poner el constructor para bindiar
    {
    }

    public Usuario(string user, string password,
        int numero, Perfil perfiles)
    {
        Id = Guid.NewGuid();
        User = user;
        Password = password;
        Numero = numero;
        Perfil = perfiles;
    }

    public Guid Id { get; set; }
    public string User {get; set;}
    public string Password { get; set;}
    public int Numero { get; set; }
    public Perfil Perfil { get; set; }
}

public enum Perfil
{
    Administrador = 1,
    Vendedor = 2,
    Usuario = 3
}