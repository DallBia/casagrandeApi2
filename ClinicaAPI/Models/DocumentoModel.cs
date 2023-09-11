using ClinicaAPI.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class DocumentoModel
    {
        [Key]
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string CliOuProf { get; set; }
        public string Tipo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DtInclusao { get; set; }


    }
}
