using ClinicaAPI.DataContext;
using ClinicaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaAPI.Service.DonoSalaService
{
    public class DonoSalaService : IDonoSalaInterface 
    {
        private readonly ApplicationDbContext _context;
        public DonoSalaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<DonoSalaModel>>> CreateDonoSala(DonoSalaModel novoDonoSala)
        {
            ServiceResponse<List<DonoSalaModel>> serviceResponse = new ServiceResponse<List<DonoSalaModel>>();

            try
            {
                if (novoDonoSala == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados...";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }
                _context.Add(novoDonoSala);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.DonoSalas.ToList();
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

        public async Task<ServiceResponse<List<DonoSalaModel>>> GetDonoSala()
        {
            ServiceResponse<List<DonoSalaModel>> serviceResponse = new ServiceResponse<List<DonoSalaModel>>();
            
            DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
            try
            {
                List<DonoSalaModel> Dono = _context.DonoSalas
                    .Where(x => x.dataFim >= dataAtual)
                    .ToList();
                serviceResponse.Mensagem = "Dados nulos";
                if (serviceResponse.Dados != null)
                {
                    if (serviceResponse.Dados.Count == 0 || serviceResponse.Dados == null)
                    {
                        serviceResponse.Mensagem = "Nenhum dado encontrado.";
                    }
                }
                
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DonoSalaModel>>> UpdateDonoSala(DonoSalaModel editDonoSala)
        {
            ServiceResponse<List<DonoSalaModel>> serviceResponse = new ServiceResponse<List<DonoSalaModel>>();
            try
            {
                DonoSalaModel donoSala = _context.DonoSalas.AsNoTracking().FirstOrDefault(x => x.id == editDonoSala.id);


                if (donoSala == null)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }


                _context.DonoSalas.Update(editDonoSala);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.DonoSalas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
