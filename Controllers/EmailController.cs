using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using AutoMailSender.Services.EmailService;
using AutoMailSender.Models;
using AutoMailSender.Data;
using Microsoft.EntityFrameworkCore;


namespace AutoMailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
       
        private readonly DataContext _context;
        public EmailController(DataContext context)
        {
            _context = context;
        }
        


        [HttpPost]
        public async Task<ActionResult<List<EmailDto>>>AddEmail(EmailDto request)
        {
            _context.EmailDto.Add(request);
            await _context.SaveChangesAsync();

            return Ok(await _context.EmailDto.ToListAsync());

        }

        [HttpGet]
        public async Task<ActionResult<List<EmailDto>>> Get()
        {
          

            return Ok(await _context.EmailDto.ToListAsync());

        }

    }
}
