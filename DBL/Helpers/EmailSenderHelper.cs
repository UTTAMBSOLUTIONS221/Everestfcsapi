using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace DBL.Helpers
{
    public class EmailSenderHelper
    {
        public bool UttambsolutionssendemailAsync(string to, string subject, string body, bool IsBodyHtml,string EmailServer, string EmailServerEmail,string EmailServerPassword)
        {
            string appServer = "mail.uttambsolutions.com";
            string appEmail = "communications@uttambsolutions.com";
            string appPassword = "K@ribun1";

            if (EmailServer == null || EmailServer == "" || EmailServerEmail == null || EmailServerEmail == "" || EmailServerPassword == null || EmailServerPassword == "")
            {
                appServer = appServer;
                appEmail = appEmail;
                appPassword = appPassword;
            }
            else
            {
                appServer = EmailServer;
                appEmail = EmailServerEmail;
                appPassword = EmailServerPassword;
            }
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(appEmail,"EVEREST FCS");
                mail.IsBodyHtml = IsBodyHtml;
                mail.Subject = subject;
                mail.Body = body;
                mail.To.Add(to);

                using (SmtpClient smtp = new SmtpClient(appServer, 25))
                {
                    NetworkCredential Credentials = new NetworkCredential(appEmail, appPassword);
                    smtp.Credentials = Credentials;
                    try
                    {
                        smtp.Send(mail);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception here
                        return false;
                    }
                }
            }
        }
    }
}
