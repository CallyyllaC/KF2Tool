using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KF2Tool
{
    class KFGame
    {
        public string[] GetMaps(string serverLocation)
        {
            string[] files = Directory.GetFiles($"{serverLocation}\\KFGame\\Cache", "*.kfm", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileNameWithoutExtension(files[i]);
            }
            return files;
        }

        public void SetMaps(string serverLocation)
        {
            string[] files = GetMaps(serverLocation);
            int kfgamelength = File.ReadAllLines($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini").Count();
            string[] KFGamelines = new string[kfgamelength];
            int counter = 0;
            int customMapsStart = 0;
            int customMapsEnd = 0;
            bool customMaps = false;

            int newcounter = 0;
            string[] CustomMapsArray = new string[files.Length * 4];
            for (int i = 0; i < files.Length; i++)
            {
                CustomMapsArray[newcounter] = $"[{files[i]} KFMapSummary]";
                newcounter++;
                CustomMapsArray[newcounter] = $"MapName = {files[i]}";
                newcounter++;
                CustomMapsArray[newcounter] = $"ScreenshotPathName = UI_MapPreview_TEX.UI_MapPreview_Placeholder";
                newcounter++;
                CustomMapsArray[newcounter] = "";
                newcounter++;
            }

            foreach (var line in File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini"))
            {
                KFGamelines[counter] = line;
                if (line.Contains("; --Custom Maps Start-- ;")) { customMapsStart = counter; customMaps = true; }
                if (line.Contains("; --Custom Maps End-- ;")) { customMapsEnd = counter; }
                counter++;
            }
            if (customMaps == true)
            {
                string[] KFGamelinesP1; //part before the custom maps
                string[] KFGamelinesP2; //custom maps + everything after custom maps
                string[] KFGamelinesP3; //custom maps
                string[] KFGamelinesP4; //everything after custom maps

                Split(KFGamelines, customMapsStart, out KFGamelinesP1, out KFGamelinesP2);
                Split(KFGamelinesP2, customMapsEnd - customMapsStart + 1, out KFGamelinesP3, out KFGamelinesP4);
                KFGamelinesP2 = null;
                KFGamelinesP3 = null;

                using (StreamWriter sw = new StreamWriter($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini"))
                {
                    foreach (var item in KFGamelinesP1)
                    {
                        sw.WriteLine(item);
                    }

                    sw.WriteLine("; --Custom Maps Start-- ;");
                    sw.WriteLine("");
                    foreach (var item in CustomMapsArray)
                    {
                        sw.WriteLine(item);
                    }
                    sw.WriteLine("; --Custom Maps End-- ;");

                    foreach (var item in KFGamelinesP4)
                    {
                        sw.WriteLine(item);
                    }

                }

                KFGamelinesP1 = null;
                KFGamelinesP4 = null;
            }
            else
            {
                using (StreamWriter sw = new StreamWriter($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini"))
                {
                    foreach (var item in KFGamelines)
                    {
                        sw.WriteLine(item);
                    }
                    sw.WriteLine("");
                    sw.WriteLine("; --Custom Maps Start-- ;");
                    sw.WriteLine("");
                    foreach (var item in CustomMapsArray)
                    {
                        sw.WriteLine(item);
                    }
                    sw.WriteLine("; --Custom Maps End-- ;");
                }
            }
        }

        private void Split<T>(T[] array, int index, out T[] first, out T[] second)
        {
            first = array.Take(index).ToArray();
            second = array.Skip(index).ToArray();
        }
    }
}
