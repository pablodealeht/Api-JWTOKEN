using Domain.Abstractions;

namespace Domain;

public class Siniestro : BaseEntity
{
    public Siniestro(string descripcion, DateTime fecha,
        string direccion, string localidad, string provincia, string pais)
    {
        Id = Guid.NewGuid();
        Descripcion = descripcion;
        Fecha = fecha;
        Estado = EstadoSinistro.EnProceso;
        Tipo = TipoSiniestro.Choque;
        Direccion = direccion;
        Localidad = localidad;
        Provincia = provincia;
        Pais = pais;
    }

    public int Numero { get; set; }
    public string Descripcion { get; set; }
    public DateTime Fecha { get; set; }
    public EstadoSinistro Estado { get; set; }
    public TipoSiniestro Tipo { get; set; }
    public string Direccion { get; set; }
    public string Localidad { get; set; }
    public string Provincia { get; set; }
    public string Pais { get; set; }
    public virtual ICollection<Tercero> Terceros { get; set; } = new List<Tercero>();

}

public enum EstadoSinistro
{
    EnProceso,
    Finalizado
}

public enum TipoSiniestro
{
    Robo,
    Incendio,
    Choque
}