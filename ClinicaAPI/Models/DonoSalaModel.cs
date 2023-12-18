using Org.BouncyCastle.Asn1.Cmp;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ClinicaAPI.Models
{
    public class DonoSalaModel
    {
        [Key]
        public int id { get; set; }
        public int unidade { get; set; }
        public int sala { get; set; }
        public int? idProfissional { get; set; } // pode ser o do Cliente
        public string? area { get; set; }
        public string diaSemana { get; set; }
        public DateOnly dataInicio { get; set; }
        public string configRept { get; set; }  // sempre no formato X%Y%Z
        public DateOnly? dataFim { get; set; }
        public string periodo { get; set; } // na verdade, horário.
    }
}
