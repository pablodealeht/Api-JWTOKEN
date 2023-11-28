
namespace Application.Handlers.Siniestros.Queries;

public class SiniestroDto
{
    public int? Numero { get; set; }
    public string? Descripcion { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Estado { get; set; }
    public TipoSiniestroDto Tipo { get; set; }
    public string? Direccion { get; set; }
    public string? Localidad { get; set; }
    public string? Provincia { get; set; }
    public string? Pais { get; set; }
}
public enum TipoSiniestroDto
{
    Robo,
    Incendio,
    Choque
}
