using ClinicaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AgendaController : ControllerBase
{
    private readonly IAgendaInterface _agendaInterface;

    public AgendaController(IAgendaInterface agendaInterface)
    {
        _agendaInterface = agendaInterface;
    }

    [HttpGet("AgendaByDate/{dia}")]
    public async Task<ActionResult<ServiceResponse<List<AgendaModel>>>> GetAgendaByDate(string dia)
    {
        if (!DateTime.TryParseExact(dia, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            return BadRequest("Formato de data inválido. Use o formato yyyy-MM-dd.");
        }

        DateOnly dateOnly = DateOnly.FromDateTime(parsedDate);

        ServiceResponse<List<AgendaModel>> serviceResponse = await _agendaInterface.GetAgendaByDate(dateOnly);
        return Ok(serviceResponse);
    }

    [HttpPost("CreateAgenda")]
    public async Task<ActionResult<ServiceResponse<AgendaModel>>> CreateAgenda([FromBody] AgendaModel novaAgenda)
    {
        ServiceResponse<AgendaModel> serviceResponse = await _agendaInterface.CreateAgenda(novaAgenda);
        return Ok(serviceResponse);
    }

    [HttpPut("UpdateAgenda/{id}")]
    public async Task<ActionResult<ServiceResponse<AgendaModel>>> UpdateAgenda(int id, [FromBody] AgendaModel agendaAtualizada)
    {
        ServiceResponse<AgendaModel> serviceResponse = await _agendaInterface.UpdateAgenda(id, agendaAtualizada);
        return Ok(serviceResponse);
    }
}