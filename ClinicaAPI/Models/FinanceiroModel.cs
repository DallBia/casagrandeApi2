using System.ComponentModel.DataAnnotations;

namespace ClinicaAPI.Models
{
    public class FinanceiroModel
    {
        public  int id { get; set; }
        public  string espec { get; set; }
        public double valor { get; set; }
        public DateTime dtAlt { get; set; }

    }
}
