

using System.Text.Json.Serialization;

namespace Application.Handlers.Personal.Average;

public class PromedioSexo
{
    public double Hombres { get; set; }
    public double Mujeres { get; set; }
}

public class Mes
{
    public int Numero { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public string Nombre { get; set; }
}