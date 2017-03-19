using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Display_System.IO
{
    class Init
    {
        public static void runInit()
        {
            runFirstTimeInit();
            loadConfig();
            scanDirs();
            loadResources();
            ClientCommunication.startNetServer();
        }
        public static void loadResources()
        {
        }
        public static void scanDirs()
        {
            Variables.imagePathList = Rotators.PictureRotator.GetImages();
            Variables.messageList = Rotators.MessageRotator.GetMessages();
            Variables.videoList = Rotators.VideoRotator.GetVideos();
        }
        public static void genPanelTextFile()
        {
            string[] PanelText =
            {
                        "#Display System Panel Text",
                        "#Please enter text in the following format:",
                        @"#Day 1\nA\nB\nC\nD",
                        @"#Note the \n for newline",
                        @"#Note that the text parser may add a \ to the front of any spaces. This has no impact on how the line is displayed.",
                        @"#This is due to the way Regex handles spaces, this will be fixed in a future version.",
                        "",
                        "Sunday:\"" + Regex.Escape(Properties.Settings.Default.PanelSundayText.Replace("\r\n", "\n")) + "\"",
                        "Monday:\"" + Regex.Escape(Properties.Settings.Default.PanelMondayText.Replace("\r\n", "\n")) + "\"",
                        "Tuesday:\"" + Regex.Escape(Properties.Settings.Default.PanelTuesdayText.Replace("\r\n", "\n")) + "\"",
                        "Wednesday:\"" + Regex.Escape(Properties.Settings.Default.PanelWednesdayText.Replace("\r\n", "\n")) + "\"",
                        "Thursday:\"" + Regex.Escape(Properties.Settings.Default.PanelThursdayText.Replace("\r\n", "\n")) + "\"",
                        "Friday:\"" + Regex.Escape(Properties.Settings.Default.PanelFridayText.Replace("\r\n", "\n")) + "\"",
                        "Saturday:\"" + Regex.Escape(Properties.Settings.Default.PanelSaturdayText.Replace("\r\n", "\n")) + "\""
                    };
            File.WriteAllLines(Properties.Settings.Default.Path + "\\PanelText.txt", PanelText);
        }
        public static void loadConfig()
        {
            try
            {
                if (!File.Exists(Properties.Settings.Default.Path + "\\PanelText.txt"))
                    genPanelTextFile();
                    //File.WriteAllText(Properties.Settings.Default.Path + "\\PanelText.txt", Properties.Resources.PanelText);
                string[] PanelTextData = File.ReadAllLines(Properties.Settings.Default.Path + "\\PanelText.txt");
                foreach(string str in PanelTextData)
                {
                    if (str.StartsWith("#")) continue;
                    string parsedString = str.Replace("\\n", "\r\n");
                    parsedString = parsedString.Replace("\"", "");
                    string[] sStr = parsedString.Split(':');
                    if (sStr.Length <=1)
                        continue;
                    if (sStr.Length != 2) {
                        Variables.logger.LogLine("An error occured while parsing the panel text file");
                        break;
                    }
                    sStr[1] = Regex.Unescape(sStr[1]);
                    switch (sStr[0])
                    {
                        case "Sunday":
                            Properties.Settings.Default.PanelSundayText = sStr[1];
                            break;
                        case "Monday":
                            Properties.Settings.Default.PanelMondayText = sStr[1];
                            break;
                        case "Tuesday":
                            Properties.Settings.Default.PanelTuesdayText = sStr[1];
                            break;
                        case "Wednesday":
                            Properties.Settings.Default.PanelWednesdayText = sStr[1];
                            break;
                        case "Thursday":
                            Properties.Settings.Default.PanelThursdayText = sStr[1];
                            break;
                        case "Friday":
                            Properties.Settings.Default.PanelFridayText = sStr[1];
                            break;
                        case "Saturday":
                            Properties.Settings.Default.PanelSaturdayText = sStr[1];
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Variables.logger.LogLine("Error reading override text file.");
            }
            try
            {
                Variables.panelText[0] = Properties.Settings.Default.PanelSundayText;
                Variables.panelText[1] = Properties.Settings.Default.PanelMondayText;
                Variables.panelText[2] = Properties.Settings.Default.PanelTuesdayText;
                Variables.panelText[3] = Properties.Settings.Default.PanelWednesdayText;
                Variables.panelText[4] = Properties.Settings.Default.PanelThursdayText;
                Variables.panelText[5] = Properties.Settings.Default.PanelFridayText;
                Variables.panelText[6] = Properties.Settings.Default.PanelSaturdayText;
                string[] PanelOverrides = Properties.Settings.Default.PanelOverrides.Split('|');
                if (PanelOverrides.Length > 0)
                {
                    for (int x = 0; x < PanelOverrides.Length; x++)
                    {
                        string[] OvrValue = PanelOverrides[x].Split('=');
                        if (OvrValue[0] == DateTime.Now.ToString("yyyy-MM-dd"))
                        {
                            Variables.forcedPanelText = OvrValue[1];
                            Variables.usingForcedPanelText = true;
                        }
                        else
                        {
                            Variables.forcedPanelText = "";
                            Variables.usingForcedPanelText = false;
                        }
                    }
                }
                else
                {
                    Variables.forcedPanelText = "";
                    Variables.usingForcedPanelText = false;
                }
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(2, "An error occurred while reading the config file:" + ex.Message);
            }
            
        }
        public static void runFirstTimeInit()
        {
            //create directories
            try
            {
                if (!Directory.Exists(Properties.Settings.Default.Path))
                    Directory.CreateDirectory(Properties.Settings.Default.Path);
                if (!Directory.Exists(Properties.Settings.Default.Path + "\\Pictures"))
                    Directory.CreateDirectory(Properties.Settings.Default.Path + "\\Pictures");
                if (!Directory.Exists(Properties.Settings.Default.Path + "\\Videos"))
                    Directory.CreateDirectory(Properties.Settings.Default.Path + "\\Videos");
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(2, "Failed to create directories:" + ex.Message);
            }
        }
    }
}
