using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

public class SmtpSettings
{
    public string Server { get; set; }
    public int Port { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string message);
}

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
        emailMessage.To.Add(new MailboxAddress("", toEmail));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart("plain") { Text = message };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
