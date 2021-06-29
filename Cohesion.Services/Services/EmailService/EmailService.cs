using Cohesion.Base.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Linq;

namespace Cohesion.Services.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private EmailSettings emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            emailSettings = options.Value;
        }

        public void SendMail()
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(emailSettings.SmtpFromAddress.FirstOrDefault(), emailSettings.SmtpFromAddress.FirstOrDefault()));
            message.To.Add(new MailboxAddress("Nithin", "def@gmail.com"));
            message.Subject = "Service request Completed";
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "<p>Your service request has been completed</p><span>Thank you</span>" };
            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(emailSettings.SmtpServer, emailSettings.SmtpPort, false);
                emailClient.Authenticate(emailSettings.SmtpUsername, emailSettings.SmtpPassword);
                emailClient.Send(message);
                emailClient.Disconnect(true);
            }
        }
    }
}
