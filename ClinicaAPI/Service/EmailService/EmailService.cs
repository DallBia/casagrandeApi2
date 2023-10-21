using ClinicaAPI.Models;
using MailKit.Net.Smtp;
using MimeKit;


namespace ClinicaAPI.Service.EmailService
{
    public class EmailService : IEmailInterface
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ServiceResponse<List<EmailRequest>>> EnviarEmailAsync(EmailRequest emailRequest)
        {
            ServiceResponse<EmailRequest> serviceResponse = new ServiceResponse<EmailRequest>();
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
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            /*
            try
            {


                var smtpClient = new SmtpClient(_configuration["EmailConfig:SmtpServer"])
                {
                    Port = int.Parse(_configuration["EmailConfig:SmtpPort"]),
                    Credentials = new NetworkCredential(_configuration["EmailConfig:Username"], _configuration["EmailConfig:Password"]),
                    EnableSsl = true,
                };

                var mensagem = new MailMessage
                {
                    From = new MailAddress(_configuration["EmailConfig:FromEmail"]),
                    Subject = emailRequest.Assunto,
                    Body = emailRequest.Corpo,
                    IsBodyHtml = true,
                };

                mensagem.To.Add(emailRequest.Destinatario);

                await smtpClient.SendMailAsync(mensagem);
                serviceResponse.Mensagem = "mensagem enviada";
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            */
            return (ServiceResponse<List<EmailRequest>>)serviceResponse;
        }

      

    }
}
