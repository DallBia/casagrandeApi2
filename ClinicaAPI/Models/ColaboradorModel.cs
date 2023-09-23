using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class ColaboradorModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateOnly DtNasc { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string? TelFixo { get; set; }
        public string? Celular { get; set; }
        public string Email { get; set; }
        public DateOnly DtAdmis { get; set; } = DateOnly.FromDateTime(DateTime.Now.ToLocalTime());
        public DateOnly DtDeslig { get; set; }
        public int IdPerfil { get; set; }
        public bool Ativo { get; set; } = true;
        public string? AreaSession { get; set; }
        public string SenhaHash { get; set; }


    }
}
