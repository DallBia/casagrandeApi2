namespace ClinicaAPI.Models
{
    public class EmailRequest
    {
        public string Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Corpo { get; set; }
    }
}
