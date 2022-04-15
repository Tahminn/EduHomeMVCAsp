using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Service.Interfaces;
using Service.Utilities.Helpers;
using System.Threading.Tasks;

namespace Service.Account
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(string emailTo, string userName, string html, string content)
        {
            var emailModel = _config.GetSection("EmailConfig").Get<EmailRequest>();
            var apiKey = emailModel.SecretKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailModel.SenderEmail, emailModel.SenderName);
            var subject = "EduHome Notification";
            var to = new EmailAddress(emailTo, userName);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, html);
            await client.SendEmailAsync(msg);
        }
    }
}
