using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KF2Tool
{
    class KFEngine
    {
        public Collection<string> WSMaps = new Collection<string>();
        public Collection<string> WSMuts = new Collection<string>();

        public void GetMaps(string serverLocation)
        {
            WSMaps.Clear();
            int counter = 0;
            int MapsStart = 0;
            int MapsEnd = 0;
            string[] EngineContent = new string[File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini").Count()];
            foreach (var line in File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                EngineContent[counter] = line;
                if (line.Contains("; --MapsStart-- ;")) { MapsStart = counter; }
                if (line.Contains("; --MapsEnd-- ;")) { MapsEnd = counter; }
                counter++;
            }
            string[] KFEnginelinesP1; //part before the maps
            string[] KFEnginelinesP2; //maps + everything after maps
            string[] KFEnginelinesP3; //maps
            string[] KFEnginelinesP4; //everything after maps

            Split(EngineContent, MapsStart, out KFEnginelinesP1, out KFEnginelinesP2);
            Split(KFEnginelinesP2, MapsEnd - MapsStart + 1, out KFEnginelinesP3, out KFEnginelinesP4);
            KFEnginelinesP1 = null;
            KFEnginelinesP2 = null;
            KFEnginelinesP4 = null;
            foreach (var item in KFEnginelinesP3)
            {
                if (item.Contains("ServerSubscribedWorkshopItems="))
                {
                    string tmp = item;
                    tmp = tmp.Replace("ServerSubscribedWorkshopItems=", "");
                    tmp = tmp.Trim();
                    WSMaps.Add(tmp);
                }
            }
        }

        public void SetMaps(string serverLocation)
        {
            int counter = 0;
            int MapsStart = 0;
            int MapsEnd = 0;
            bool Workshop = false;
            string[] EngineContent = new string[File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini").Count()];
            foreach (var line in File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                EngineContent[counter] = line;
                if (line.Contains("[OnlineSubsystemSteamworks.KFWorkshopSteamworks]")) { Workshop = true; }
                if (line.Contains("; --MapsStart-- ;")) { MapsStart = counter; }
                if (line.Contains("; --MapsEnd-- ;")) { MapsEnd = counter; }
                counter++;
            }
            if (Workshop == false)
            {
                using (StreamWriter sw = new StreamWriter($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
                {
                    foreach (var item in EngineContent)
                    {
                        sw.WriteLine(item);
                    }
                    sw.WriteLine("[OnlineSubsystemSteamworks.KFWorkshopSteamworks]");
                    sw.WriteLine("; --MapsStart-- ;");
                    sw.WriteLine("");
                    foreach (var item in WSMaps)
                    {
                        sw.WriteLine($"ServerSubscribedWorkshopItems={item}");
                    }
                    sw.WriteLine("; --MapsEnd-- ;");
                    sw.WriteLine("; --MutsStart-- ;");
                    sw.WriteLine("; --MutsEnd-- ;");
                }
            }
            else
            {
                string[] KFEnginelinesP1; //part before the custom maps
                string[] KFEnginelinesP2; //custom maps + everything after custom maps
                string[] KFEnginelinesP3; //custom maps
                string[] KFEnginelinesP4; //everything after custom maps

                Split(EngineContent, MapsStart, out KFEnginelinesP1, out KFEnginelinesP2);
                Split(KFEnginelinesP2, MapsEnd - MapsStart + 1, out KFEnginelinesP3, out KFEnginelinesP4);
                KFEnginelinesP2 = null;
                KFEnginelinesP3 = null;
                using (StreamWriter sw = new StreamWriter($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
                {
                    foreach (var item in KFEnginelinesP1)
                    {
                        sw.WriteLine(item);
                    }
                    sw.WriteLine("; --MapsStart-- ;");
                    foreach (var item in WSMaps)
                    {
                        sw.WriteLine($"ServerSubscribedWorkshopItems={item}");
                    }
                    sw.WriteLine("; --MapsEnd-- ;");

                    foreach (var item in KFEnginelinesP4)
                    {
                        sw.WriteLine(item);
                    }
                }
                KFEnginelinesP1 = null;
                KFEnginelinesP4 = null;
            }
        }

        public string[] GetActors(string serverLocation)
        {
            int counter = 0;
            Collection<int> Actorlist = new Collection<int>();
            string[] EngineContent = new string[File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini").Count()];
            foreach (var line in File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                EngineContent[counter] = line;
                if (line.Contains("ServerActors=")) { Actorlist.Add(counter); }
                counter++;
            }
            counter = 0;
            string[] Actors = new string[Actorlist.Count()];
            for (int i = 0; i < EngineContent.Length; i++)
            {
                for (int i2 = 0; i2 < Actorlist.Count(); i2++)
                {
                    if (i == Actorlist[i2])
                    {
                        Actors[counter] = EngineContent[i].Replace("ServerActors=", "").Trim();
                        counter++;
                    }
                }
            }
            return Actors;
        }

        public void SetActors(string serverLocation,string input)
        {
            string[] NewActors = new string[GetActors(serverLocation).Count() + 1];
            for (int i = 0; i < GetActors(serverLocation).Length; i++)
            {
                NewActors[i] = GetActors(serverLocation)[i];
            }
            NewActors[NewActors.Count() - 1] = input;
            int counter = 0;
            List<int> Actorlist = new List<int>();
            string[] EngineContent = new string[File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini").Count()];
            foreach (var line in File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                EngineContent[counter] = line;
                if (line.StartsWith("ServerActors=")) { Actorlist.Add(counter); }
                counter++;
            }
            Actorlist.Sort();
            string[] KFEnginelinesP1; //part before the muts
            string[] KFEnginelinesP2; //muts + everything after muts
            if (Actorlist.Count() > 1)
            {
                string[] KFEnginelinesP3; //muts
                string[] KFEnginelinesP4; //everything after muts

                Split(EngineContent, Actorlist[0], out KFEnginelinesP1, out KFEnginelinesP2);
                Split(KFEnginelinesP2, Actorlist[Actorlist.Count() - 1] - Actorlist[0] + 1, out KFEnginelinesP3, out KFEnginelinesP4);
                KFEnginelinesP2 = null;
                KFEnginelinesP3 = null;
                using (StreamWriter sw = new StreamWriter($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
                {
                    foreach (var item in KFEnginelinesP1)
                    {
                        sw.WriteLine(item);
                    }
                    foreach (var item in NewActors)
                    {
                        sw.WriteLine($"ServerActors={item}");
                    }
                    foreach (var item in KFEnginelinesP4)
                    {
                        sw.WriteLine(item);
                    }
                }

                KFEnginelinesP4 = null;
            }
            else
            {
                counter = 0;
                int found = 0;
                foreach (var line in File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
                {
                    EngineContent[counter] = line;
                    if (line.Contains("[Engine.GameEngine]"))
                    {
                        found = counter;
                    }
                    counter++;
                }
                Split(EngineContent, found + 1, out KFEnginelinesP1, out KFEnginelinesP2);
                using (StreamWriter sw = new StreamWriter($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
                {
                    foreach (var item in KFEnginelinesP1)
                    {
                        sw.WriteLine(item);
                    }
                    foreach (var item in GetActors(serverLocation))
                    {
                        sw.WriteLine($"ServerActors={item}");
                    }
                    foreach (var item in KFEnginelinesP2)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            KFEnginelinesP1 = null;
            KFEnginelinesP2 = null;
        }

        public void GetMuts(string serverLocation)
        {
            WSMuts.Clear();
            int counter = 0;
            int MutsStart = 0;
            int MutsEnd = 0;
            string[] EngineContent = new string[File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini").Count()];
            foreach (var line in File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                EngineContent[counter] = line;
                if (line.Contains("; --MutsStart-- ;")) { MutsStart = counter; }
                if (line.Contains("; --MutsEnd-- ;")) { MutsEnd = counter; }
                counter++;
            }
            string[] KFEnginelinesP1; //part before the muts
            string[] KFEnginelinesP2; //muts + everything after muts
            string[] KFEnginelinesP3; //muts
            string[] KFEnginelinesP4; //everything after muts

            Split(EngineContent, MutsStart, out KFEnginelinesP1, out KFEnginelinesP2);
            Split(KFEnginelinesP2, MutsEnd - MutsStart + 1, out KFEnginelinesP3, out KFEnginelinesP4);
            KFEnginelinesP1 = null;
            KFEnginelinesP2 = null;
            KFEnginelinesP4 = null;
            foreach (var item in KFEnginelinesP3)
            {
                if (item.Contains("ServerSubscribedWorkshopItems="))
                {
                    string tmp = item;
                    tmp = tmp.Replace("ServerSubscribedWorkshopItems=", "");
                    tmp = tmp.Trim();
                    WSMuts.Add(tmp);
                }
            }
        }

        public void SetMuts(string serverLocation)
        {
            int counter = 0;
            int MutsStart = 0;
            int MutsEnd = 0;
            bool Workshop = false;
            string[] EngineContent = new string[File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini").Count()];
            foreach (var line in File.ReadLines($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                EngineContent[counter] = line;
                if (line.Contains("[OnlineSubsystemSteamworks.KFWorkshopSteamworks]")) { Workshop = true; }
                if (line.Contains("; --MutsStart-- ;")) { MutsStart = counter; }
                if (line.Contains("; --MutsEnd-- ;")) { MutsEnd = counter; }
                counter++;
            }
            if (Workshop == false)
            {
                using (StreamWriter sw = new StreamWriter($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
                {
                    foreach (var item in EngineContent)
                    {
                        sw.WriteLine(item);
                    }
                    sw.WriteLine("[OnlineSubsystemSteamworks.KFWorkshopSteamworks]");
                    sw.WriteLine("; --MutsStart-- ;");
                    sw.WriteLine("");
                    foreach (var item in WSMuts)
                    {
                        sw.WriteLine($"ServerSubscribedWorkshopItems={item}");
                    }
                    sw.WriteLine("; --MutsEnd-- ;");
                    sw.WriteLine("; --MapsStart-- ;");
                    sw.WriteLine("; --MapsEnd-- ;");
                }
            }
            else
            {
                string[] KFEnginelinesP1; //part before the muts
                string[] KFEnginelinesP2; //muts + everything after muts
                string[] KFEnginelinesP3; //muts
                string[] KFEnginelinesP4; //everything after muts

                Split(EngineContent, MutsStart, out KFEnginelinesP1, out KFEnginelinesP2);
                Split(KFEnginelinesP2, MutsEnd - MutsStart + 1, out KFEnginelinesP3, out KFEnginelinesP4);
                KFEnginelinesP2 = null;
                KFEnginelinesP3 = null;
                using (StreamWriter sw = new StreamWriter($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
                {
                    foreach (var item in KFEnginelinesP1)
                    {
                        sw.WriteLine(item);
                    }
                    sw.WriteLine("; --MutsStart-- ;");
                    foreach (var item in WSMuts)
                    {
                        sw.WriteLine($"ServerSubscribedWorkshopItems={item}");
                    }
                    sw.WriteLine("; --MutsEnd-- ;");

                    foreach (var item in KFEnginelinesP4)
                    {
                        sw.WriteLine(item);
                    }
                }
                KFEnginelinesP1 = null;
                KFEnginelinesP4 = null;
            }
        }

        private void Split<T>(T[] array, int index, out T[] first, out T[] second)
        {
            first = array.Take(index).ToArray();
            second = array.Skip(index).ToArray();
        }
    }
}
