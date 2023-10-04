using ClinicaAPI.DataContext;
using ClinicaAPI.Enums;
using ClinicaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AgendaService : IAgendaInterface
{
    private readonly ApplicationDbContext _context;

    public AgendaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<AgendaModel>>> GetAgendaByDate(DateOnly dia)
    {
        ServiceResponse<List<AgendaModel>> serviceResponse = new ServiceResponse<List<AgendaModel>>();

        try
        {
            // Consulta no banco de dados para encontrar agendas na data especificada (dia).
            List<AgendaModel> agendas = await _context.Agendas
                .Where(a => a.dia == dia)
                .ToListAsync();

            serviceResponse.Dados = agendas;

            if (agendas.Count == 0)
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

    public async Task<ServiceResponse<AgendaModel>> CreateAgenda(AgendaModel novaAgenda)
    {
        ServiceResponse<AgendaModel> serviceResponse = new ServiceResponse<AgendaModel>();

        try
        {
            _context.Agendas.Add(novaAgenda);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = novaAgenda;
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }


   public async Task<ServiceResponse<AgendaModel>> UpdateAgenda(int id, AgendaModel agendaAtualizada)
     {
         ServiceResponse<AgendaModel> serviceResponse = new ServiceResponse<AgendaModel>();

         try
         {
             /*var agendaExistente = await _context.Agendas.FindAsync(id);*/
            var agendaExistente = _context.Agendas.AsNoTracking().FirstOrDefault(x => x.id == agendaAtualizada.id);

             if (agendaExistente == null)
             {
                 serviceResponse.Mensagem = "Agenda não encontrada.";
                 return serviceResponse;
             }

             agendaExistente.idCliente = agendaAtualizada.idCliente;
             agendaExistente.idFuncAlt = agendaAtualizada.idFuncAlt;
             agendaExistente.dtAlt= DateTime.UtcNow;
             agendaExistente.horario = agendaAtualizada.horario;
             agendaExistente.sala = agendaAtualizada.sala;
             agendaExistente.unidade = agendaAtualizada.unidade;
             agendaExistente.dia = agendaAtualizada.dia;
             agendaExistente.repeticao = agendaAtualizada.repeticao;
             agendaExistente.subtitulo = agendaAtualizada.subtitulo;
             agendaExistente.status = agendaAtualizada.status;
             agendaExistente.historico = agendaAtualizada.historico;
             agendaExistente.obs = agendaAtualizada.obs; 

     _context.Agendas.Update(agendaExistente);
             await _context.SaveChangesAsync();
             serviceResponse.Dados = agendaExistente;
         }
         catch (Exception ex)
         {
             serviceResponse.Mensagem = ex.Message;
             serviceResponse.Sucesso = false;
         }

         return serviceResponse;
     }

}