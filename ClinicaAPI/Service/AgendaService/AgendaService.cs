using ClinicaAPI.DataContext;
using ClinicaAPI.Enums;
using ClinicaAPI.Models;
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

    public async Task<ServiceResponse<List<AgendaModel>>> CreateAgenda(AgendaModel novaAgenda)
    {
        ServiceResponse<List<AgendaModel>> serviceResponse = new ServiceResponse<List<AgendaModel>>();

        try
        {
            _context.Agendas.Add(novaAgenda);
            await _context.SaveChangesAsync();
            var dia = novaAgenda.dia;
            List<AgendaModel> agendas = await _context.Agendas
                .Where(a => a.dia == dia)
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
             agendaExistente.dia = agendaAtualizada.dia;
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
        try { 
            AgendaModel agendaExistente = _context.Agendas
                .FirstOrDefault(x => x.dia == testAgenda.dia
                                 && x.sala == testAgenda.sala
                                 && x.unidade == testAgenda.unidade);

            if (agendaExistente != null)
            {

                agendaExistente.id = testAgenda.id;
                agendaExistente.idCliente = testAgenda.idCliente;
                agendaExistente.idFuncAlt = testAgenda.idFuncAlt;
                agendaExistente.dtAlt = testAgenda.dtAlt;
                agendaExistente.horario = testAgenda.horario;
                agendaExistente.sala = testAgenda.sala;
                agendaExistente.unidade = testAgenda.unidade;
                agendaExistente.repeticao = testAgenda.repeticao;
                agendaExistente.subtitulo = testAgenda.subtitulo;
                agendaExistente.status = testAgenda.status;
                agendaExistente.historico = testAgenda.historico;
                agendaExistente.obs = testAgenda.obs;


                _context.Agendas.Update(agendaExistente);
                serviceResponse.Mensagem = "Atualizado.";
            }
            else
            {
                // Se não existir, criar um novo registro
                AgendaModel novoRegistro = new AgendaModel
                {
                id = testAgenda.id,
                idCliente = testAgenda.idCliente,
                idFuncAlt = testAgenda.idFuncAlt,
                dtAlt = testAgenda.dtAlt,
                horario = testAgenda.horario,
                sala = testAgenda.sala,
                unidade = testAgenda.unidade,
                repeticao = testAgenda.repeticao,
                subtitulo = testAgenda.subtitulo,
                status = testAgenda.status,
                historico = testAgenda.historico,
                obs = testAgenda.obs
            };

                _context.Agendas.Add(novoRegistro);
                serviceResponse.Mensagem = "Criado.";
            }

            await _context.SaveChangesAsync();            
            serviceResponse.Sucesso = true;
        }
        catch (Exception ex)
        {
            // Tratar exceções, se necessário
            serviceResponse.Mensagem = "Erro ao realizar operação: " + ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
}