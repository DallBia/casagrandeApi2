using ClinicaAPI.Models;

namespace ClinicaAPI.Service.FormacaoService
{
    public interface IFormacaoInterface
    {
        Task<ServiceResponse<List<FormacaoModel>>> GetFormacao();
        Task<ServiceResponse<List<FormacaoModel>>> CreateFormacao(FormacaoModel novoFormacao);
        Task<ServiceResponse<FormacaoModel>> GetFormacaobyId(int Id);
        Task<ServiceResponse<List<FormacaoModel>>> GetFormacaobyArea(string Area);
        Task<ServiceResponse<List<FormacaoModel>>> UpdateFormacao(FormacaoModel editFormacao);
    }
}
