using MediatR;

namespace Application.Handlers.Siniestros.Queries.GetAll;

public class GetAllSiniestrosQuery : IRequest<List<SiniestroDto>>
{
    public DateTime? FechaDesde { get; set; }
    public DateTime? FechaHasta { get; set; }
    public int Num { get; set; }
    public int Estado { get; set; }
}