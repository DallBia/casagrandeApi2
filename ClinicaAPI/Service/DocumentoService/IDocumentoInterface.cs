using ClinicaAPI.Models;

namespace ClinicaAPI.Service.DocumentoService
{
    public interface IDocumentoInterface
    {
        Task<ServiceResponse<List<DocumentoModel>>> GetDocumento();
        Task<ServiceResponse<List<DocumentoModel>>> CreateDocumento(DocumentoModel novoDocumento);
        Task<ServiceResponse<DocumentoModel>> GetDocumentobyId(int Id);
        Task<ServiceResponse<List<DocumentoModel>>> GetDocumentobyUser(string User);
        Task<ServiceResponse<List<DocumentoModel>>> GetDocumentobyArea(string Area);
        Task<ServiceResponse<List<DocumentoModel>>> UpdateDocumento(DocumentoModel editDocumento);
        Task<ServiceResponse<List<DocumentoModel>>> DeleteDocumento(int Id);
    }
}
