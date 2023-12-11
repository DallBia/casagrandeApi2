using ClinicaAPI.Models;

namespace ClinicaAPI.Service.ValorService
{
    public interface IValorInterface
    {
        Task<ServiceResponse<List<ValorModel>>> GetValor();
        Task<ServiceResponse<List<ValorModel>>> CreateValor(ValorModel novoValor); 
        Task<ServiceResponse<List<ValorModel>>> UpdateValor(ValorModel editValor);
        Task<ServiceResponse<List<ValorModel>>> DeleteValor(int Id); 
    }
}
