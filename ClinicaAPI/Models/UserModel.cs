using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class UserModel
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public DateOnly dtNasc { get; set; }
        public string? rg { get; set; }
        public string? cpf { get; set; }
        public string? endereco { get; set; }
        public string? telFixo { get; set; }
        public string? celular { get; set; }
        public string email { get; set; }
        public DateOnly dtAdmis { get; set; } 
        public DateOnly? dtDeslig { get; set; }
        public int idPerfil { get; set; }
        public bool ativo { get; set; } = true;
        public string? areaSession { get; set; }
        public string senhaHash { get; set; }
    }

}
