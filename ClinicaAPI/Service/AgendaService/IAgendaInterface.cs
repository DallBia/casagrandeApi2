using ClinicaAPI.Models;

namespace ClinicaAPI.Service.AgendaService
{
    public interface IAgendaInterface
    {
        Task<ServiceResponse<List<AgendaModel>>> CreateAgenda(AgendaModel novoAgenda);
        Task<ServiceResponse<List<AgendaModel>>> UpdateAgenda(AgendaModel editAgenda);
        Task<ServiceResponse<AgendaModel>> GetAgendabyId(int Id);
        Task<ServiceResponse<List<AgendaModel>>> GetAgendabyCliente(string Id);
        Task<ServiceResponse<List<AgendaModel>>> GetAgendabyArea(string Area);
        Task<ServiceResponse<List<AgendaModel>>> DeleteAgenda(int Id);
        Task<ServiceResponse<List<AgendaModel>>> GetAgendabyDay(string Day);
    }
}