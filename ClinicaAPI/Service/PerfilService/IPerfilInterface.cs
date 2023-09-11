using ClinicaAPI.Models;

namespace ClinicaAPI.Service.PerfilService
{
    public interface IPerfilInterface
    {
        Task<ServiceResponse<List<PerfilModel>>> GetPerfil();
        Task<ServiceResponse<List<PerfilModel>>> UpdatePerfil(PerfilModel editPerfil);
    }
}
