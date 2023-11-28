
namespace Application.Handlers.Personal;

public class PersonalDto
{
    public Guid Id { get; set; }

    public int idEmployee { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string registerType { get; set; }

    public SexoDto Sexo { get; set; }
    public string businessLocation { get; set; }
}

public enum SucursalPersonalDto
{
    SucursalUno,
    SucursalDos
}

public enum SexoDto
{
    Masculino,
    Femenino
}