
using Domain.Abstractions;

namespace Domain
{
    public class RegPersonal : BaseEntity
    {
        public int idEmployee { get; set; }
        public string registerType { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Sexo Sexo { get; set; }
        public Sucursal businessLocation { get; set; }
        
    }

    public enum Sucursal
    {
        SucursalUno,
        SucursalDos
    }

    public enum Sexo
    {
        Masculino,
        Femenino
    }
}
