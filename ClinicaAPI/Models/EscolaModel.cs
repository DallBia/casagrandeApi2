using ClinicaAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class EscolaModel
    {
        [Key]
        public int id { get; set; }
        public int idCliente { get; set; }
        public int? anoLetivo { get; set; }
        public string? serie { get; set; }
        public string? escola { get; set; }
        public int? telEscola { get; set; }
        public string? professor { get; set; }
        public PeriodoEnum periodo { get; set; }
    }
}
