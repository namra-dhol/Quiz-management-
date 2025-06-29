using Microsoft.AspNetCore.Mvc;
using DemoTest.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
namespace DemoTest.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send(MailRequest mailRequest)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("You", "nd.demo06@gmail.com"));
                message.To.Add(new MailboxAddress("You", "nd.demo06@gmail.com"));
                message.Subject = mailRequest.Subject;

                message.Body = new TextPart("plain")
                {
                    Text = mailRequest.Body
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("nd.demo06@gmail.com", "kbzn ezmn sela kuut");
                    client.Send(message);
                    client.Disconnect(true);
                }

                ViewBag.Message = "Email sent!";
                return View("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return View("Error");
            }
        }
    }
}