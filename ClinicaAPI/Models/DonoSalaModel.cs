using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class DonoSalaModel
    {
        [Key]
        public int Id { get; set; }
        public int Unidade { get; set; }
        public int Sala { get; set; }
        public int? IdProfissional { get; set; }
        public string DiaSemana { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly? DataFim { get; set; }
        public string Periodo { get; set; }
    }
}
