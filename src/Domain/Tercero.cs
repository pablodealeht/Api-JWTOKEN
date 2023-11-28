using Domain.Abstractions;

namespace Domain;

public class Tercero : BaseEntity
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Dni { get; set; }
    public TipoTercero Tipo { get; set; }
    public Guid SiniestroId { get; set; }
    public virtual Siniestro Siniestros { get; set; }
}
public enum TipoTercero
{
    Conductor,
    Acompañante,
    Peaton
}