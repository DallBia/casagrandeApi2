using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class DocumentoModel
    {
        [Key]
        public int id { get; set; }
        public int idPessoa { get; set; }
        public string cliOuProf { get; set; }
        public string tipo { get; set; }
        public string? descricao { get; set; }
        public DateTime dtInclusao { get; set; }
        public string arquivo { get; set; }
        public byte[] arquivoPDF { get; set; }

    }
}
