using ClinicaAPI.DataContext;
using ClinicaAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ClinicaAPI.Service.PerfilService
{
    public class PerfilService : IPerfilInterface
    {
        private readonly ApplicationDbContext _context;

        public PerfilService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<PerfilModel>>> GetPerfil()
        {
            ServiceResponse<List<PerfilModel>> serviceResponse = new ServiceResponse<List<PerfilModel>>();

            try
            {
                serviceResponse.Dados = _context.Perfils.ToList();
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

        public async Task<ServiceResponse<List<PerfilModel>>> UpdatePerfil(PerfilModel editPerfil)
        {
            ServiceResponse<List<PerfilModel>> serviceResponse = new ServiceResponse<List<PerfilModel>>();
            try
            {
                PerfilModel perfil = _context.Perfils.AsNoTracking().FirstOrDefault(x => x.Id == editPerfil.Id);


                if (perfil == null)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }


                _context.Perfils.Update(editPerfil);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Perfils.ToList();
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
