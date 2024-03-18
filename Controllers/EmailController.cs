using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using AutoMailSender.Services.EmailService;
using AutoMailSender.Models;


namespace AutoMailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService  _emailService;  

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);

            return Ok();

        }

        [HttpGet]
        public IActionResult ListEmail(EmailDto request)
        {
          

            return Ok();

        }

    }
}
