using ClinicaAPI.Models;

namespace ClinicaAPI.Service.InfoService
{
    public interface InfoInterface
    {
        Task<ServiceResponse<List<InfoModel>>> GetInfo();
        Task<ServiceResponse<List<InfoModel>>> CreateInfo(InfoModel novoInfo);
        Task<ServiceResponse<InfoModel>> GetInfobyId(int Id);
        Task<ServiceResponse<List<InfoModel>>> UpdateInfo(InfoModel editInfo);
    }
}
