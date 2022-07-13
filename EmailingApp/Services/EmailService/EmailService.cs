using EmailingApp.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailingApp.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void SendEmail(EmailDto emailModel)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailModel.From));
            email.To.Add(MailboxAddress.Parse(emailModel.To));
            email.Subject = emailModel.Subject;


            string FilePath = @"C:\Users\Kazan\Desktop\C#\Test Projects\EmailingApp\EmailingApp\Others\Templates\template.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = MailText };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(configuration.GetSection("EmailConfig:Host").Value, configuration.GetValue<int>("EmailConfig:Port"), MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(configuration.GetSection("EmailConfig:Username").Value, configuration.GetSection("EmailConfig:Password").Value);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
