using ClinicaAPI.DataContext;
using ClinicaAPI.Enums;
using ClinicaAPI.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                .Where(a => a.diaI <= dia && a.diaF >= dia)
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

    public async Task<ServiceResponse<List<AgendaModel>>> CreateAgenda(AgendaModel novaAgenda)
    {
        ServiceResponse<List<AgendaModel>> serviceResponse = new ServiceResponse<List<AgendaModel>>();

        try
        {
            _context.Agendas.Add(novaAgenda);
            await _context.SaveChangesAsync();
            var diaI = novaAgenda.diaI;
            var diaF = novaAgenda.diaF;
            List<AgendaModel> agendas = await _context.Agendas
                .Where(a => a.diaI <= diaI && a.diaF >= diaF)
                .ToListAsync();
            serviceResponse.Dados = agendas;
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
             agendaExistente.nome = agendaAtualizada.nome;
             agendaExistente.dtAlt= DateTime.UtcNow;
             agendaExistente.horario = agendaAtualizada.horario;
             agendaExistente.sala = agendaAtualizada.sala;
             agendaExistente.unidade = agendaAtualizada.unidade;
             agendaExistente.diaI = agendaAtualizada.diaI;
             agendaExistente.diaF = agendaAtualizada.diaF;
             agendaExistente.repeticao = agendaAtualizada.repeticao;
             agendaExistente.subtitulo = agendaAtualizada.subtitulo;
             agendaExistente.status = agendaAtualizada.status;
             agendaExistente.historico = agendaAtualizada.historico;
             agendaExistente.obs = agendaAtualizada.obs;
             agendaExistente.valor = agendaAtualizada.valor;

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

    public async Task<ServiceResponse<AgendaModel>> ValidAgenda(AgendaModel testAgenda)
    {
        ServiceResponse<AgendaModel> serviceResponse = new ServiceResponse<AgendaModel>();
        if (testAgenda.nome != "")
        {
            try
            {
                AgendaModel agendaExistente = _context.Agendas
                .FirstOrDefault(x => x.diaI <= testAgenda.diaI
                                    && x.diaF >= testAgenda.diaF
                                    && x.nome == testAgenda.nome
                                    && x.horario == testAgenda.horario);

                if (agendaExistente != null)
                {
                    serviceResponse.Dados = agendaExistente;
                    serviceResponse.Mensagem = "Encontrado.";
                    serviceResponse.Sucesso = true;
                }
                else
                {
                    serviceResponse.Dados = agendaExistente;
                    serviceResponse.Mensagem = "Não Encontrado.";
                    serviceResponse.Sucesso = true;
                };

            }
            catch (Exception ex)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Erro ao realizar operação: " + ex.Message;
                serviceResponse.Sucesso = false;
            }
        }
        else
        {
            try
            {
                AgendaModel agendaExistente = _context.Agendas
                .FirstOrDefault(x => x.diaI <= testAgenda.diaI
                                    && x.diaF >= testAgenda.diaF
                                    && x.sala == testAgenda.sala
                                    && x.unidade == testAgenda.unidade
                                    && x.horario == testAgenda.horario);

                if (agendaExistente != null)
                {
                    serviceResponse.Dados = agendaExistente;
                    serviceResponse.Mensagem = "Indisponível.";
                    serviceResponse.Sucesso = true;
                }
                else
                {
                    serviceResponse.Dados = agendaExistente;
                    serviceResponse.Mensagem = "Disponível.";
                    serviceResponse.Sucesso = true;
                };

            }
            catch (Exception ex)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Erro ao realizar operação: " + ex.Message;
                serviceResponse.Sucesso = false;
            }
        }
        

        return serviceResponse;
    }
}