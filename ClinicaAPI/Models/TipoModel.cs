namespace ClinicaAPI.Models
{
    public class TipoModel
    {
        public int id { get; set; }
        public string nome { get; set; }

        public static implicit operator TipoModel(List<TipoModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
