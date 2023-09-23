namespace ClinicaAPI.Models
{
    public class ProntuarioModel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdColab { get; set; }
        public string Tipo { get; set; }
        public DateTime DtInsercao { get; set; }
        public string Texto { get; set; }

    }
}
