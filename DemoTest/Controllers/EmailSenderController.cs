using System.Net.Mail;
using DemoTest.Models;

using Microsoft.AspNetCore.Mvc;

namespace DemoTest.Controllers
{
    public class EmailSenderController : Controller
    {
        public IActionResult EmailForm()
        {
            return View();
        }
        public IActionResult SendEmail(MailModel mailModel)
        {
            // Send email
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("nd.demo06@gmail.com");
                mail.To.Add(mailModel.To);
                mail.Subject = mailModel.Subject;
                mail.Body = mailModel.Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("nd.demo06@gmail.com", "kbzn ezmn sela kuut"); // Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ViewBag.Error = e.Message;
                //Console.WriteLine("SMTP Error: " + e.port);
                Console.WriteLine("Message: " + e.Message);
                Console.WriteLine("Inner: " + e.InnerException?.Message);
                return View("EmailForm");
            }
            return RedirectToAction("EmailForm");
        }
    }
}
