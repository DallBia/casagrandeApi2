using ClinicaAPI.DataContext;
using ClinicaAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ClinicaAPI.Service.ValorService
{
    public class ValorService : IValorInterface
    {
        private readonly ApplicationDbContext _context;
        public ValorService(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<ServiceResponse<List<ValorModel>>> CreateValor(ValorModel novoValor)
        {
            ServiceResponse<List<ValorModel>> serviceResponse = new ServiceResponse<List<ValorModel>>();

            try
            {
                if (novoValor == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados...";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }
                _context.Add(novoValor);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Valores.ToList();
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
       
        
        public async Task<ServiceResponse<List<ValorModel>>> DeleteValor(int Id)
        {
            var response = new ServiceResponse<List<ValorModel>>();

            try
            {
                var valorParaExcluir = await _context.Valores.FindAsync(Id);

                if (valorParaExcluir == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Valor não encontrado para exclusão.";
                    return response;
                }

                _context.Valores.Remove(valorParaExcluir);
                await _context.SaveChangesAsync();

                response.Sucesso = true;
                response.Dados = _context.Valores.ToList();
                response.Mensagem = "Valor excluído com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao excluir o valor: {ex.Message}";
            }

            return response;
        }
        

        public async Task<ServiceResponse<List<ValorModel>>> GetValor()
        {
            ServiceResponse<List<ValorModel>> serviceResponse = new ServiceResponse<List<ValorModel>>();

            try
            {
                serviceResponse.Dados = _context.Valores.ToList();
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

        public async Task<ServiceResponse<List<ValorModel>>> UpdateValor(ValorModel editValor)
        {
            ServiceResponse<List<ValorModel>> serviceResponse = new ServiceResponse<List<ValorModel>>();
            try
            {
                ValorModel Valor = _context.Valores.AsNoTracking().FirstOrDefault(x => x.id == editValor.id);


                if (Valor == null)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }


                _context.Valores.Update(editValor);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Valores.ToList();
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
