using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class PerfilModel
    {
        [Key]
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string? Help { get; set; }
        public bool? Dir { get; set; } = true;
        public bool? Secr { get; set; } = true;
        public bool? Coord { get; set; } = true;
        public bool? Equipe { get; set; } = false;
        public bool? SiMesmo { get; set; } = false;
    }
}
