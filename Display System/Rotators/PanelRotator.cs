using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Display_System.Rotators
{
    class PanelRotator
    {
        public static string DisplayText()
        {
            string toReturn = "";
            try
            {
                if (Properties.Settings.Default.ManualPanelOverride == null || Properties.Settings.Default.ManualPanelOverride == "")
                {
                    if (Variables.usingForcedPanelText)
                    {
                        toReturn = Regex.Unescape(Variables.forcedPanelText);
                    }
                    else
                    {
                        toReturn = Regex.Unescape(Variables.panelText[(int)DateTime.Now.DayOfWeek]);
                    }
                }
                else
                    toReturn = Regex.Unescape(Properties.Settings.Default.ManualPanelOverride);
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(2, "Error parsing panel text, please check regex syntax: "+ex.Message);
            }
                return toReturn;
        }
        public static Image DisplayImage()
        {
                if (Properties.Settings.Default.PanelImagePath != "")
                {
                    Image toReturn = null;
                    try
                    {
                        toReturn = Image.FromFile(Properties.Settings.Default.PanelImagePath);
                    }
                    catch (Exception ex)
                    {
                        Variables.logger.LogLine(2, "Unable to load panel image file: " + ex.Message);
                    }
                    return toReturn;
                }
                else
                return null;
            }
        }
    }
