using System.Text.Json.Serialization;

namespace ClinicaAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReptEnum
    {
        Unica,
        Diaria,
        Semanal,
        Quinzenal,
        Mensal,
        Cancelar
    }
}
