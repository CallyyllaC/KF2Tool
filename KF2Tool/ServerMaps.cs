using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace KF2Tool
{
    public partial class ServerMaps : Form
    {
        ServerData Data;
        KFEngine KFEngine = new KFEngine();
        KFGame KFGame = new KFGame();
        string serverLocation;

        private void Save()
        {
            Data.serverLocation = serverLocation;

            // Save data
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenWrite($"{Application.StartupPath}\\save.bin"))
            {
                formatter.Serialize(stream, Data);
            }
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

        private void LoadData()
        {
            TBServerLocation.Text = Data.serverLocation;
        }

        public ServerMaps()
        {
            InitializeComponent();
        }

        private void LBServerLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(serverLocation);
            }
            catch
            {

            }
        }

        private void ServerLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK) { TBServerLocation.Text = folder.SelectedPath; }
        }

        private void TBServerLocation_TextChanged(object sender, EventArgs e)
        {
            serverLocation = TBServerLocation.Text;
            if (Directory.Exists($"{serverLocation}\\KFGame"))
            {
                ServerLocationOK.Text = "OK";
                ServerLocationOK.ForeColor = Color.Green;
            }
            else
            {
                ServerLocationOK.Text = "NOT OK";
                ServerLocationOK.ForeColor = Color.Red;
            }
            if (File.Exists($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini"))
            {
                KFGameOK.Text = "OK";
                KFGameOK.ForeColor = Color.Green;

                string[] files = KFGame.GetMaps(serverLocation);
                
                for (int i = 0; i < files.Length; i++)
                    {
                        files[i] = Path.GetFileNameWithoutExtension(files[i]);
                    }

                    TBMaps.Text = string.Join(@"
", files);
                
            }
            else
            {
                KFGameOK.Text = "NOT OK";
                KFGameOK.ForeColor = Color.Red;
            }

            if (File.Exists($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                KFEngineOK.Text = "OK";
                KFEngineOK.ForeColor = Color.Green;
                KFEngine.GetMaps(serverLocation);
                foreach (var item in KFEngine.WSMaps)
                {
                    LBWorkshop.Items.Add(item);
                    WorkShopCollection.Items.Add(item);
                }
            }
            else
            {
                KFEngineOK.Text = "NOT OK";
                KFEngineOK.ForeColor = Color.Red;
            }
            Save();
        }

        private void LBKFGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini"))
            {
                Process.Start($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini");
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            Data = InitialLoad();
            LoadData();
        }

        private void AddMaps_Click(object sender, EventArgs e)
        {
            KFGame.SetMaps(serverLocation);
        }

        private void BackupKFGame_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{serverLocation}//KFGame//Config//PCServer-KFGameBackup.ini"))
            {
                Form OverWrite = new Overwrite($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", $"{serverLocation}//KFGame//Config//PCServer-KFGameBackup.ini");
                OverWrite.Show();
            }
            else
            {
                File.Copy($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", $"{serverLocation}//KFGame//Config//PCServer-KFGameBackup.ini", false);
            }
        }

        private void LBKFEngine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                Process.Start($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini");
            }
        }

        private void BackupKFEngine_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{serverLocation}//KFGame//Config//PCServer-KFEngineBackup.ini"))
            {
                Form OverWrite = new Overwrite($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini", $"{serverLocation}//KFGame//Config//PCServer-KFEngineBackup.ini");
                OverWrite.Show();
            }
            else
            {
                File.Copy($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini", $"{serverLocation}//KFGame//Config//PCServer-KFEngineBackup.ini", false);
            }
        }

        private void WorkShopCollection_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                LBWorkshop.SelectedItem = WorkShopCollection.SelectedItem;
                WorkShopBrowser.Url = new Uri($"http://steamcommunity.com/sharedfiles/filedetails/?id={WorkShopCollection.SelectedItem.ToString()}");
            }
            catch { }
        }

        private void LBWorkshop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WorkShopCollection.SelectedItem = LBWorkshop.SelectedItem;
                WorkShopBrowser.Url = new Uri($"http://steamcommunity.com/sharedfiles/filedetails/?id={WorkShopCollection.SelectedItem.ToString()}");
            }
            catch { }
        }

        private void WorkshopAdd_Click(object sender, EventArgs e)
        {
            KFEngine.WSMaps.Add(TBWorkshopAdd.Text);
            KFEngine.SetMaps(serverLocation);
            LBWorkshop.Items.Add(TBWorkshopAdd.Text);
        }

        private void WorkShopBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (WorkShopBrowser.Url.ToString().Contains("https://steamcommunity.com/sharedfiles/filedetails/?id="))
            {
                TBWorkshopAdd.Text = WorkShopBrowser.Url.ToString().Replace("https://steamcommunity.com/sharedfiles/filedetails/?id=", "").Replace("&searchtext =", "");
            }
            else if(WorkShopBrowser.Url.ToString().Contains("http://steamcommunity.com/sharedfiles/filedetails/?id="))
            {
                TBWorkshopAdd.Text = WorkShopBrowser.Url.ToString().Replace("http://steamcommunity.com/sharedfiles/filedetails/?id=", "").Replace("&searchtext =", "");
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            WorkShopBrowser.GoBack();
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            WorkShopBrowser.GoForward();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            WorkShopBrowser.Url = new Uri("https://steamcommunity.com/workshop/browse/?appid=232090&requiredtags[]=Maps");
        }

        private void ServerLocationOK_Click(object sender, EventArgs e)
        {

        }

        private void ButSearch_Click(object sender, EventArgs e)
        {
            try
            {
                WorkShopBrowser.Url = new Uri($"https://steamcommunity.com/sharedfiles/filedetails/?id={TBSearch.Text}");
            }
            catch
            {

            }
        }
    }
}
