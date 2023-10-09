using ClinicaAPI.Models;

namespace ClinicaAPI.Service.DonoSalaService
{
    public interface IDonoSalaInterface
    {
        Task<ServiceResponse<List<DonoSalaModel>>> GetDonoSala();
        Task<ServiceResponse<List<DonoSalaModel>>> CreateDonoSala(DonoSalaModel novoDonoSala);
        Task<ServiceResponse<List<DonoSalaModel>>> UpdateDonoSala(DonoSalaModel editDonoSala);
    }
}
