using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Display_System.IO
{
    class Email
    {
        public static void EmailLog()
        {
            try
            {
                MailMessage mail = new MailMessage("kolbygraham@gmail.com", "kolbygraham@gmail.com");
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "aspmx.l.google.com";
                client.EnableSsl = true;
                mail.Subject = "Display System Log File";
                mail.Body = "Please see the attached log file for debugging purposes.";
                Variables.logger.writing = true;
                //mail.Attachments.Add(new Attachment(Variables.logger.loglocation + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log"));
                client.Send(mail);
                Variables.logger.writing = false;
                Variables.logger.LogLine("Email Message Send with attachement: " + Variables.logger.loglocation + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
            }
            catch (Exception ex)
            {
                Variables.logger.writing = false;
                Variables.logger.LogLine(2, "Unable to send log email: " + ex.InnerException);
            }
        }
    }
}
