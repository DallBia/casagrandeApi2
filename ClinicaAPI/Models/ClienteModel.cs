using ClinicaAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtInclusao { get; set; } = DateTime.Now.ToLocalTime();
        public bool SaiSozinho { get; set; } = false;
        public RespFinEnum RespFinanc { get; set; }
        public DateOnly DtNascim { get; set; }
        public DateTime ClienteDesde { get; set; } = DateTime.Now.ToLocalTime();
        public bool Ativo { get; set; } = true;
        public string? AreaSession { get; set; }
        public string? Identidade { get; set; }
        public string? Cpf { get; set; }
        public string? Celular { get; set; }
        public string? TelFixo { get; set; }
        public string? TelComercial { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        //DADOS DA MÃE:
        public string? Mae { get; set; }
        public bool MaeRestric { get; set; } = false;
        public string? MaeIdentidade { get; set; }
        public string? MaeCpf { get; set; }
        public string? MaeCelular { get; set; }
        public string? MaeTelFixo { get; set; }
        public string? MaeTelComercial { get; set; }
        public string MaeEmail { get; set; }
        public string MaeEndereco { get; set; }

        //DADOS DO PAI
        public string? Pai { get; set; }
        public bool PaiRestric { get; set; } = false;
        public string? PaiIdentidade { get; set; }
        public string? PaiCpf { get; set; }
        public string? PaiCelular { get; set; }
        public string? PaiTelFixo { get; set; }
        public string? PaiTelComercial { get; set; }
        public string PaiEmail { get; set; }
        public string PaiEndereco { get; set; }
        

    }
}
