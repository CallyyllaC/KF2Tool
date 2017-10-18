using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace KF2Tool
{
    public partial class ServerMut : Form
    {
        ServerData Data;
        KFEngine KFEngine = new KFEngine();
        KF2Server KF2Server = new KF2Server();
        string serverLocation;

        public ServerMut()
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

        private void ServerMut_Load(object sender, EventArgs e)
        {
            Data = InitialLoad();
            LoadData();
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
            if (File.Exists($"{serverLocation}\\KF2Server.bat"))
            {
                ServerLocationOK.Text = "OK";
                ServerLocationOK.ForeColor = Color.Green;
            }
            else
            {
                ServerLocationOK.Text = "NOT OK";
                ServerLocationOK.ForeColor = Color.Red;
            }
            if (File.Exists($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                KFEngineOK.Text = "OK";
                KFEngineOK.ForeColor = Color.Green;
                KFEngine.GetMuts(serverLocation);
                foreach (var item in KFEngine.WSMuts)
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
            TBMutators.Text = "";
            TBActors.Text = "";
            foreach (var item in KF2Server.GetMutators(serverLocation))
            {
                if (item != "")
                {
                    TBMutators.Text = TBMutators.Text + item + @"
";
                }
            }

            foreach (var item in KFEngine.GetActors(serverLocation))
            {
                TBActors.Text = TBActors.Text + item + @"
";
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK) { TBServerLocation.Text = folder.SelectedPath; }
        }

        private void LBKFEngine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                Process.Start($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini");
            }
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void WorkShopCollection_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                LBWorkshop.SelectedItem = WorkShopCollection.SelectedItem;
                WorkShopBrowser.Url = new Uri($"http://steamcommunity.com/sharedfiles/filedetails/?id={WorkShopCollection.SelectedItem.ToString()}");
            }
            catch { }
        }

        private void WorkShopBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (WorkShopBrowser.Url.ToString().Contains("https://steamcommunity.com/sharedfiles/filedetails/?id="))
            {
                TBWorkshopAdd.Text = WorkShopBrowser.Url.ToString().Replace("https://steamcommunity.com/sharedfiles/filedetails/?id=", "").Replace("&searchtext =", "");
            }
            else if (WorkShopBrowser.Url.ToString().Contains("http://steamcommunity.com/sharedfiles/filedetails/?id="))
            {
                TBWorkshopAdd.Text = WorkShopBrowser.Url.ToString().Replace("http://steamcommunity.com/sharedfiles/filedetails/?id=", "").Replace("&searchtext =", "");
            }
        }

        private void WorkshopAdd_Click_1(object sender, EventArgs e)
        {
            KFEngine.WSMuts.Add(TBWorkshopAdd.Text);
            KFEngine.SetMuts(serverLocation);
            LBWorkshop.Items.Add(TBWorkshopAdd.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TBActors.Text = null;
            foreach (var item in KFEngine.GetActors(serverLocation))
            {
                TBActors.Text = TBActors.Text + item + @"
";
            }
            TBActors.Text = TBActors.Text + TBMutAdd.Text + @"
";
            KFEngine.SetActors(serverLocation, TBMutAdd.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Collection<string> MutCollection = new Collection<string>();
            TBMutators.Text = null;
            foreach (var item in KF2Server.GetMutators(serverLocation))
            {
                TBMutators.Text = TBMutators.Text + item + @"
";
                MutCollection.Add(item);
            }
            TBMutators.Text = TBMutators.Text + TBMutAdd.Text + @"
";
            MutCollection.Add(TBMutAdd.Text);
            string output = "Mutator=";
            foreach (var item in MutCollection)
            {
                output = output + "," + item;
            }
            var tmp = KF2Server.SendMutators(output,serverLocation);
            using (StreamWriter sw = new StreamWriter($"{serverLocation}//KF2Server.bat"))
            {
                sw.Write(tmp);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{serverLocation}//KF2ServerBackup.bat"))
            {
                Form OverWrite = new Overwrite($"{serverLocation}//KF2Server.bat", $"{serverLocation}//KF2ServerBackup.bat");
                OverWrite.Show();
            }
            else
            {
                File.Copy($"{serverLocation}//KF2Server.bat", $"{serverLocation}//KF2ServerBackup.bat", false);
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
            WorkShopBrowser.Url = new Uri("https://steamcommunity.com/workshop/browse/?appid=232090&requiredtags[]=Mutators");
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

        private void LBWorkshop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WorkShopCollection.SelectedItem = LBWorkshop.SelectedItem;
                WorkShopBrowser.Url = new Uri($"http://steamcommunity.com/sharedfiles/filedetails/?id={WorkShopCollection.SelectedItem.ToString()}");
            }
            catch { }
        }
    }
}
