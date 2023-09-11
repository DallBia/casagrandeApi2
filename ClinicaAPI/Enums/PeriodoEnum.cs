using System.Text.Json.Serialization;

namespace ClinicaAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PeriodoEnum
    {
        Manhã,
        Tarde,
        Noite,
        Integral,
        Online,
        Indefinido
    }
}
