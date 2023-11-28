namespace Application.Handlers.Terceros; 

public class TerceroDto
{
    public Guid SiniestroId { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Dni { get; set; }
    public TipoTerceroDto Tipo { get; set; }
}
public enum TipoTerceroDto
{
    Conductor,
    Acompañante,
    Peaton
}
