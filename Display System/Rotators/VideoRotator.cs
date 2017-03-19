using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Display_System.Rotators
{
    class VideoRotator
    {
        public static string[] GetVideos()
        {
            string[] Videos = { "" };
            try
            {
                DirectoryInfo dir = new DirectoryInfo(Properties.Settings.Default.Path + "\\Videos");
                DirectoryInfo[] dirs = dir.GetDirectories();
                if (!dir.Exists)
                {
                    Variables.logger.LogLine(2, "The video directory does not exist or could not be found.");
                    return null;
                }
                string[] filter = { "wmv", "avi", "mp4" };
                string[] files = GetFilesFrom(dir.FullName, filter, true);
                Videos = new string[files.Length];
                for (int x = 0; x < files.Length; x++)
                {
                    Variables.logger.LogLine("Adding file: " + files[x] + " to video list");
                    Videos[x] = files[x];
                }
                Variables.currentImage = 0;
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(2, "Failed to get list of videos: " + ex.Message);
            }
            return Videos;
        }
        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }
        public static string GetNextVideo()
        {
            if (Variables.videoList.Length > 0)
            {
                string toDisplay = null;
                try
                {
                    toDisplay = Variables.videoList[Variables.currentVideo];
                }
                catch (Exception ex)
                {
                    Variables.logger.LogLine(2, "Video failed to load: " + ex.Message);
                }
                finally
                {
                    if (Variables.currentVideo >= Variables.videoList.Length - 1)
                    {
                        Variables.currentVideo = 0;
                        if (Variables.imagePathList.Length > 0)
                            Variables.runVideo = false;
                    }
                    else
                        Variables.currentVideo++;
                }
                return toDisplay;
            }
            else
            {
                if (Variables.imagePathList.Length > 0)
                Variables.runVideo = false;
                return null;
            }
        }
    }
}
