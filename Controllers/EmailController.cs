using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using AutoMailSender.Services.EmailService;
using AutoMailSender.Models;
using AutoMailSender.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace AutoMailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        // add and then enables save changes to database.
        private readonly DataContext _context;
       
        public EmailController(DataContext context)
        {
        
            _context = context;
        }



        [HttpPost]
        public async Task<ActionResult<List<EmailDto>>> AddEmail(EmailDto request)
        {
           
            HttpResponseMessage response = await MakeHttpPostRequest(request); 

            // Capture the status code from the response
            int statusCode = (int)response.StatusCode;

            // Update the request object with the status code
            request.StatusCode = statusCode;

            // Add and save the updated request object to the database
            _context.EmailDto.Add(request);
            await _context.SaveChangesAsync();

            return Ok(await _context.EmailDto.ToListAsync());
        }




        private async Task<HttpResponseMessage> MakeHttpPostRequest(EmailDto emailDto)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7201/api/Email");
           

          

            return await client.SendAsync(request);
        }






        [HttpGet]
        public async Task<ActionResult<List<EmailDto>>> Get()
        {
            // add and then enables save changes to database.

            return Ok(await _context.EmailDto.ToListAsync());

        }


      


    }
}
