using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;

namespace AutoMailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("edwin.shields18@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("edwin.shields18@ethereal.email"));
            email.Subject = "Test Email Subject";
            email.Body= new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("edwin.shields18@ethereal.email", "e1k2xtEueZfsAUhUjt");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();

        }
    }
}
