using System.Net.Mail;

namespace authApi.Services
{
    public class EmailService
    {
        public static void SendMail(string mailAddressTo, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("printfusionpage@gmail.com");
            mail.To.Add(mailAddressTo);
            mail.Subject = subject;
            mail.Body = body;
            smtpServer.Credentials = new System.Net.NetworkCredential("printfusionpage@gmail.com", "huci yvoe bmqw thaz");

            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }
    }
}
