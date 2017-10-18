using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KF2Tool
{
    class KF2Server
    {

        public string[] GetMutators(string serverLocation)
        {
            string KF2Server = File.ReadAllText($"{serverLocation}//KF2Server.bat");
            string[] Options = KF2Server.Split('?');
            string MutString = null;
            foreach (var item in Options)
            {
                if (item.Contains("Mutator="))
                {
                    MutString = item;
                }
            }
            string[] Mutators = null;
            try
            {
                MutString = MutString.Replace("Mutator=", "");
                Mutators = MutString.Split(',');
                for (int i = 0; i < Mutators.Length; i++)
                {
                    Mutators[i] = Mutators[i].Replace(",", "").Trim();
                }
            }
            catch
            {
                Mutators = new string[] { "" };
            }

            return Mutators;
        }

        public string SendMutators(string input, string serverLocation)
        {
            string KF2Server = File.ReadAllText($"{serverLocation}//KF2Server.bat");
            string[] Options = KF2Server.Split('?');
            string Options2 = null;
            for (int i = 0; i < Options.Length; i++)
            {
                if (Options[i].Contains("Mutator="))
                {
                    Options[i] = input;
                }
            }
            foreach (var item in Options)
            {
                Options2 = Options2 + item + "?";
            }
            return Options2;
        }
    }
}
