using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Display_System.Rotators
{
    class MessageRotator
    {
        public static string[] GetMessages()
        {
            string[] Messages = null;
            try
            {
                if (!File.Exists(Properties.Settings.Default.Path + "\\messages.txt"))
                {
                    Variables.logger.LogLine(2, "Messages files is missing and will be recreated.");
                    if (Properties.Settings.Default.MessageRotatorLargeText)
                    {
                        File.WriteAllText(Properties.Settings.Default.Path + "\\messages.txt", "Messages should not exceed the end of this line...............................................................");
                    }
                    else
                    {
                        File.WriteAllText(Properties.Settings.Default.Path + "\\messages.txt", "Messages should not exceed the end of this line............................................................................................................................................................................");
                    }
                }
                string[] linesInFile = File.ReadAllLines(Properties.Settings.Default.Path + "\\messages.txt");
                if (linesInFile.Length == 0)
                {
                    Variables.logger.LogLine(2, "An error occured while reading the messages file.");
                    return null;
                }
                if (linesInFile.Length == 1)
                {
                    Variables.logger.LogLine(1, "The messages file is empty.");
                    return null;
                }
                Messages = new string[linesInFile.Length - 1];
                for (int x = 1; x < linesInFile.Length; x++)
                {
                    Messages[x - 1] = linesInFile[x];
                }
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(2, "Error reading the messages file: " + ex.Message);
            }
            Variables.currentMessage = 0;
            return Messages;
        }
        public static string GetNextMessage()
        {
            if (Variables.messageList == null)
                return null;
            string message = Variables.messageList[Variables.currentMessage];
            if(Variables.currentMessage >= Variables.messageList.Length - 1)
                Variables.currentMessage = 0;
            else Variables.currentMessage++;
            return message;
        }
    }
}
