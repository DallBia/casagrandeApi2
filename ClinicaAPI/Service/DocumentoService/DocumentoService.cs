using ClinicaAPI.DataContext;
using ClinicaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaAPI.Service.DocumentoService
{
    public class DocumentoService : IDocumentoInterface

    {
        private readonly ApplicationDbContext _context;
        public DocumentoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<DocumentoModel>>> CreateDocumento(DocumentoModel novoDocumento)
        {
            ServiceResponse<List<DocumentoModel>> serviceResponse = new ServiceResponse<List<DocumentoModel>>();

            try
            {
                if (novoDocumento == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados...";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }
                _context.Add(novoDocumento);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Documentos.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";

                }
                foreach (var i in serviceResponse.Dados)
                {
                    i.arquivoPDF = null;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    

        public Task<ServiceResponse<List<DocumentoModel>>> DeleteDocumento(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<DocumentoModel>>> GetDocumento()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<DocumentoModel>>> GetDocumentobyArea(string Area)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<DocumentoModel>> GetDocumentobyId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<DocumentoModel>>> GetDocumentobyUser(string User)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<DocumentoModel>>> UpdateDocumento(DocumentoModel editDocumento)
        {
            throw new NotImplementedException();
        }
    }
}
