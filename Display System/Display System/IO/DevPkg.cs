using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Display_System.IO
{
    class DevPkg
    {
        public static void SaveLog()
        {

            try
            {
                //Variables.logger.writing = true;
                //mail.Attachments.Add(new Attachment(Variables.logger.loglocation + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log"));
                Variables.logger.LogLine("Email Message Send with attachement: " + Variables.logger.loglocation + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(2, "Unable to send log email: " + ex.InnerException);
            }
            finally
            {
                //Variables.logger.writing = false;
            }
        }
    }
}
