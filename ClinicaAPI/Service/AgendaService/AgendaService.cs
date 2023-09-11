using ClinicaAPI.DataContext;
using ClinicaAPI.Models;
using ClinicaAPI.Service.AgendaService;
using Microsoft.EntityFrameworkCore;

namespace ClinicaAPI.Service.AgendaService
{
    public class AgendaService : IAgendaInterface
    {
        private readonly ApplicationDbContext _context;
        public AgendaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<AgendaModel>>> CreateAgenda(AgendaModel novoAgenda)
        {
            ServiceResponse<List<AgendaModel>> serviceResponse = new ServiceResponse<List<AgendaModel>>();

            try
            {
                if (novoAgenda == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados...";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }
                _context.Add(novoAgenda);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Agendas.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";

                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AgendaModel>>> DeleteAgenda(int Id)
        {
            ServiceResponse<List<AgendaModel>> serviceResponse = new ServiceResponse<List<AgendaModel>>();

            try
            {
                AgendaModel agenda = _context.Agendas.AsNoTracking().FirstOrDefault(x => x.Id == Id);


                if (agenda == null)
                {
                    serviceResponse.Mensagem = "Usuário não encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }


                _context.Agendas.Remove(agenda);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Agendas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<List<AgendaModel>>> GetAgendabyArea(string Area)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<AgendaModel>>> GetAgendabyCliente(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<AgendaModel>>> GetAgendabyDay(string Day)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<AgendaModel>> GetAgendabyId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<AgendaModel>>> UpdateAgenda(AgendaModel editAgenda)
        {
            throw new NotImplementedException();
        }
    }
}
