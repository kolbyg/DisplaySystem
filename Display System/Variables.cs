using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NetworksApi.TCP.SERVER;

namespace Display_System
{
    class Variables
    {
        public static IO.Logger logger;
        public static string programPath = Environment.CurrentDirectory;
        public static int logVerbosity = 0;
        public static string logPath = programPath + "\\Logs";
        public static string[] panelText = new string[7];
        public static string forcedPanelText = "";
        public static bool usingForcedPanelText = false;
        public static string panelImagePath = "";
        public static Image panelImage = null;
        public static int currentImage = 0;
        public static string[] imagePathList;
        public static int currentMessage = 0;
        public static string[] messageList;
        public static int currentVideo = 0;
        public static string[] videoList;
        public static bool runVideo;
        public static Server clientConnServer;
    }
}
