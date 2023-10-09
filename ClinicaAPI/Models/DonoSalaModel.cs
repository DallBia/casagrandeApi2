using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class DonoSalaModel
    {
        [Key]
        public int id { get; set; }
        public int unidade { get; set; }
        public int sala { get; set; }
        public int? idProfissional { get; set; }
        public string? area { get; set; }
        public string diaSemana { get; set; }
        public DateOnly dataInicio { get; set; }
        public DateOnly? dataFim { get; set; }
        public string periodo { get; set; }
    }
}
