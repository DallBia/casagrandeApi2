using System.Text.Json.Serialization;

namespace ClinicaAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReptEnum
    {
        Sessão_Única,
        Semanal,
        Quinzenal,
        Mensal,
        Terminar_Repetições
    }
}
