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
                .Where(a => a.Dia == dia)
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
            var agendaExistente = await _context.Agendas.FindAsync(id);

            if (agendaExistente == null)
            {
                serviceResponse.Mensagem = "Agenda não encontrada.";
                return serviceResponse;
            }

            // Atualize os campos necessários da agenda existente

            agendaExistente.IdCliente = agendaAtualizada.IdCliente;
            agendaExistente.IdFuncAlt = agendaAtualizada.IdFuncAlt;
            agendaExistente.DtAlt= DateTime.Now.ToLocalTime();
            agendaExistente.Horario = agendaAtualizada.Horario;
            agendaExistente.Sala = agendaAtualizada.Sala;
            agendaExistente.Unidade = agendaAtualizada.Unidade;
            agendaExistente.Dia = agendaAtualizada.Dia;
            agendaExistente.Repeticao = agendaAtualizada.Repeticao;
            agendaExistente.Subtitulo = agendaAtualizada.Subtitulo;
            agendaExistente.Status = agendaAtualizada.Status;
            agendaExistente.Historico = agendaAtualizada.Historico;
            agendaExistente.Obs = agendaAtualizada.Obs; 


    // ... Atualize outras propriedades conforme necessário

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