using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;        // Doğru SMTP client
using MailKit.Security;
using MimeKit;
using System.Net.Mail;
using WebUI.DataTransferObjects.MailDtos;

namespace WebUI.Areas.Admin.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateMailDto mailDto)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress("World Steak Burger", "your-email@gmail.com"));
            mimeMessage.To.Add(new MailboxAddress(mailDto.Reciever, mailDto.Reciever));
            mimeMessage.Subject = mailDto.Subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = mailDto.Body
            };
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("korayciftciii60@gmail.com", "your-app-password"); // Uygulama şifresi kullanılmalı
                    await client.SendAsync(mimeMessage);
                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    // Log or handle error
                    ModelState.AddModelError("", "An error occurred while sending the email: " + ex.Message);
                    return View(mailDto);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
