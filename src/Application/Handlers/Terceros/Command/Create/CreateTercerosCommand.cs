
using MediatR;

namespace Application.Handlers.Terceros.Command.Create;

public class CreateTercerosCommand : IRequest<TerceroDto>
{
    public Guid SiniestroId { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Dni { get; set; }
    public int Tipo { get; set; }
}

