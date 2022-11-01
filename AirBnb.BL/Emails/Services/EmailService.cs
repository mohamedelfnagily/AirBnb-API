using AirBnb.BL.Emails.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Emails.Services
{
    public class EmailService:IEmailService
    {
        private readonly EmailSettings _settings;
        public EmailService(IOptions<EmailSettings> opt)
        {
            _settings = opt.Value;
        }


        //Here is the welcoming email that will be sent after regestiration of a user
        public async Task SendEmailAsync(string mailTo, string subject, string body)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_settings.Email),
                Subject = subject,

            };
            //Here is the reciever
            email.To.Add(MailboxAddress.Parse(mailTo));
            //Here is the email structure
            var builder = new BodyBuilder();
            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_settings.DisplayName, _settings.Email));
            using var smtp = new SmtpClient();
            smtp.Connect(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_settings.Email, _settings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
        //Forget password Email implementation
        public async Task ForgetPasswordEmailAsync(string mailTo, string subject)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_settings.Email),
                Subject = subject,

            };
            //Here is the reciever
            email.To.Add(MailboxAddress.Parse(mailTo));
            //Here is the email structure
            var builder = new BodyBuilder();
            builder.HtmlBody = "Please Click here <a href=\"https://localhost:4200/ForgetPassword\">Forget Password</a>";
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_settings.DisplayName, _settings.Email));
            using var smtp = new SmtpClient();
            smtp.Connect(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_settings.Email, _settings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
