using ClinicaAPI.Models;
using ClinicaAPI.Service.PerfilService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilInterface _perfilInterface;
        public PerfilController(IPerfilInterface perfilInterface)
        {
            _perfilInterface = perfilInterface;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PerfilModel>>>> GetPerfil()
        {
            return Ok(await _perfilInterface.GetPerfil());
        }

        [Authorize]
        [HttpPut("Editar")]
        public async Task<ActionResult<ServiceResponse<List<PerfilModel>>>> UpdatePerfil(PerfilModel editPerfil)
        {
            ServiceResponse<List<PerfilModel>> serviceResponse = await _perfilInterface.UpdatePerfil(editPerfil);
            return Ok(serviceResponse);
        }
    }
}
