using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using EmailingApp.Services.EmailService;
using EmailingApp.Models;

namespace EmailingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail(EmailDto emailDto)
        {
            emailService.SendEmail(emailDto);

            return Ok();
        }
    }
}
