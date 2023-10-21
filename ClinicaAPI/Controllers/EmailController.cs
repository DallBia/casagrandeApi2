using ClinicaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailInterface _emailInterface;
        public EmailController(IEmailInterface emailInterface)
        {
            _emailInterface = emailInterface;
        }

       
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EmailRequest>>>> EnviarEmailAsync(EmailRequest emailRequest)
        {
            return Ok(await _emailInterface.EnviarEmailAsync(emailRequest));
        }
    }
}
