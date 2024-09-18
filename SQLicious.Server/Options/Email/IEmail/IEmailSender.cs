namespace SQLicious.Server.Options.Email.IEmail
{
    public interface IEmailSender
    {
        public Task<EmailResult> SendEmailAsync(string email, string subject, string body);
    }
}
