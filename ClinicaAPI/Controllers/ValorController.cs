using ClinicaAPI.Models;
using ClinicaAPI.Service.ValorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ValorController : ControllerBase    
    {
        private readonly IValorInterface _valorInterface;
        public ValorController(IValorInterface valorInterface)
        {
            _valorInterface = valorInterface;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ValorModel>>>> GetValor()
        {
            return Ok(await _valorInterface.GetValor());
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ValorModel>>>> CreateValor(ValorModel novoValor)
        {
            
        return Ok(await _valorInterface.CreateValor(novoValor));
        }

        [Authorize]
        [HttpPut("Editar")]
        public async Task<ActionResult<ServiceResponse<List<ValorModel>>>> UpdateValor(ValorModel editValor)
        {
            ServiceResponse<List<ValorModel>> serviceResponse = await _valorInterface.UpdateValor(editValor);
            return Ok(serviceResponse);
        }
       
        
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ValorModel>>>> DeleteValor(int id)
        {
            ServiceResponse<List<ValorModel>> serviceResponse = await _valorInterface.DeleteValor(id);
            return Ok(serviceResponse);
        }
        
    }
}
