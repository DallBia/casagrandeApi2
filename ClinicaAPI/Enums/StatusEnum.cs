using System.Text.Json.Serialization;

namespace ClinicaAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEnum
    {
        Vago,
        Bloqueado,
        Pendente,
        Realizado,
        Desmarcado,
        Falta,
        Reservado,
        Sala
    }
}
