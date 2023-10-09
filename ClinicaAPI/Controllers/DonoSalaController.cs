using ClinicaAPI.Models;
using ClinicaAPI.Service.DonoSalaService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonoSalaController : ControllerBase
    {
        private readonly IDonoSalaInterface _donoSalaInterface;
        public DonoSalaController(IDonoSalaInterface donoSalaInterface)
        {
            _donoSalaInterface = donoSalaInterface;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DonoSalaModel>>>> GetDonoSala()
        {
            return Ok(await _donoSalaInterface.GetDonoSala());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<DonoSalaModel>>>> CreateDonoSala(DonoSalaModel novoDonoSala)
        {
            return Ok(await _donoSalaInterface.CreateDonoSala(novoDonoSala));
        }

        [HttpPut("Editar")]
        public async Task<ActionResult<ServiceResponse<List<DonoSalaModel>>>> UpdateDonoSala(DonoSalaModel editDonoSala)
        {
            ServiceResponse<List<DonoSalaModel>> serviceResponse = await _donoSalaInterface.UpdateDonoSala(editDonoSala);
            return Ok(serviceResponse);
        }
    }
}
