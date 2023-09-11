using System.Text.Json.Serialization;

namespace ClinicaAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RespFinEnum
    {
        Pai,
        Mãe,
        Cliente
    }
}