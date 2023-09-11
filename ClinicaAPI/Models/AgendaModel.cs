using ClinicaAPI.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class AgendaModel
    {
        [Key]
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int IdFuncAlt { get; set; }
        public DateTime DtAlt { get; set; } = DateTime.Now.ToLocalTime();
        public string Horario { get; set; }
        public int Sala { get; set; }
        public int Unidade { get; set; }
        public DateOnly Dia { get; set; }
        public string DiaDaSemana
        {
            get
            {
                return DiaDaSemanaParaPortugues(Dia.DayOfWeek);
            }
        }

        private string DiaDaSemanaParaPortugues(DayOfWeek dia1)
        {
            switch (dia1)
            {
                case DayOfWeek.Sunday: return "DOM";
                case DayOfWeek.Monday: return "SEG";
                case DayOfWeek.Tuesday: return "TER";
                case DayOfWeek.Wednesday: return "QUA";
                case DayOfWeek.Thursday: return "QUI";
                case DayOfWeek.Friday: return "SEX";
                case DayOfWeek.Saturday: return "SAB";
                default: throw new ArgumentException("dia inválido");
            }
        }
        public ReptEnum Repeticao { get; set; }
        public string? Subtitulo { get; set; }
        public StatusEnum Status { get; set; } = 0;
        public string? Historico { get; set; }
        public string? Obs { get; set; }

    }
}
