using EmailingApp.Models;

namespace EmailingApp.Services.EmailService
{
    public interface IEmailService
    {
        public void SendEmail(EmailDto email);
    }
}
