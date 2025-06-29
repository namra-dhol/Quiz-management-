using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using DemoTest.Models;
//using DemoTest.Models.MessageModel;
namespace DemoTest.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult MessageDemo() { return View(); }



        [HttpPost]
        public ActionResult SendMessage(MessageModel message)
        {
            if (ModelState.IsValid)
            {
                // Send Email
                SendEmail(message);

                // Optionally, you can show a success message after sending the email
                ViewBag.Message = "Your message has been sent successfully!";
            }

            return View("Contact");
        }

        public void SendEmail(MessageModel message)
        {
            var fromAddress = new MailAddress("nd.demo06@gmail.com", "Your Website");
            var toAddress = new MailAddress("dholnamra20@gmail.com", "Receiver");
            const string fromPassword = "yourAppPassword";  // Use the app password for Gmail
            string subject = "New Message from Website";
            string body = $"Name: {message.Name}\nEmail: {message.Email}\nPhone: {message.Phone}\nMessage: {message.MessageContent}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var mailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(mailMessage);
            }
        }


    }
}


