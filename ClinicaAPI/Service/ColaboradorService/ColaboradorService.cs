using ClinicaAPI.Controllers;
using ClinicaAPI.DataContext;
using ClinicaAPI.Models;
using ClinicaAPI.Service.EmailService;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace ClinicaAPI.Service.ColaboradorService
{
    public class ColaboradorService : IColaboradorInterface

    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public ColaboradorService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        





        public async Task<ServiceResponse<List<UserModel>>> CreateColaborador(UserModel novoColaborador)
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();

            try
            {
                if (novoColaborador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados...";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }
                _context.Add(novoColaborador);
                await _context.SaveChangesAsync();
                EmailRequest emailRequest = new EmailRequest();
                emailRequest.Destinatario = novoColaborador.email;
                emailRequest.Assunto = "Cadastro de usuário";
                emailRequest.Corpo = "<p><strong><span style='color: blue; font-size: 24px;'> Olá, "
   + novoColaborador.nome + "!</span></strong></p>"
   + "<p>Você acaba de ser cadastrado como funcionário da <b>Clínica Casagrande. </b></p>"
   + "<p>Seu login é o e-mail <strong><span style='color: blue; font-size: 18px;'>"
   + novoColaborador.email + ".</span></strong></p>"
   + "<p>Sua senha <b>provisória</b> é <strong><span style='color: blue; font-size: 18px;'>"
   + novoColaborador.senhaHash + "</span></strong></p>"
   + "<p>Acesse o link do <a href='http://35.232.35.159'>aplicativo</a> e <b>altere a senha. </b>"
    + "Coloque uma senha que seja fácil para você decorar.</p>"
    + "<p>Para sua comodidade, salve o link na sua guia de marcadores favoritos.</p>"
    + "Depois, vá na guia <b>Cadastro de Equipe</b>, selecione seu nome através do filtro e "
    + "complete as informações do seu cadastro.";
                //ServiceResponse<List<EmailRequest>> emailResponse = await _emailService.EnviarEmailAsync(emailRequest);
                try
                {
                    var email = new MimeMessage();


                    email.From.Add(MailboxAddress.Parse(_configuration["EmailConfig:FromEmail"]));
                    email.Subject = emailRequest.Assunto;
                    email.Body = new TextPart("html")
                    {
                        Text = emailRequest.Corpo
                    };
                    using var smtp = new SmtpClient();

                    smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    var usuario = _configuration["EmailConfig:FromEmail"];
                    //var usuario = "966741631742-sjsrqt2f8251f7qc0b48i2qcnrsi7tk2.apps.googleusercontent.com";
                    var hash = "sknr xkhy mjzf twul";
                    //var hash = _configuration["EmailConfig:Password"];
                    email.To.Add(MailboxAddress.Parse(emailRequest.Destinatario));
                    smtp.Authenticate(usuario, hash);
                    smtp.Send(email);
                    smtp.Disconnect(true);
                    serviceResponse.Mensagem = "mensagem enviada";
                    serviceResponse.Sucesso = true;
                }
                catch
                {
                    serviceResponse.Mensagem = "erro no envio do e-mail";
                    serviceResponse.Sucesso = false;
                }
                serviceResponse.Dados = _context.Users.ToList();
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

        Task<ServiceResponse<List<UserModel>>> IColaboradorInterface.GetColaborador()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<UserModel>>> UpdateColaborador(UserModel editUser)
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();
            try
            {
                UserModel User = _context.Users.AsNoTracking().FirstOrDefault(x => x.id == editUser.id);


                if (User == null)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    if (editUser.nome != "")
                    {
                        User.nome = editUser.nome;
                    }
                    if (editUser.celular != "")
                    {
                        User.celular = editUser.celular;
                    }
                    if (editUser.ativo != null)
                    {
                        User.ativo = editUser.ativo;
                    }
                    if (editUser.cpf != "")
                    {
                        User.cpf = editUser.cpf;
                    }
                    if (editUser.foto != "")
                    {
                        User.foto = editUser.foto;
                    }
                    if (editUser.idPerfil != 0)
                    {
                        User.idPerfil = editUser.idPerfil;
                    }
                    DateOnly dataMinima = new DateOnly(1900, 1, 1);
                    if (editUser.dtDeslig != dataMinima)
                    {
                        User.dtDeslig = editUser.dtDeslig;
                    }
                    if (editUser.dtNasc != dataMinima)
                    {
                        User.dtNasc = editUser.dtNasc;
                    }
                    if (editUser.dtAdmis != dataMinima)
                    {
                        User.dtAdmis = editUser.dtAdmis;
                    }
                    if (editUser.email != "")
                    {
                        User.email = editUser.email;
                    }
                    if (editUser.endereco != "")
                    {
                        User.endereco = editUser.endereco;
                    }
                    if (editUser.rg != "")
                    {
                        User.rg = editUser.rg;
                    }
                    if (editUser.telFixo != "")
                    {
                        User.telFixo = editUser.telFixo;
                    }
                }
                _context.Users.Update(User);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Users.ToList();
                foreach (var user in serviceResponse.Dados)
                {
                    user.senhaHash = "secreta";
                }
                serviceResponse.Dados = _context.Users.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        


        /*
         public async Task<ServiceResponse<UserModel>> AltSenha(int id, string novaSenha)
        {
            ServiceResponse<UserModel> serviceResponse = new ServiceResponse<UserModel>();
            try
            {
                UserModel User = _context.Users.AsNoTracking().FirstOrDefault(x => x.id == id);


                if (User == null)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    if (novaSenha != "")
                    {
                        User.senhaHash = novaSenha;
                    }
                    
                    if (User.dtDeslig.ToString() == "1900-01-01")
                    {
                        User.dtDeslig = null;
                        User.ativo = true;
                    }
                     
                }
                _context.Users.Update(User);
                await _context.SaveChangesAsync();
                User.senhaHash = "secreta";
                serviceResponse.Dados = User;
                
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
        */
    }
    
}
