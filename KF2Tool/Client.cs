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
    public partial class Client : Form
    {
        private string map;
        private string muts;
        private string game;
        private string customGame;
        private string length;
        private string difficulty;
        private string customDifficulty;
        private int sleeptime = 3;
        ServerData Data;
        KFGame KFGame = new KFGame();
        Collection<string> MutatorCollection = new Collection<string>();
        private string gameLocation;
        private string SteamLocation;
        bool gameFound = false;
        Collection<string> Custominis = new Collection<string>();

        public Client()
        {
            InitializeComponent();
        }

        private void Save(int check)
        {
            if(check == 1 || check == 3)
            {
                Data.gameLocation = gameLocation;
            }
            if (check == 2 || check == 3)
            {
                Data.steamLocation = SteamLocation;
            }
            Data.Gameinis = null;
            Data.Gameinis = new string[Custominis.Count];
            for (int i = 0; i < Custominis.Count; i++)
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
            if (Data.gameLocation != null)
            {
                TBGameLocation.Text = Data.gameLocation;
            }
            else
            {
                TBGameLocation.Text = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\My Games\\KillingFloor2\\";
            }
            if (Data.steamLocation != null)
            {
                TBSteamLocation.Text = Data.steamLocation;
                SteamLocation = Data.steamLocation;
            }
            else
            {
                if (File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86)}\\Steam\\Steam.exe"))
                {
                    TBSteamLocation.Text = $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86)}\\Steam\\Steam.exe";
                }
            }

            foreach (var item in Data.Gameinis)
            {
                CustomFiles.Items.Add(item);
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {
            Data = InitialLoad();
            LoadData();
            Loadmuts();
            foreach (var item in Custominis)
            {
                CustomFiles.Items.Add(item);
            }
            foreach (var item in KFGame.GetMaps(gameLocation))
            {
                CBMaps.Items.Add(item);
            }
            foreach (var item in MutatorCollection)
            {
                LBMutators.Items.Add(item);
            }

        }

        private void Loadmuts()
        {
            MutatorCollection.Clear();
            if (File.Exists($"{Application.StartupPath}\\ClientConfig.txt"))
            {
                foreach (var line in File.ReadAllLines($"{Application.StartupPath}\\ClientConfig.txt"))
                {
                    if (line.StartsWith("Mut=")) { MutatorCollection.Add(line.Replace("Mut=", "").Trim()); }
                    if (line.StartsWith("Game=")) { customGame = line.Replace("Game=", "").Trim(); }
                    if (line.StartsWith("Diff=")) { customDifficulty = line.Replace("Diff=", "").Trim(); }
                }
            }
            else
            {
                string[] tmp = new string[] { "/Mutators/ - supposrts multiple", "Mut=", "/GameMode/ - only supports one input", "Game=", "/CustomDifficulty/ - only supports one input", "Diff=" };
                File.WriteAllLines($"{Application.StartupPath}\\ClientConfig.txt",tmp);
            }
        }

        private void ButGameLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK) { TBGameLocation.Text = folder.SelectedPath; }
        }

        private void TBGameLocation_TextChanged(object sender, EventArgs e)
        {
            gameLocation = TBGameLocation.Text;
            if (Directory.Exists($"{gameLocation}\\KFGame"))
            {
                GameLocationOK.Text = "OK";
                GameLocationOK.ForeColor = Color.Green;
                gameFound = true;
            }
            else
            {
                GameLocationOK.Text = "NOT OK";
                GameLocationOK.ForeColor = Color.Red;
            }
            if (File.Exists($"{gameLocation}//KFGame//Config//KFGame.ini"))
            {
                KFGameOK.Text = "OK";
                KFGameOK.ForeColor = Color.Green;
            }
            else
            {
                KFGameOK.Text = "NOT OK";
                KFGameOK.ForeColor = Color.Red;
            }
            if (File.Exists($"{gameLocation}//KFGame//Config//KFEngine.ini"))
            {
                KFEngineOK.Text = "OK";
                KFEngineOK.ForeColor = Color.Green;
            }
            else
            {
                KFEngineOK.Text = "NOT OK";
                KFEngineOK.ForeColor = Color.Red;
            }
            if (File.Exists($"{gameLocation}//KFGame//Config//KFSystemSettings.ini"))
            {
                KFEngineOK.Text = "OK";
                KFEngineOK.ForeColor = Color.Green;
            }
            else
            {
                KFEngineOK.Text = "NOT OK";
                KFEngineOK.ForeColor = Color.Red;
            }
            Save(1);
        }

        private void Custominilabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try { Process.Start($"{gameLocation}//KFGame//Config//"); }
            catch { }
        }

        private void ButAddCustomini_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{gameLocation}//KFGame//Config//{TBCustomini.Text}"))
            {
                Custominis.Add($"{TBCustomini.Text}");
                CustomFiles.Items.Clear();
                foreach (var item in Custominis)
                {
                    CustomFiles.Items.Add(item);
                }
                Save(3);
            }
            else if (File.Exists($"{TBCustomini.Text}"))
            {
                Custominis.Add($"{TBCustomini.Text}");
                CustomFiles.Items.Clear();
                foreach (var item in Custominis)
                {
                    CustomFiles.Items.Add(item);
                }
                Save(3);
            }
        }

        private void KFGameBackup_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{gameLocation}//KFGame//Config//KFGameBackup.ini"))
            {
                Form OverWrite = new Overwrite($"{gameLocation}//KFGame//Config//KFGame.ini", $"{gameLocation}//KFGame//Config//KFGameBackup.ini");
                OverWrite.Show();
            }
            else
            {
                File.Copy($"{gameLocation}//KFGame//Config//KFGame.ini", $"{gameLocation}//KFGame//Config//KFGameBackup.ini", false);
            }
        }

        private void KFEngineBackup_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{gameLocation}//KFGame//Config//KFEngineBackup.ini"))
            {
                Form OverWrite = new Overwrite($"{gameLocation}//KFGame//Config//KFEngine.ini", $"{gameLocation}//KFGame//Config//KFEngineBackup.ini");
                OverWrite.Show();
            }
            else
            {
                File.Copy($"{gameLocation}//KFGame//Config//KFEngine.ini", $"{gameLocation}//KFGame//Config//KFEngineBackup.ini", false);
            }
        }

        private void ButStartGame_Click(object sender, EventArgs e)
        {
            SetVariables();
            try { Process.Start($"{SteamLocation}\\Steam.exe", "-applaunch 232090 -nomoviestartup -USEALLAVAILABLECORES"); }
            catch { }
            System.Threading.Thread.Sleep(sleeptime * 60000);
            RunMap();
        }

        private void SetVariables()
        {
            muts = "?mutators=";
            if (LBMutators.CheckedItems.Count > 1)
            {
                foreach (var item in LBMutators.CheckedItems)
                {
                    muts = muts + item + ",";
                }
            }
            else if (LBMutators.CheckedItems.Count == 1)
            {
                foreach (var item in LBMutators.CheckedItems)
                {
                    muts = muts + item;
                }
            }
            else if (LBMutators.CheckedItems.Count == 0)
            {
                muts = null;
            }

            if (CBMaps.SelectedText != null) { map = CBMaps.Text; }
            else { map = "KF-Outpost"; }

            if (CBGameMode.SelectedText == "Custom") { game = customGame; }
            else if (CBGameMode.SelectedText == "Survival") { game = "KFGameContent.KFGameInfo_Survival"; }
            else if (CBGameMode.SelectedText == "VS Survival") { game = "KFGameContent.KFGameInfo_VersusSurvival"; }
            else if (CBGameMode.SelectedText == "Weekly") { game = "KFGameContent.KFGameInfo_WeeklySurvival"; }
            else { game = "KFGameContent.KFGameInfo_Survival"; }

            if (CBDifficulty.SelectedText == "Custom") { difficulty = customDifficulty; }
            else if (CBDifficulty.SelectedText == "Normal") { difficulty = "0"; }
            else if (CBDifficulty.SelectedText == "Hard") { difficulty = "1"; }
            else if (CBDifficulty.SelectedText == "Suicidal") { difficulty = "2"; }
            else if (CBDifficulty.SelectedText == "Hell On Earth") { difficulty = "3"; }
            else { difficulty = "0"; }

            if (CBLength.SelectedText == "Short") { length = "0"; }
            else if (CBLength.SelectedText == "Medium") { length = "1"; }
            else if (CBLength.SelectedText == "Long") { length = "2"; }
            else { length = "0"; }
        }

        private void RunMap()
        {
            System.Threading.Thread.Sleep(5000);
            SendKeys.Send("{F3}");
            System.Threading.Thread.Sleep(1000);
            SendKeys.Send($"open {map}?game={game}?difficulty={difficulty}?length={length}{muts}");
            System.Threading.Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");
        }

        private void ButSteamLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK) { TBSteamLocation.Text = folder.SelectedPath; }
        }

        private void TBSteamLocation_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists($"{TBSteamLocation.Text}\\steam.exe"))
            {
                SteamLocationOK.Text = "OK";
                SteamLocationOK.ForeColor = Color.Green;
            }
            else
            {
                SteamLocationOK.Text = "NOT OK";
                SteamLocationOK.ForeColor = Color.Red;
            }
            SteamLocation = TBSteamLocation.Text;
            Save(2);
        }

        private void LBGameLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try { Process.Start(gameLocation); }
            catch { }
        }

        private void LBKFGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists($"{gameLocation}//KFGame//Config//KFGame.ini"))
            {
                Process.Start($"{gameLocation}//KFGame//Config//KFGame.ini");
            }
        }

        private void LBKFEngine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists($"{gameLocation}//KFGame//Config//KFEngine.ini"))
            {
                Process.Start($"{gameLocation}//KFGame//Config//KFEngine.ini");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[,] tmp = new string[,] { { "MaxDeadBodies", TBMaxDeadBodies.Text } };
            if (File.Exists($"{gameLocation}//KFGame//Config//KFGame.ini")&& TBMaxDeadBodies.Text != null)
            {
                SetConfig($"{gameLocation}//KFGame//Config//KFGame.ini", tmp);
            }
        }

        private void ButTextureStreaming_Click(object sender, EventArgs e)
        {
            string[,] tmp = new string[,] { { "bUseTextureStreaming", CBTextureStreaming.Text } };
            if (File.Exists($"{gameLocation}//KFGame//Config//KFEngine.ini") && (CBTextureStreaming.Text.ToLower() == "true" || CBTextureStreaming.Text.ToLower() == "false"))
            {
                SetConfig($"{gameLocation}//KFGame//Config//KFEngine.ini", tmp);
            }
        }

        private void SetConfig(string file, string[,] ChangelineAndValue)
        {
            string changeline;
            string value;
            string[] fileArray = File.ReadLines(file).ToArray();
            for (int i = 0; i < fileArray.Length; i++)
            {
                for (int rows = 0; rows < ChangelineAndValue.GetLength(0); rows++)
                {
                    changeline = ChangelineAndValue[rows, 0];
                    value = ChangelineAndValue[rows, 1];
                    if (fileArray[i].StartsWith(changeline + "="))
                    {
                        fileArray[i] = changeline + "=" + value;
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (var item in fileArray)
                {
                    sw.WriteLine(item);
                }
            }
            }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists($"{gameLocation}//KFGame//Config//KFSystemSettings.ini"))
            {
                Process.Start($"{gameLocation}//KFGame//Config//KFSystemSettings.ini");
            }
        }

        private void ButKFSystemSettings_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{gameLocation}//KFGame//Config//KFSystemSettingsBackup.ini"))
            {
                Form OverWrite = new Overwrite($"{gameLocation}//KFGame//Config//KFSystemSettings.ini", $"{gameLocation}//KFGame//Config//KFSystemSettingsBackup.ini");
                OverWrite.Show();
            }
            else
            {
                File.Copy($"{gameLocation}//KFGame//Config//KFSystemSettings.ini", $"{gameLocation}//KFGame//Config//KFSystemSettingsBackup.ini", false);
            }
        }

        private void CBPerformancePlus_CheckedChanged(object sender, EventArgs e)
        {
            if (CBPerformancePlus.Checked == true && File.Exists($"{gameLocation}//KFGame//Config//KFSystemSettings.ini") && File.Exists($"{gameLocation}//KFGame//Config//KFEngine.ini") && File.Exists($"{gameLocation}//KFGame//Config//KFGame.ini"))
            {
                string[,] KFSystemSettings = new string[,] {
                { "DynamicShadows", "False" },
                { "UpscaleScreenPercentage", "True"},
                { "MinShadowResolution", "1"},
                { "MinPreShadowResolution", "0"},
                { "MaxShadowResolution", "1"},
                { "MobileShadowTextureResolution", "1"},
                { "MaxWholeSceneDominantShadowResolution", "1"},
                { "ShadowFadeResolution", "0"},
                { "PreShadowFadeResolution", "0"},
                { "ShadowTexelsPerPixel", "0"},
                { "bAllowHardwareShadowFiltering", "False"},
                { "GlobalShadowDistanceScale", "0.0"},
                { "AllowBooleanPreshadows", "False"},
                { "MaxPrimBoundsForPerObjectShadows", "0.0"},
                { "AllowPersistentSplats", "False"},
                { "AllowSecondaryBloodEffects", "False"}
                };

                string[,] KFGame = new string[,] { 
                { "MaxExplosionDecals", "0"},
                {"BloodPoolDelay", "0"},
                {"GoreFXLifetimeMultiplier", "0.0"},
                {"BodyWoundDecalLifetime", "0.0"},
                {"BloodSplatterLifetime", "0.0"},
                {"BloodPoolLifetime", "0.0"},
                {"GibletLifetime", "0.0"},
                {"MaxBodyWoundDecals", "0.0"},
                {"MaxBloodSplatterDecals", "0.0"},
                {"MaxBloodPoolDecals", "0.0"},
                {"BloodSplatSize", "0.0"},
                {"BloodPoolSize", "0.0"},
                {"MaxDeadBodies", "0.0"},
                {"MaxBloodEffects", "0.0"},
                {"MaxGoreEffects", "0.0"},
                {"AllowBloodSplatterDecals", "False"},
                {"PersistentSplatTraceLength", "0.0"},
                {"MaxPersistentSplatsPerFrame", "0.0"},
                {"GoreLevel", "0"},
                {"MaxFluidNumVerts", "64"},
                {"MaxParticleResize", "532"},
                {"MaxParticleVertexMemory", "64"},
                {"ShellEjectLifetime", "0.000000"}};

                string[,] KFEngine = new string[,] {
                {"MaxParticleVertexMemory", "1"},
                {"ParticlePercentage", "0"},
                {"bShouldGenerateSimpleLightmaps", "False"},
                {"bUseNormalMapsForSimpleLightMaps", "False"},
                {"MaxFluidNumVerts", "1"},
                {"MaxParticleResize", "532"},
                {"MaxParticleResizeWarn", "0"},
                {"MaxParticleVertexMemory", "64"}
                };

                SetConfig($"{gameLocation}//KFGame//Config//KFGame.ini",KFGame);
                SetConfig($"{gameLocation}//KFGame//Config//KFEngine.ini",KFEngine);
                SetConfig($"{gameLocation}//KFGame//Config//KFSystemSettings.ini", KFSystemSettings);
                CBPerformancePlusPlus.Enabled = true;
            }
            else
            {
                CBPerformancePlusPlus.Enabled = false;
            }
        }

        private void CBPerformance_CheckedChanged(object sender, EventArgs e)
        {
            if (CBPerformance.Checked == true && File.Exists($"{gameLocation}//KFGame//Config//KFSystemSettings.ini") && File.Exists($"{gameLocation}//KFGame//Config//KFEngine.ini") && File.Exists($"{gameLocation}//KFGame//Config//KFGame.ini"))
            {
                string[,] KFSystemSettings = new string[,] {
                {"StaticDecals", "False"},
                {"DynamicDecals", "False"},
                {"UnbatchedDecals", "False"},
                {"DropParticleDistortion", "False"},
                {"SpeedTreeLeaves", "False"},
                {"SpeedTreeFronds", "False"},
                {"OnlyStreamInTextures", "True"},
                {"FogVolumes", "False"},
                {"FloatingPointRenderTargets", "False"},
                {"AllowRadialBlur", "False"},
                {"AllowImageReflections", "False"},
                {"AllowImageReflectionShadowing", "False"},
                {"bAllowHighQualityMaterials", "False"},
                {"MaxDrawDistanceScale", "0.800000"},
                {"ScreenPercentage", "90.000000"},
                {"bAllowFracturedDamage", "False"},
                {"UseComputeSSR", "False"},
                {"ImageGrainScaler", "0.000000"},
                {"AllowBooleanPreshadows", "False"},
                {"UseNewDOF", "False"},
                {"DistanceFog", "False"},
                {"MotionBlurStaticScale", "0.0"},
                {"MotionBlurDynamicScale", "0.0"},
                {"UpscaleScreenPercentage", "True"}};

                string[,] KFEngine = new string[,] {
                {"ImageReflectionTextureSize", "512"},
                {"bStaticDecalsEnabled", "False"},
                {"bDynamicDecalsEnabled", "False"},
                {"bUseTextureStreaming", "False"},
                {"MaxFluidNumVerts", "1"},
                {"MipFadeInSpeed0", "0.0"},
                {"MipFadeOutSpeed0", "0.0"},
                {"MipFadeInSpeed1", "0.0"},
                {"MipFadeOutSpeed1", "0.0"},
                {"bSmoothFrameRate", "False"},
                {"MinSmoothedFrameRate", "30"},
                {"MaxSmoothedFrameRate", "60"},
                {"MinDesiredFrameRate", "35"},
                {"BoostPlayerTextures", "0.0"},
                {"ParticlePercentage", "80"}};

                string[,] KFGame = new string[,] {
                {"DecalLifeSpan", "0.0"},
                {"MaxImpactEffectDecals", "0"},
                {"ShellEjectLifetime", "0.5"}};
                
                SetConfig($"{gameLocation}//KFGame//Config//KFSystemSettings.ini", KFSystemSettings);
                SetConfig($"{gameLocation}//KFGame//Config//KFEngine.ini", KFEngine);
                SetConfig($"{gameLocation}//KFGame//Config//KFGame.ini", KFGame);
                CBPerformancePlus.Enabled = true;
            }
            else
            {
                CBPerformancePlus.Enabled = false;
            }
        }

        private void LBPerformancePlusPlus_CheckedChanged(object sender, EventArgs e)
        {
            if (CBPerformance.Checked == true && CBPerformancePlus.Checked == true && File.Exists($"{gameLocation}//KFGame//Config//KFSystemSettings.ini"))
            {
                string MaxLODSize = "0";
                string LODBias = "10";
                char[] characterarray = new char[] { '(', ',', ')' };
                string file = $"{gameLocation}//KFGame//Config//KFSystemSettings.ini";
                string[,] KFSystemSettings = new string[,] {
{ "TEXTUREGROUP_World","(MinLODSize=1,MaxLODSize=4096,LODBias=-1,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_WorldNormalMap","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_WorldSpecular","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Character","(MinLODSize=1,MaxLODSize=4096,LODBias=-1,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_CharacterNormalMap","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_CharacterSpecular","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Weapon","(MinLODSize=1,MaxLODSize=4096,LODBias=-1,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_WeaponNormalMap","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_WeaponSpecular","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Vehicle","(MinLODSize=1,MaxLODSize=4096,LODBias=-1,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_VehicleNormalMap","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_VehicleSpecular","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Cinematic","(MinLODSize=1,MaxLODSize=4096,LODBias=-1,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Effects","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=linear,MipFilter=point)"},
{ "TEXTUREGROUP_EffectsNotFiltered","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Skybox","(MinLODSize=1,MaxLODSize=4096,LODBias=-1,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_UI","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Lightmap","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Shadowmap","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point,NumStreamedMips=3)"},
{ "TEXTUREGROUP_RenderTarget","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_MobileFlattened","(MinLODSize=1,MaxLODSize=1024,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_ProcBuilding_LightMap","(MinLODSize=1,MaxLODSize=256,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Terrain_Heightmap","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Terrain_Weightmap","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_ImageBasedReflection","(MinLODSize=256,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=linear,MipGenSettings=TMGS_Blur5)"},
{ "TEXTUREGROUP_Bokeh","(MinLODSize=1,MaxLODSize=256,LODBias=0,MinMagFilter=linear,MipFilter=linear)"},
{ "TEXTUREGROUP_Creature","(MinLODSize=1,MaxLODSize=4096,LODBias=-1,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_CreatureNormalMap","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_CreatureSpecular","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Weapon3rd","(MinLODSize=1,MaxLODSize=4096,LODBias=-1,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Weapon3rdNormalMap","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Weapon3rdSpecular","(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_Cosmetic", "(MinLODSize=1,MaxLODSize=4096,LODBias=-1,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_CosmeticNormalMap", "(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},
{ "TEXTUREGROUP_CosmeticSpecular", "(MinLODSize=1,MaxLODSize=4096,LODBias=0,MinMagFilter=aniso,MipFilter=point)"},

};
                string[] fileArray = File.ReadLines(file).ToArray();
                for (int i = 0; i < fileArray.Length; i++)
                {
                    if (fileArray[i].StartsWith("TEXTUREGROUP_UI") || fileArray[i].StartsWith("TEXTUREGROUP_ColorLookupTable") || fileArray[i].StartsWith("TEXTUREGROUP_Bokeh"))
                    {

                    }
                    else if (fileArray[i].StartsWith("TEXTUREGROUP_"))
                    {
                        string[] tmp = fileArray[i].Split(characterarray,StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < tmp.Length; j++)
                        {
                            if (tmp[j].StartsWith("MinMagFilter=Linear"))
                            {
                                tmp[j] = "MinMagFilter=Point";
                            }
                            if (tmp[j].StartsWith("MaxLODSize="))
                            {
                                tmp[j] = $"MaxLODSize={MaxLODSize}";
                            }
                            if (tmp[j].StartsWith("LODBias="))
                            {
                                tmp[j] = $"LODBias={LODBias}";
                            }
                        }
                        fileArray[i] = tmp[0] + "(";
                        for (int k = 1; k < (tmp.Length-1); k++)
                        {
                            fileArray[i] = fileArray[i] + tmp[k] + ",";
                        }
                        fileArray[i] = fileArray[i] + tmp[(tmp.Length - 1)] + ")";
                    }
                }
                using(StreamWriter sr = new StreamWriter(file))
                {
                    foreach (var item in fileArray)
                    {
                        sr.WriteLine(item);
                    }
                }

            }
            else
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                string[,] KFSystemSettings = new string[,] {
                { "DynamicLights", "False"},
                { "LightEnvironmentShadows", "False"},
                { "CompositeDynamicLights", "False"},
                { "SHSecondaryLighting", "False"},
                { "DirectionalLightmaps", "False"},
                { "MaxOverlappingLights", "0"},
                { "AllowLightOcclusionQueries", "False"},
                { "VolumetricLightingMode", "0"} };
                SetConfig($"{gameLocation}//KFGame//Config//KFSystemSettings.ini", KFSystemSettings);
            }
            else if (checkBox1.Checked == false)
            {
                string[,] KFSystemSettings = new string[,] {
                { "DynamicLights", "True"},
                { "LightEnvironmentShadows", "True"},
                { "CompositeDynamicLights", "True"},
                { "SHSecondaryLighting", "True"},
                { "DirectionalLightmaps", "True"},
                { "MaxOverlappingLights", "15"},
                { "AllowLightOcclusionQueries", "True"},
                { "VolumetricLightingMode", "1"} };
                SetConfig($"{gameLocation}//KFGame//Config//KFSystemSettings.ini", KFSystemSettings);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
