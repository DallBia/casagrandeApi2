using ClinicaAPI.Models;

namespace ClinicaAPI.Service.ClienteService
{
    public interface IClienteInterface
    {
        Task<ServiceResponse<List<ClienteModel>>> GetCliente();
        Task<ServiceResponse<List<ClienteModel>>> CreateCliente(ClienteModel novoCliente);
        Task<ServiceResponse<ClienteModel>> GetClientebyId(int Id);
        Task<ServiceResponse<ClienteModel>> GetClientebyEmail(string Email);
        Task<ServiceResponse<List<ClienteModel>>> GetClientebyArea(string Area);
        Task<ServiceResponse<List<ClienteModel>>> UpdateCliente(ClienteModel editCliente);
        Task<ServiceResponse<List<ClienteModel>>> DeleteCliente(int Id);
        Task<ServiceResponse<List<ClienteModel>>> ActivateCliente(int Id);
        Task<ServiceResponse<List<ClienteModel>>> GetClientebyNome(string atr, string par, string ret);

        Task<ServiceResponse<List<TipoModel>>> GetClientebyAgenda();
    }

}
