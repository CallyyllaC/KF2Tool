using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace KF2Tool
{
    public partial class ServerConfig : Form
    {
        string serverLocation;
        ServerData Data;
        bool serverFound = false;
        Collection<string> Custominis = new Collection<string>();
        public ServerConfig()
        {
            InitializeComponent();
        }

        private void ServerConfig_Load(object sender, EventArgs e)
        {
            Data = InitialLoad();
            LoadData();
            foreach (var item in Custominis)
            {
                CustomFiles.Items.Add(item);
            }
            try
            {
                TBServerPort.Text = GetValue($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini", "Port=");
                TBServerPeerPort.Text = GetValue($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini", "PeerPort=");
                TBServerGameName.Text = GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "ServerName=");

                if(GetValue($"{serverLocation}//KFGame//Config//KFWeb.ini", "bEnabled=").ToLower() == "true")
                {
                    CBWebAdminEnabled.Text = "True";
                }
                else
                {
                    CBWebAdminEnabled.Text = "False";
                }
                TBWebPort.Text = GetValue($"{serverLocation}//KFGame//Config//KFWeb.ini", "ListenPort=");
                TBWebPassword.Text = GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "AdminPassword=");
                TBGameMaxPlayers.Text = GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "MaxPlayers=");
                TBGameDifficulty.Text = GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "GameDifficulty=");
                TBGameMode.Text = GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "DefaultGame=");
                TBGamePassword.Text = GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "GamePassword=");
                TBGameFF.Text = GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "FriendlyFireScale=");
                if(GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "bDisableTeamCollision=").ToLower() == "true")
                {
                    CBGameCollide.Text = "True";
                }
                else
                {
                    CBGameCollide.Text = "False";
                }

                if (GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "bDisablePickups=").ToLower() == "true")
                {
                    CBGamePickups.Text = "True";
                }
                else
                {
                    CBGamePickups.Text = "False";
                }

                if (GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "bDisableKickVote=").ToLower() == "true")
                {
                    CBGameVoteKick.Text = "True";
                }
                else
                {
                    CBGameVoteKick.Text = "False";
                }
                TBGameKick.Text = float.Parse(GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "KickVotePercentage=")).ToString();

                if (float.Parse(GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "GameLength=")) == 0)
                {
                    CBGameLength.Text = "Short";
                }
                else if (float.Parse(GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "GameLength=")) == 1)
                {
                    CBGameLength.Text = "Medium";
                }
                else if (float.Parse(GetValue($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "GameLength=")) == 2)
                {
                    CBGameLength.Text = "Long";
                }
                else
                {
                    CBGameLength.Text = "Error";
                }
            }
            catch { }
        }

        private void TBServerLocation_TextChanged(object sender, EventArgs e)
        {
        serverLocation = TBServerLocation.Text;
            if (Directory.Exists($"{serverLocation}\\KFGame"))
            {
                ServerLocationOK.Text = "OK";
                ServerLocationOK.ForeColor = Color.Green;
                serverFound = true;
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
            }
            else
            {
                KFGameOK.Text = "NOT OK";
                KFGameOK.ForeColor = Color.Red;
            }
            if (File.Exists($"{serverLocation}//KFGame//Config//KFWeb.ini"))
            {
                KFWebOK.Text = "OK";
                KFWebOK.ForeColor = Color.Green;
            }
            else
            {
                KFWebOK.Text = "NOT OK";
                KFWebOK.ForeColor = Color.Red;
            }
            if (File.Exists($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                KFEngineOK.Text = "OK";
                KFEngineOK.ForeColor = Color.Green;
            }
            else
            {
                KFEngineOK.Text = "NOT OK";
                KFEngineOK.ForeColor = Color.Red;
            }
            Save();
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
            Custominis.Clear();
            foreach (var item in Data.Serverinis)
            {
                Custominis.Add(item);
            }
        }

        private void Save()
        {
            Data.serverLocation = serverLocation;
            Data.Serverinis = null;
            Data.Serverinis = new string[Custominis.Count()];
            for (int i = 0; i < Custominis.Count(); i++)
            {
                Data.Serverinis[i] = Custominis[i];
            }

            // Save data
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenWrite($"{Application.StartupPath}\\save.bin"))
            {
                formatter.Serialize(stream, Data);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (serverFound == true)
            {
                if (File.Exists($"{serverLocation}//KFGame//Config//{TBCustomini.Text}"))
                {
                    CustominiWait.Text = "OK";
                    CustominiWait.ForeColor = Color.Green;
                    ButAddCustomini.Enabled = true;
                }
                else if (File.Exists($"{TBCustomini.Text}"))
                {
                    CustominiWait.Text = "OK";
                    CustominiWait.ForeColor = Color.Green;
                    ButAddCustomini.Enabled = true;
                }
                else if (TBCustomini.Text == "")
                {
                    CustominiWait.Text = "Wait";
                    CustominiWait.ForeColor = Color.Black;
                    ButAddCustomini.Enabled = false;
                }
                else
                {
                    CustominiWait.Text = "NOT OK";
                    CustominiWait.ForeColor = Color.Red;
                    ButAddCustomini.Enabled = false;
                }
            }
        }

        private void ButAddCustomini_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{serverLocation}//KFGame//Config//{TBCustomini.Text}"))
            {
                Custominis.Add($"{TBCustomini.Text}");
                CustomFiles.Items.Clear();
                foreach (var item in Custominis)
                {
                    CustomFiles.Items.Add(item);
                }
                Save();
            }
            else if (File.Exists($"{TBCustomini.Text}"))
            {
                Custominis.Add($"{TBCustomini.Text}");
                CustomFiles.Items.Clear();
                foreach (var item in Custominis)
                {
                    CustomFiles.Items.Add(item);
                }
                Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK) { TBServerLocation.Text = folder.SelectedPath; }
        }

        private void CustomFiles_Click(object sender, EventArgs e)
        {
            if (CustomFiles.SelectedItem != null)
            {
                if (File.Exists($"{serverLocation}//KFGame//Config//{CustomFiles.SelectedItem.ToString()}"))
                {
                    
                }
                else if (File.Exists(CustomFiles.SelectedItem.ToString()))
                {

                }
            }
        }

        private void LBKFWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists($"{serverLocation}//KFGame//Config//KFWeb.ini"))
            {
                Process.Start($"{serverLocation}//KFGame//Config//KFWeb.ini");
            }
        }

        private void LBKFEngine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini"))
            {
                Process.Start($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini");
            }
        }

        private void LBKFGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini"))
            {
                Process.Start($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini");
            }
        }

        private void LBServerLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try { Process.Start(serverLocation); }
            catch { }
        }

        private void KFGameBackup_Click(object sender, EventArgs e)
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

        private void KFEngineBackup_Click(object sender, EventArgs e)
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

        private void KFWebBackup_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{serverLocation}//KFGame//Config//KFWebBackup.ini"))
            {
                Form OverWrite = new Overwrite($"{serverLocation}//KFGame//Config//KFWeb.ini", $"{serverLocation}//KFGame//Config//KFWebBackup.ini");
                OverWrite.Show();
            }
            else
            {
                File.Copy($"{serverLocation}//KFGame//Config//KFWeb.ini", $"{serverLocation}//KFGame//Config//KFWebBackup.ini", false);
            }
        }

        private void Custominilabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try { Process.Start($"{serverLocation}//KFGame//Config//"); }
            catch { }
        }

        private void ButGamePasswordShow_Click(object sender, EventArgs e)
        {
            if (TBGamePassword.PasswordChar.ToString() == "*")
            {
                TBGamePassword.PasswordChar = '\0';
                ButGamePasswordShow.Name = "Hide Password";
            }
            else
            {
                TBGamePassword.PasswordChar = '*';
                ButGamePasswordShow.Name = "Show Password";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TBWebPassword.PasswordChar.ToString() == "*")
            {
                TBWebPassword.PasswordChar = '\0';
                button2.Name = "Hide Password";
            }
            else
            {
                TBWebPassword.PasswordChar = '*';
                button2.Name = "Show Password";
            }
        }
        private void Replace(string file, string word, string replace)
        {
            if (File.Exists(file))
            {
                int origfilelines = 0;
                foreach (var line in File.ReadAllLines(file))
                {
                    origfilelines++;
                }
                string[] origfile = new string[origfilelines];
                int counter = 0;
                foreach (var line in File.ReadAllLines(file))
                {
                    origfile[counter] = line;
                    counter++;
                }
                for (int i = 0; i < origfile.Length; i++)
                {
                    if (origfile[i].StartsWith(word))
                    {
                        origfile[i] = replace;
                    }

                }
                using (StreamWriter sw = new StreamWriter(file))
                {
                    foreach (var item in origfile)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
        }
        private string GetValue(string file, string word)
        {
            string value = null;
            if (File.Exists(file))
            {
                int origfilelines = 0;
                foreach (var line in File.ReadAllLines(file))
                {
                    origfilelines++;
                }
                string[] origfile = new string[origfilelines];
                int counter = 0;
                foreach (var line in File.ReadAllLines(file))
                {
                    origfile[counter] = line;
                    counter++;
                }
                for (int i = 0; i < origfile.Length; i++)
                {
                    if (origfile[i].StartsWith(word))
                    {
                        value = origfile[i].Replace(word,"").Trim();
                    }
                }
            }
            return value;
        }

        private void ButServerPort_Click(object sender, EventArgs e)
        {
            if(TBServerPort.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini", "Port=", $"Port={TBServerPort}");
            }
        }

        private void ButServerPeerPort_Click(object sender, EventArgs e)
        {
            if (TBServerPeerPort.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//PCServer-KFEngine.ini", "PeerPort=", $"PeerPort={TBServerPeerPort.Text}");
            }
        }

        private void ButServerGameName_Click(object sender, EventArgs e)
        {
            if (TBServerGameName.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "ServerName=", $"ServerName={TBServerGameName.Text}");
            }
        }

        private void ButWebAdminEnabled_Click(object sender, EventArgs e)
        {
            if (CBWebAdminEnabled.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//KFWeb.ini", "bEnabled=", $"bEnabled={CBWebAdminEnabled.Text}");
            }
        }

        private void ButWebPort_Click(object sender, EventArgs e)
        {
            if (TBWebPort.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//KFWeb.ini", "ListenPort=", $"ListenPort={TBWebPort.Text}");
            }
        }

        private void ButWebPassword_Click(object sender, EventArgs e)
        {
            if (TBWebPassword.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "AdminPassword=", $"AdminPassword={TBWebPassword.Text}");
            }
        }

        private void ButGameMaxPlayers_Click(object sender, EventArgs e)
        {
            if (TBGameMaxPlayers.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "MaxPlayers=", $"MaxPlayers={TBGameMaxPlayers.Text}");
            }
        }

        private void ButGameDifficulty_Click(object sender, EventArgs e)
        {
            if (TBGameDifficulty.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "GameDifficulty=", $"GameDifficulty={TBGameDifficulty.Text}");
            }
        }

        private void CBGameDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBGameDifficulty.Text != null)
            {
                if (CBGameDifficulty.Text == "Normal")
                {
                    TBGameDifficulty.Text = "0";
                    TBGameDifficulty.Enabled = false;
                }
                else if (CBGameDifficulty.Text == "Hard")
                {
                    TBGameDifficulty.Text = "1";
                    TBGameDifficulty.Enabled = false;
                }
                else if (CBGameDifficulty.Text == "Suicidal")
                {
                    TBGameDifficulty.Text = "2";
                    TBGameDifficulty.Enabled = false;
                }
                else if (CBGameDifficulty.Text == "Hell On Earth")
                {
                    TBGameDifficulty.Text = "3";
                    TBGameDifficulty.Enabled = false;
                }
                else if (CBGameDifficulty.Text == "Custom")
                {
                    TBGameDifficulty.Enabled = true;
                }
            }
            else
            {
                TBGameDifficulty.Enabled = false;
            }
        }

        private void ButGameLength_Click(object sender, EventArgs e)
        {
            if (CBGameLength.Text != null)
            {
                if (CBGameLength.Text == "Short")
                {
                    Replace($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "GameLength=", "GameLength=0");
                }
                else if (CBGameDifficulty.Text == "Medium")
                {
                    Replace($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "GameLength=", "GameLength=1");
                }
                else if (CBGameDifficulty.Text == "Long")
                {
                    Replace($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "GameLength=", "GameLength=2");
                }
            }
        }

        private void ButGameMode_Click(object sender, EventArgs e)
        {
            if (TBGameMode.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "DefaultGame=", $"DefaultGame={TBGameMode.Text}");
                Replace($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "DefaultServerGame=", $"DefaultServerGame={TBGameMode.Text}");
            }
        }

        private void CBGameMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBGameMode.Text != null)
            {
                if (CBGameMode.Text == "Survival")
                {
                    TBGameMode.Text = "KFGameContent.KFGameInfo_Survival";
                    TBGameMode.Enabled = false;
                }
                else if (CBGameMode.Text == "VS Survival")
                {
                    TBGameMode.Text = "KFGameContent.KFGameInfo_VersusSurvival";
                    TBGameMode.Enabled = false;
                }
                else if (CBGameMode.Text == "Weekly")
                {
                    TBGameMode.Text = "KFGameContent.KFGameInfo_WeeklySurvival";
                    TBGameMode.Enabled = false;
                }
                else if (CBGameMode.Text == "Custom")
                {
                    TBGameMode.Enabled = true;
                }
            }
            else
            {
                TBGameMode.Enabled = false;
            }
        }

        private void ButGamePassword_Click(object sender, EventArgs e)
        {
            if (TBGamePassword.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//PCServer-KFGame.ini", "GamePassword=", $"GamePassword={TBGamePassword.Text}");
            }
        }

        private void CBGameFF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TBGameFF.Text != null)
                {
                    if (float.Parse(TBGameFF.Text) == 0)
                    {
                        CBGameFF.Text = "False";
                        TBGameFF.Enabled = false;
                    }
                    else if (float.Parse(TBGameFF.Text) != 0)
                    {
                        CBGameFF.Text = "True";
                        TBGameFF.Enabled = true;
                    }
                }
            }
            catch
            {
                TBGameFF.Enabled = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBGameVoteKick.Text != null)
            {
                if (CBGameVoteKick.Text == "True")
                {
                    TBGameKick.Text = "0";
                    TBGameKick.Enabled = false;
                }
                else if (CBGameVoteKick.Text == "False")
                {
                    TBGameKick.Enabled = true;
                }
            }
            else
            {
                TBGameKick.Enabled = false;
            }
        }

        private void ButGamePickups_Click(object sender, EventArgs e)
        {
            if (CBGamePickups.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//KFGame.ini", "bDisablePickups=", $"bDisablePickups={CBGamePickups.Text}");
            }
        }

        private void ButGameFF_Click(object sender, EventArgs e)
        {
            if (CBGameFF.Text != null)
            {
                if (CBGameFF.Text == "True")
                {
                    Replace($"{serverLocation}//KFGame//Config//KFGame.ini", "FriendlyFireScale=", $"FriendlyFireScale = {TBGameFF.Text}");
                }
                if (CBGameFF.Text == "False")
                {
                    Replace($"{serverLocation}//KFGame//Config//KFGame.ini", "FriendlyFireScale=", $"FriendlyFireScale = 0");
                }
            }
        }

        private void ButGameCollide_Click(object sender, EventArgs e)
        {
            if (CBGameCollide.Text != null)
            {
                Replace($"{serverLocation}//KFGame//Config//KFGame.ini", "bDisableTeamCollision=", $"bDisableTeamCollision={CBGameCollide.Text}");
            }
        }

        private void ButGameKick_Click(object sender, EventArgs e)
        {
            if (CBGameVoteKick.Text != null)
            {
                if(CBGameVoteKick.Text == "True")
                {
                    Replace($"{serverLocation}//KFGame//Config//KFGame.ini", "bDisableKickVote =", $"bDisableKickVote = True");
                }
                if (CBGameVoteKick.Text == "False")
                {
                    Replace($"{serverLocation}//KFGame//Config//KFGame.ini", "bDisableKickVote=", $"bDisableKickVote = False");
                    Replace($"{serverLocation}//KFGame//Config//KFGame.ini", "KickVotePercentage=", $"KickVotePercentage = {TBGameKick.Text}");
                }
            }
        }

        private void TBGameDifficulty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(TBGameDifficulty.Text) == 0)
                {
                    CBGameDifficulty.Text = "Normal";
                }
                else if (float.Parse(TBGameDifficulty.Text) == 1)
                {
                    CBGameDifficulty.Text = "Hard";
                }
                else if (float.Parse(TBGameDifficulty.Text) == 2)
                {
                    CBGameDifficulty.Text = "Suicidal";
                }
                else if (float.Parse(TBGameDifficulty.Text) == 3)
                {
                    CBGameDifficulty.Text = "Hell On Earth";
                }
                else
                {
                    CBGameDifficulty.Text = "Custom";
                }
            }
            catch
            {
                CBGameDifficulty.Text = "Error";
            }
        }

        private void TBGameMode_TextChanged(object sender, EventArgs e)
        {
            if (TBGameMode.Text == "KFGameContent.KFGameInfo_Survival")
            {
                CBGameMode.Text = "Survival";
                TBGameMode.Enabled = false;
            }
            else if (TBGameMode.Text == "KFGameContent.KFGameInfo_VersusSurvival")
            {
                CBGameMode.Text = "VS Survival";
                TBGameMode.Enabled = false;
            }
            else if (TBGameMode.Text == "KFGameContent.KFGameInfo_WeeklySurvival")
            {
                CBGameMode.Text = "Weekly";
                TBGameMode.Enabled = false;
            }
            else
            {
                CBGameMode.Text = "Custom";
                TBGameMode.Enabled = true;
            }
        }

        private void TBGameFF_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(TBGameFF.Text) >= 0)
                {
                    CBGameFF.Text = "True";
                }
                else if (float.Parse(TBGameFF.Text) < 0)
                {
                    CBGameFF.Text = "False";
                }
            }
            catch
            {
                CBGameFF.Text = "Error";
            }

        }

        private void CustomFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}