using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace AmdarisAssignment10;

public static class EmailSender
{
    private static Config? _config;

    static EmailSender()
    {
        var configJson = File.ReadAllText("appsettings.json");
        _config = JsonSerializer.Deserialize<Config>(configJson);
    }

    public static void SendEmail(string toAddress)
    {
        try
        {
            using var smtpClient = new SmtpClient(_config.SmtpServer);
            using var mailMessage = new MailMessage();
            smtpClient.Port = _config.Port;
            smtpClient.Credentials = new NetworkCredential(_config.SenderEmail, _config.SenderPassword);
            smtpClient.EnableSsl = true;

            mailMessage.From = new MailAddress(_config.SenderEmail);
            mailMessage.To.Add(toAddress);
            mailMessage.Subject = "Thanks for subscription";
            mailMessage.Body = "Thank you for subscribing to our newsletter. We're thrilled to have " +
                               "you join our community! Get ready to stay up-to-date with the latest " +
                               "news, tips, and exclusive offers delivered straight to your inbox. ";

            smtpClient.Send(mailMessage);
        }
        catch (SmtpException ex)
        {
            Console.WriteLine($"Error while sending email: {ex.Message}");
        }
    }
}