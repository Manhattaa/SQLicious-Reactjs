using Microsoft.Extensions.Options;
using MimeKit;
using SQLicious.Server.Options;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace SQLicious.Server.Helpers
{
    public interface IEmailSender
    {
        public Task<EmailResult> SendEmailAsync(string email, string subject, string htmlmessage);
    }


    public class EmailResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class EmailSender : IEmailSender
    {
        // Injections of Email Configuration 
        private readonly MailKitSettings _emailSettings;

        public EmailSender(IOptions<MailKitSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<EmailResult> SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Configure email instance
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Sender));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = htmlMessage
            };

            // Connects,
            // Authenticates,
            // Sends mail
            // Sends back result
            using (SmtpClient client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, useSsl: false);
                    await client.AuthenticateAsync(_emailSettings.Sender, _emailSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);

                    return new EmailResult { Success = true };
                }
                catch (Exception ex)
                {
                    return new EmailResult { Success = false, ErrorMessage = ex.Message };
                }
            }
        }

    }
}

