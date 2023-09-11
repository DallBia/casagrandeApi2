using ClinicaAPI.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Mae { get; set; }
        public string? Pai { get; set; }
        public DateTime DtInclusao { get; set; } = DateTime.Now.ToLocalTime();
        public bool MaeRestric { get; set; } = false;
        public bool PaiRestric { get; set; } = false;
        public bool SaiSozinho { get; set; } = false;
        public RespFinEnum RespFinanc { get; set; }
        public string? Identidade { get; set; }
        public DateOnly DtNascim { get; set; }
        public string? Celular { get; set; }
        public string? TelFixo { get; set; }
        public string? TelComercial { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime ClienteDesde { get; set; } = DateTime.Now.ToLocalTime();
        public bool Ativo { get; set; } = true;
        public string? AreaSession { get; set; }

    }
}
