using Domain;
using MediatR;

namespace Application.Handlers.Personal.Commands.Create;

public class CreatePersonalCommand : IRequest<PersonalDto>
{

    public int idEmployee { get; set; }
    public string registerType { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public SexoDto Sexo { get; set; }
    public SucursalPersonalDto businessLocation { get; set; }
}
