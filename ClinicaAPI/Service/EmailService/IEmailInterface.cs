using ClinicaAPI.Models;

public interface IEmailInterface
{
    Task<ServiceResponse<List<EmailRequest>>> EnviarEmailAsync(EmailRequest emailRequest);
}
