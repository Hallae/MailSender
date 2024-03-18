using AutoMailSender.Models;

namespace AutoMailSender.Services.EmailService
{
    public interface IEmailService
    {
        
        void SendEmail(EmailDto request);
    }


}
