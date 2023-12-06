using ClinicaAPI.DataContext;
using ClinicaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace ClinicaAPI.Service.ClienteService
{
    public class ClienteService : IClienteInterface
    {
        private readonly ApplicationDbContext _context;
        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<ClienteModel>>> ActivateCliente(int Id)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();
            try
            {
                ClienteModel cliente = _context.Clientes.FirstOrDefault(x => x.Id == Id);


                if (cliente == null)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }
                cliente.Ativo = !cliente.Ativo;

                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Clientes.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> CreateCliente(ClienteModel novoCliente)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();

            try
            {
                if (novoCliente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados...";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }
                _context.Add(novoCliente);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Clientes.ToList();
                if (serviceResponse.Dados.Count == 0)
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


        public async Task<ServiceResponse<ClienteModel>> GetClientebyId(int Id)
        {
            ServiceResponse<ClienteModel> serviceResponse = new ServiceResponse<ClienteModel>();

            try
            {
                ClienteModel cliente = _context.Clientes.FirstOrDefault(x => x.Id == Id);


                if (cliente == null)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = cliente;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> GetCliente()
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();

            try
            {
                serviceResponse.Dados = _context.Clientes.ToList();
                if (serviceResponse.Dados.Count == 0)
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

        public async Task<ServiceResponse<List<ClienteModel>>> UpdateCliente(ClienteModel editCliente)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();
            try
            {
                ClienteModel cliente = _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == editCliente.Id);


                if (cliente == null)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }


                _context.Clientes.Update(editCliente);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Clientes.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ClienteModel>> GetClientebyEmail(string Email)
        {
            ServiceResponse<ClienteModel> serviceResponse = new ServiceResponse<ClienteModel>();

            try
            {
                ClienteModel cliente = _context.Clientes.FirstOrDefault(x => x.Email.ToLower() == Email.ToLower());


                if (cliente == null)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = cliente;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<ClienteModel>>> GetClientebyArea(string Area)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();

            try
            {
                List<ClienteModel> clientes = _context.Clientes
                    .Where(x => x.AreaSession.ToLower().Contains(Area.ToLower()))
                    .ToList();

                if (clientes.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = clientes;
                    serviceResponse.Sucesso = true;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> DeleteCliente(int Id)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();

            try
            {
                ClienteModel cliente = _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == Id);


                if (cliente == null)
                {
                    serviceResponse.Mensagem = "Usuário não encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }


                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Clientes.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> GetClientebyNome(string atr, string par, string ret)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();
            object Retorno;
            try
            {
                if (atr  == "")
                {
                    List<ClienteModel> clientes = _context.Clientes.OrderBy(cliente => cliente.Id).ToList();

                    if (clientes.Count == 0)
                    {
                        serviceResponse.Mensagem = "Nenhum dado encontrado.";
                        serviceResponse.Dados = null;
                        serviceResponse.Sucesso = false;
                    }
                    else
                    {
                        serviceResponse.Dados = clientes;
                        serviceResponse.Sucesso = true;
                        serviceResponse.Mensagem = clientes.Count.ToString();
                        Retorno = clientes;
                    }
                }
                else
                {
                    if (atr == "Nome")
                    {
                        var ret2 = int.Parse(ret);
                        List<ClienteModel> clientes = _context.Clientes
                                        .OrderBy(cliente => cliente.Id)
                                        .Where(x => x.Nome.ToLower().Contains(par.ToLower()) && x.Id > ret2)
                                        .Take(10)
                                        .ToList();
                        if (clientes.Count == 0)
                        {
                            serviceResponse.Mensagem = "Nenhum dado encontrado.";
                            serviceResponse.Dados = null;
                            serviceResponse.Sucesso = false;
                        }
                        else
                        {
                            int? re = clientes.LastOrDefault()?.Id;
                            serviceResponse.Dados = clientes;
                            serviceResponse.Sucesso = true;
                            serviceResponse.Mensagem = clientes.Count.ToString() + "/" + re.ToString();
                            Retorno = clientes;
                        }
                    }
                    if (atr == "Nome da Mãe")
                    {
                        List<ClienteModel> clientes = _context.Clientes
                                        .Where(x => x.Mae.ToLower().Contains(par.ToLower()))
                                        .ToList();
                        if (clientes.Count == 0)
                        {
                            serviceResponse.Mensagem = "Nenhum dado encontrado.";
                            serviceResponse.Dados = null;
                            serviceResponse.Sucesso = false;
                        }
                        else
                        {
                            serviceResponse.Dados = clientes;
                            serviceResponse.Sucesso = true;
                            serviceResponse.Mensagem = clientes.Count.ToString();
                            Retorno = serviceResponse.Mensagem;
                        }
                    }
                    if (atr == "Área")
                    {
                        List<ClienteModel> clientes = _context.Clientes
                                        .Where(x => x.AreaSession.ToLower().Contains(par.ToLower()))
                                        .ToList();
                        if (clientes.Count == 0)
                        {
                            serviceResponse.Mensagem = "Nenhum dado encontrado.";
                            serviceResponse.Dados = null;
                            serviceResponse.Sucesso = false;
                        }
                        else
                        {
                            serviceResponse.Dados = clientes;
                            serviceResponse.Sucesso = true;
                            serviceResponse.Mensagem = clientes.Count.ToString();
                            Retorno = serviceResponse.Mensagem;
                        }
                    }
                    if (atr == "Idade")
                    {
                        var idade = int.Parse(par);
                        
                        DateTime dataReferencia = DateTime.Now.ToLocalTime(); 
                        // Calcula a data mínima com base na idade
                        DateTime dataMinima = dataReferencia.AddYears(-idade - 1);
                        // dataMinima = DateTime.ParseExact(dataMinima.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateOnly dataMinimaOnly = DateOnly.FromDateTime(dataMinima);
                        string DtMin = dataMinimaOnly.ToString();
                        string[] DtMin2 = DtMin.Split('/');
                        DtMin = DtMin2[2] + "-" + DtMin2[1] + "-" + DtMin2[0];
                        dataMinimaOnly = DateOnly.Parse(DtMin);
                        // Calcula a data máxima com base na idade
                        DateTime dataMaxima = dataReferencia.AddYears(-idade);
                        // dataMaxima = DateTime.ParseExact(dataMaxima.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture); 
                        DateOnly dataMaximaOnly = DateOnly.FromDateTime(dataMaxima);
                        string DtMax = dataMaximaOnly.ToString();
                        string[] DtMax2 = DtMax.Split('/');
                        DtMax = DtMax2[2] + "-" + DtMax2[1] + "-" + DtMax2[0];
                        dataMaximaOnly = DateOnly.Parse(DtMax);



                        List<ClienteModel> clientes2 = _context.Clientes.ToList();
                        List<ClienteModel> clientes = new List<ClienteModel>();

                        foreach (var i in clientes2)
                        {
                            DateOnly Dt = DateOnly.Parse(i.DtNascim.ToString());
                            if (Dt >= dataMinimaOnly && Dt < dataMaximaOnly)
                            {
                                clientes.Add(i);
                            }
                        }
                        if (clientes.Count == 0)
                        {
                            serviceResponse.Mensagem = "Nenhum dado encontrado.";
                            serviceResponse.Dados = null;
                            serviceResponse.Sucesso = false;
                        }
                        else
                        {
                            serviceResponse.Dados = clientes;
                            serviceResponse.Sucesso = true;
                            serviceResponse.Mensagem = clientes.Count.ToString();
                            Retorno = serviceResponse.Mensagem;
                        }
                    }
                }

                
                                
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            /*if (serviceResponse.Dados.Count != 0)
            {
                foreach (var i in serviceResponse.Dados)
                {

                    
                    i.Cpf = "";
                    i.MaeEmail = "";
                    i.PaiEmail = "";
                    i.RespFinanc = 0;
                    i.PaiIdentidade = "";
                    i.PaiEndereco = "";
                    i.PaiCpf = "";
                    i.MaeCpf = "";
                    i.Endereco = "";
                    i.Identidade = "";
                    i.MaeEndereco = "";
                }
            }*/

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TipoModel>>> GetClientebyAgenda()
        {
            ServiceResponse<List<TipoModel>> serviceResponse = new ServiceResponse<List<TipoModel>>();
            var DadosList = new List<TipoModel>();
            try
            {
                var Lista = _context.Clientes
                    .OrderBy (x => x.Nome)
                    .ToList();
                foreach (var T in Lista)
                {
                    TipoModel novoItem = new TipoModel
                    {
                        id = T.Id,
                        nome = T.Nome
                    };

                    DadosList.Add(novoItem);
                }
                    serviceResponse.Dados = DadosList.ToList();
                    serviceResponse.Mensagem = "Carregado com sucesso.";
                    serviceResponse.Sucesso = true;
                
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
