using ClinicaAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAgendaInterface
{
    Task<ServiceResponse<List<AgendaModel>>> GetAgendaByDate(DateOnly dia);
    Task<ServiceResponse<AgendaModel>> CreateAgenda(AgendaModel novaAgenda);
    Task<ServiceResponse<AgendaModel>> UpdateAgenda(int id, AgendaModel editAgenda);
    Task<ServiceResponse<AgendaModel>> ValidAgenda(AgendaModel testAgenda);
}