using Narochno.Steam;
using Narochno.Steam.Entities;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace KF2Tool
{
    public partial class KF2Tool : Form
    {
        ServerData Data;
        string serverLocation;

        public KF2Tool()
        {
            InitializeComponent();
        }

        private void Save()
        {
            Data.serverLocation = serverLocation;

            // Save data
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenWrite($"{Application.StartupPath}\\save.bin"))
            {
                formatter.Serialize(stream, Data);
                stream.Dispose();
            }
        }

        private void LoadData()
        {
            TBServerLocation.Text = Data.serverLocation;
        }

        private ServerData InitialLoad()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream stream = File.OpenRead($"{Application.StartupPath}\\save.bin"))
                {
                    return (ServerData)formatter.Deserialize(stream);
                }
            }
            catch { return new ServerData(); }
        }

        private void ServerMaps_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "ServerMaps")
                    {
                        n.BringToFront();
                        found = true;
                    }
                }
                if (!found)
                {
                    ServerMaps Server = new ServerMaps();
                    Server.Name = "ServerMaps";
                    Server.Show();
                }
            }
            catch
            {
            }
        }

        private void Client_Click(object sender, EventArgs e)
        {

            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "Client")
                    {
                        n.BringToFront();
                        found = true;
                    }
                }
                if (!found)
                {
                    Client Client = new Client();
                    Client.Name = "Client";
                    Client.Show();
                }
            }
            catch
            {
            }
        }

        private async void KF2Tool_Load(object sender, EventArgs e)
        {
            Data = InitialLoad();
            LoadData();
            using (var steamClient = new SteamClient())
            {
                var cancel = new System.Threading.CancellationToken();
                var news = await steamClient.GetNewsForApp(new GetNewsForAppRequest(232090), cancel);
                TBKF2LatestNews.Text = news.AppNews.NewsItems[0].Contents;
            }
        }

        private void ServerMutators_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "ServerMods")
                    {
                        n.BringToFront();
                        found = true;
                    }
                }
                if (!found)
                {
                    ServerMut ServerMut = new ServerMut();
                    ServerMut.Name = "ServerMods";
                    ServerMut.Show();
                }
            }
            catch
            {
            }
        }

        private void ServerConfig_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "ServerConfig")
                    {
                        n.BringToFront();
                        found = true;
                    }
                }
                if (!found)
                {
                    ServerConfig ServerConfig = new ServerConfig();
                    ServerConfig.Name = "ServerConfig";
                    ServerConfig.Show();
                }
            }
            catch
            {
            }
        }

        private void ServerLocation_Click_1(object sender, EventArgs e)
        {
            try { Process.Start(serverLocation); }
            catch { }
        }

        private void ServerLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK) { TBServerLocation.Text = folder.SelectedPath; }
        }

        private void ButUpdateServer_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(TBServerLocation.Text))
            {
                try { Process.Start($"{Application.StartupPath}\\steamcmd.exe", $"+login anonymous +force_install_dir {'"' + TBServerLocation.Text + '"'} +app_update 232130 validate +exit"); }
                catch { }
            }
            else if(TBServerLocation.Text == null|| TBServerLocation.Text == "") { }
            else
            {
                try { Directory.CreateDirectory(TBServerLocation.Text); try { Process.Start($"{Application.StartupPath}\\steamcmd.exe", $"+login anonymous +force_install_dir {'"' + TBServerLocation.Text + '"'} +app_update 232130 validate +exit"); } catch { } }
                catch { }
            }
        }

        private void TBServerLocation_TextChanged(object sender, EventArgs e)
        {
            serverLocation = TBServerLocation.Text;
            Save();
        }
    }
}
