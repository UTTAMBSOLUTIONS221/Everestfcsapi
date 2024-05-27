using DBL.Entities;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace DBL.Helpers
{
    public class EmailSenderHelper
    {
        private readonly BL bl;
        public EmailSenderHelper(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }
        public async Task<bool> UttambsolutionssendemailAsync(long TenantId,string to, string subject, string body, bool IsBodyHtml,string EmailServer, string EmailServerEmail,string EmailServerPassword)
        {
            //string appServer = "mail.uttambsolutions.com";
            //string appEmail = "communications@uttambsolutions.com";
            //string appPassword = "K@ribun1";

            string appServer = "smtp.gmail.com";
            string appEmail = "uttambsolutions3@gmail.com";
            string appPassword = "fhuq etym dxel pmzw";



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
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(appEmail,"EVEREST FCS");
                mail.IsBodyHtml = IsBodyHtml;
                mail.Subject = subject;
                mail.Body = body;
                mail.To.Add(to);
                //log Email Messages
                EmailLogs Logs = new EmailLogs
                {
                    EmailLogId = 0,
                    TenantId = TenantId,
                    EmailAddress = to,
                    EmailSubject = subject,
                    EmailMessage = body,
                    IsEmailSent = false,
                    DateTimeSent = DateTime.Now,
                    Datecreated = DateTime.Now,
                };
               var resp = await bl.LogEmailMessage(Logs);

                using (SmtpClient smtp = new SmtpClient(appServer, 587))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(appEmail, appPassword);
                    try
                    {
                        smtp.Send(mail);
                        //Update Email is sent 
                        //log Email Messages
                        EmailLogs Logs1 = new EmailLogs
                        {
                            EmailLogId =Convert.ToInt64(resp.Data1),
                            TenantId = TenantId,
                            EmailAddress = to,
                            EmailSubject = subject,
                            EmailMessage = body,
                            IsEmailSent = true,
                            DateTimeSent = DateTime.Now,
                            Datecreated = DateTime.Now,
                        };
                        bl.LogEmailMessage(Logs1);
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
