using ClinicaAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class EscolaModel
    {
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int? AnoLetivo { get; set; }
        public string? Serie { get; set; }
        public string? Escola { get; set; }
        public int? TelEscola { get; set; }
        public string? Professor { get; set; }
        public PeriodoEnum Periodo { get; set; }
    }
}
