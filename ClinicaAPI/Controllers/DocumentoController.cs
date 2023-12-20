using ClinicaAPI.Models;
using ClinicaAPI.Service.DocumentoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoInterface _documentoInterface;
        public DocumentoController(IDocumentoInterface documentoInterface)
        {
            _documentoInterface = documentoInterface;
        }

        [Authorize]
        [HttpGet("id/{id}")]
        public async Task<ActionResult<ServiceResponse<DocumentoModel>>> GetDocumentobyId(int Id)
        {
            ServiceResponse<DocumentoModel> serviceResponse = await _documentoInterface.GetDocumentobyId(Id);
            return Ok(serviceResponse);
        }
        [Authorize]
        [HttpGet("Email")]
        public async Task<ActionResult<ServiceResponse<List<DocumentoModel>>>> GetDocumentobyUser(string User)
        {
            ServiceResponse<List<DocumentoModel>> serviceResponse = await _documentoInterface.GetDocumentobyUser(User);
            return Ok(serviceResponse);
        }
        [HttpGet("Area")]
        public async Task<ActionResult<ServiceResponse<List<DocumentoModel>>>> GetDocumentobyArea(string Area)
        {
            ServiceResponse<List<DocumentoModel>> serviceResponse = await _documentoInterface.GetDocumentobyArea(Area);
            return Ok(serviceResponse);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DocumentoModel>>>> GetDocumento()
        {
            return Ok(await _documentoInterface.GetDocumento());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<DocumentoModel>>>> CreateDocumento(DocumentoModel novoDocumento)
        {
            return Ok(await _documentoInterface.CreateDocumento(novoDocumento));
        }

        [HttpPut("Editar")]
        public async Task<ActionResult<ServiceResponse<List<DocumentoModel>>>> UpdateDocumento(DocumentoModel editDocumento)
        {
            ServiceResponse<List<DocumentoModel>> serviceResponse = await _documentoInterface.UpdateDocumento(editDocumento);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<DocumentoModel>>>> DeleteDocumento(int Id)
        {
            ServiceResponse<List<DocumentoModel>> serviceResponse = await _documentoInterface.DeleteDocumento(Id);
            return Ok(serviceResponse);
        }
    }
}
