using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace ProjectBackend.Services
{
    public class EmailService
    {
        
        public static void SendVerificationMail(string mailAddressTo,int randomCode, IConfiguration configuration)
        {
            string subject = $"Verify you Email: {randomCode}";
            string body = $"Thank you for registering to PrintFusion, after you verify your email all of the websites features are unlocked.\nYour verification code is: {randomCode}";

            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            string emailAddress = configuration["EmailSettings:EmailAddress"];
            string emailSecret = configuration["EmailSettings:EmailSecret"];
            mail.From = new MailAddress(emailAddress);
            mail.To.Add(mailAddressTo);
            mail.Subject = subject;
            mail.Body = body;
            smtpServer.Credentials = new System.Net.NetworkCredential(emailAddress, emailSecret);
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }
        
        public static void SendConfirmationMail(string mailAddressTo, string subject, string body, IConfiguration configuration)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            string emailAddress = configuration["EmailSettings:EmailAddress"];
            string emailSecret = configuration["EmailSettings:EmailSecret"];
            mail.From = new MailAddress(emailAddress);
            mail.To.Add(mailAddressTo);
            mail.Subject = subject;
            mail.Body = body;
            smtpServer.Credentials = new System.Net.NetworkCredential(emailAddress, emailSecret);
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }
    }
}
