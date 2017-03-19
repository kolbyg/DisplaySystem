using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Display_System.Rotators
{
    class PictureRotator
    {
        public static string[] GetImages()
        {
            string[] Images = { "" };
            try
            {
                DirectoryInfo dir = new DirectoryInfo(Properties.Settings.Default.Path + "\\Pictures");
                DirectoryInfo[] dirs = dir.GetDirectories();
                if (!dir.Exists)
                {
                    Variables.logger.LogLine(2, "The picture directory does not exist or could not be found.");
                    return null;
                }
                string[] filter = {"jpg", "gif", "png"};
                string[] files = GetFilesFrom(dir.FullName, filter, true);
                Images = new string[files.Length];
                for (int x = 0; x < files.Length; x++)
                {
                    Variables.logger.LogLine("Adding file: " + files[x] + " to picture list");
                    Images[x] = files[x];
                }
                Variables.currentImage = 0;
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(2, "Failed to get list of images: " + ex.Message);
            }
            return Images;
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
        public static Image GetNextImage()
        {
            if (Variables.imagePathList.Length > 0)
            {
                Image toDisplay = null;
                try
                {
                    toDisplay = Image.FromFile(Variables.imagePathList[Variables.currentImage]);
                }
                catch (Exception ex)
                {
                    Variables.logger.LogLine(2, "Image failed to load: " + ex.Message);
                }
                finally
                {
                    if (Variables.currentImage >= Variables.imagePathList.Length - 1)
                    {
                        Variables.currentImage = 0;
                        if (Variables.videoList.Length > 0)
                            Variables.runVideo = true;
                    }
                    else
                        Variables.currentImage++;
                }
                return toDisplay;
            }
            else
                if (Variables.videoList.Length > 0)
                    Variables.runVideo = true;
                return null;
        }
    }
}
