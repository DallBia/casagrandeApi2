using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;

        public static implicit operator ServiceResponse<T>(ServiceResponse<List<ProntuarioModel>> v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator ServiceResponse<T>(ActionResult<ServiceResponse<List<EmailRequest>>> v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator ServiceResponse<T>(ServiceResponse<EmailRequest> v)
        {
            throw new NotImplementedException();
        }
    }
}
