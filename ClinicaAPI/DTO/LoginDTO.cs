using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.DTO
{
    public class LoginDTO
    {
        [Key]
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
