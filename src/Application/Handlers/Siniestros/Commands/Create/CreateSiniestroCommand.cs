using Application.Handlers.Siniestros.Queries;
using MediatR;

namespace Application.Handlers.Siniestros.Commands.Create;

public class CreateSiniestroCommand : IRequest<Guid>
{
    public string? Descripcion { get; init; }
    public DateTime? Fecha { get; init; }
    public TipoSiniestroDto Tipo { get; init; }
    public string? Direccion { get; init; }
    public string? Localidad { get; init; }
    public string? Provincia { get; init; }
    public string? Pais { get; init; }
}
