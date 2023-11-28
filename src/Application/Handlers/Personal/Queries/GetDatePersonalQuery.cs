using MediatR;

namespace Application.Handlers.Personal.Queries
{
    public class GetDatePersonalQuery : IRequest<List<PersonalDto>>
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string? registerType { get; set; }
        public SucursalPersonalDto businessLocation { get; set; }
    }
}
