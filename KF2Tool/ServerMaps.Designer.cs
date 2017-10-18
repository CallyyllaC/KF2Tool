namespace KF2Tool
{
    partial class ServerMaps
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LBTitle = new System.Windows.Forms.Label();
            this.LBServerLocation = new System.Windows.Forms.LinkLabel();
            this.TBServerLocation = new System.Windows.Forms.TextBox();
            this.ButServerLocation = new System.Windows.Forms.Button();
            this.ServerLocationOK = new System.Windows.Forms.Label();
            this.KFGameOK = new System.Windows.Forms.Label();
            this.LBKFGame = new System.Windows.Forms.LinkLabel();
            this.ButAddMaps = new System.Windows.Forms.Button();
            this.ButBackupKFGame = new System.Windows.Forms.Button();
            this.KFEngineOK = new System.Windows.Forms.Label();
            this.LBKFEngine = new System.Windows.Forms.LinkLabel();
            this.ButBackupKFEngine = new System.Windows.Forms.Button();
            this.TBMaps = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButSearch = new System.Windows.Forms.Button();
            this.LBSearch = new System.Windows.Forms.Label();
            this.ButHome = new System.Windows.Forms.Button();
            this.TBSearch = new System.Windows.Forms.TextBox();
            this.ButWorkshopAdd = new System.Windows.Forms.Button();
            this.ButForward = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ButBack = new System.Windows.Forms.Button();
            this.TBWorkshopAdd = new System.Windows.Forms.TextBox();
            this.LBWorkshop = new System.Windows.Forms.ListBox();
            this.WorkShopBrowser = new System.Windows.Forms.WebBrowser();
            this.WorkShopCollection = new System.Windows.Forms.DomainUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBTitle
            // 
            this.LBTitle.AutoSize = true;
            this.LBTitle.Location = new System.Drawing.Point(13, 13);
            this.LBTitle.Name = "LBTitle";
            this.LBTitle.Size = new System.Drawing.Size(50, 13);
            this.LBTitle.TabIndex = 0;
            this.LBTitle.Text = "KF2 Tool";
            // 
            // LBServerLocation
            // 
            this.LBServerLocation.AutoSize = true;
            this.LBServerLocation.Location = new System.Drawing.Point(13, 30);
            this.LBServerLocation.Name = "LBServerLocation";
            this.LBServerLocation.Size = new System.Drawing.Size(82, 13);
            this.LBServerLocation.TabIndex = 1;
            this.LBServerLocation.TabStop = true;
            this.LBServerLocation.Text = "Server Location";
            this.LBServerLocation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LBServerLocation_LinkClicked);
            // 
            // TBServerLocation
            // 
            this.TBServerLocation.Location = new System.Drawing.Point(16, 47);
            this.TBServerLocation.Name = "TBServerLocation";
            this.TBServerLocation.Size = new System.Drawing.Size(419, 20);
            this.TBServerLocation.TabIndex = 2;
            this.TBServerLocation.TextChanged += new System.EventHandler(this.TBServerLocation_TextChanged);
            // 
            // ButServerLocation
            // 
            this.ButServerLocation.Location = new System.Drawing.Point(441, 45);
            this.ButServerLocation.Name = "ButServerLocation";
            this.ButServerLocation.Size = new System.Drawing.Size(65, 23);
            this.ButServerLocation.TabIndex = 3;
            this.ButServerLocation.Text = "Browse";
            this.ButServerLocation.UseVisualStyleBackColor = true;
            this.ButServerLocation.Click += new System.EventHandler(this.ServerLocation_Click);
            // 
            // ServerLocationOK
            // 
            this.ServerLocationOK.AutoSize = true;
            this.ServerLocationOK.Location = new System.Drawing.Point(101, 30);
            this.ServerLocationOK.Name = "ServerLocationOK";
            this.ServerLocationOK.Size = new System.Drawing.Size(29, 13);
            this.ServerLocationOK.TabIndex = 4;
            this.ServerLocationOK.Text = "Wait";
            this.ServerLocationOK.Click += new System.EventHandler(this.ServerLocationOK_Click);
            // 
            // KFGameOK
            // 
            this.KFGameOK.AutoSize = true;
            this.KFGameOK.Location = new System.Drawing.Point(74, 79);
            this.KFGameOK.Name = "KFGameOK";
            this.KFGameOK.Size = new System.Drawing.Size(29, 13);
            this.KFGameOK.TabIndex = 5;
            this.KFGameOK.Text = "Wait";
            // 
            // LBKFGame
            // 
            this.LBKFGame.AutoSize = true;
            this.LBKFGame.Location = new System.Drawing.Point(13, 79);
            this.LBKFGame.Name = "LBKFGame";
            this.LBKFGame.Size = new System.Drawing.Size(48, 13);
            this.LBKFGame.TabIndex = 6;
            this.LBKFGame.TabStop = true;
            this.LBKFGame.Text = "KFGame";
            this.LBKFGame.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LBKFGame_LinkClicked);
            // 
            // ButAddMaps
            // 
            this.ButAddMaps.Location = new System.Drawing.Point(6, 537);
            this.ButAddMaps.Name = "ButAddMaps";
            this.ButAddMaps.Size = new System.Drawing.Size(279, 23);
            this.ButAddMaps.TabIndex = 9;
            this.ButAddMaps.Text = "Add Found Maps To KFGame.ini";
            this.ButAddMaps.UseVisualStyleBackColor = true;
            this.ButAddMaps.Click += new System.EventHandler(this.AddMaps_Click);
            // 
            // ButBackupKFGame
            // 
            this.ButBackupKFGame.Location = new System.Drawing.Point(266, 74);
            this.ButBackupKFGame.Name = "ButBackupKFGame";
            this.ButBackupKFGame.Size = new System.Drawing.Size(117, 23);
            this.ButBackupKFGame.TabIndex = 11;
            this.ButBackupKFGame.Text = "Backup KFGame.ini";
            this.ButBackupKFGame.UseVisualStyleBackColor = true;
            this.ButBackupKFGame.Click += new System.EventHandler(this.BackupKFGame_Click);
            // 
            // KFEngineOK
            // 
            this.KFEngineOK.AutoSize = true;
            this.KFEngineOK.Location = new System.Drawing.Point(168, 79);
            this.KFEngineOK.Name = "KFEngineOK";
            this.KFEngineOK.Size = new System.Drawing.Size(29, 13);
            this.KFEngineOK.TabIndex = 12;
            this.KFEngineOK.Text = "Wait";
            // 
            // LBKFEngine
            // 
            this.LBKFEngine.AutoSize = true;
            this.LBKFEngine.Location = new System.Drawing.Point(109, 79);
            this.LBKFEngine.Name = "LBKFEngine";
            this.LBKFEngine.Size = new System.Drawing.Size(53, 13);
            this.LBKFEngine.TabIndex = 13;
            this.LBKFEngine.TabStop = true;
            this.LBKFEngine.Text = "KFEngine";
            this.LBKFEngine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LBKFEngine_LinkClicked);
            // 
            // ButBackupKFEngine
            // 
            this.ButBackupKFEngine.Location = new System.Drawing.Point(389, 74);
            this.ButBackupKFEngine.Name = "ButBackupKFEngine";
            this.ButBackupKFEngine.Size = new System.Drawing.Size(117, 23);
            this.ButBackupKFEngine.TabIndex = 14;
            this.ButBackupKFEngine.Text = "Backup KFEngine.ini";
            this.ButBackupKFEngine.UseVisualStyleBackColor = true;
            this.ButBackupKFEngine.Click += new System.EventHandler(this.BackupKFEngine_Click);
            // 
            // TBMaps
            // 
            this.TBMaps.Location = new System.Drawing.Point(6, 19);
            this.TBMaps.Name = "TBMaps";
            this.TBMaps.ReadOnly = true;
            this.TBMaps.Size = new System.Drawing.Size(279, 512);
            this.TBMaps.TabIndex = 15;
            this.TBMaps.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBMaps);
            this.groupBox1.Controls.Add(this.ButAddMaps);
            this.groupBox1.Location = new System.Drawing.Point(16, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 566);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maps";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ButSearch);
            this.groupBox2.Controls.Add(this.LBSearch);
            this.groupBox2.Controls.Add(this.ButHome);
            this.groupBox2.Controls.Add(this.TBSearch);
            this.groupBox2.Controls.Add(this.ButWorkshopAdd);
            this.groupBox2.Controls.Add(this.ButForward);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ButBack);
            this.groupBox2.Controls.Add(this.TBWorkshopAdd);
            this.groupBox2.Controls.Add(this.LBWorkshop);
            this.groupBox2.Controls.Add(this.WorkShopBrowser);
            this.groupBox2.Controls.Add(this.WorkShopCollection);
            this.groupBox2.Location = new System.Drawing.Point(315, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(937, 566);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Workshop";
            // 
            // ButSearch
            // 
            this.ButSearch.Location = new System.Drawing.Point(601, 19);
            this.ButSearch.Name = "ButSearch";
            this.ButSearch.Size = new System.Drawing.Size(75, 23);
            this.ButSearch.TabIndex = 23;
            this.ButSearch.Text = "Find";
            this.ButSearch.UseVisualStyleBackColor = true;
            this.ButSearch.Click += new System.EventHandler(this.ButSearch_Click);
            // 
            // LBSearch
            // 
            this.LBSearch.AutoSize = true;
            this.LBSearch.Location = new System.Drawing.Point(393, 24);
            this.LBSearch.Name = "LBSearch";
            this.LBSearch.Size = new System.Drawing.Size(72, 13);
            this.LBSearch.TabIndex = 22;
            this.LBSearch.Text = "Search by ID:";
            // 
            // ButHome
            // 
            this.ButHome.Location = new System.Drawing.Point(312, 19);
            this.ButHome.Name = "ButHome";
            this.ButHome.Size = new System.Drawing.Size(75, 23);
            this.ButHome.TabIndex = 21;
            this.ButHome.Text = "Home";
            this.ButHome.UseVisualStyleBackColor = true;
            this.ButHome.Click += new System.EventHandler(this.Home_Click);
            // 
            // TBSearch
            // 
            this.TBSearch.Location = new System.Drawing.Point(471, 21);
            this.TBSearch.Name = "TBSearch";
            this.TBSearch.Size = new System.Drawing.Size(124, 20);
            this.TBSearch.TabIndex = 19;
            // 
            // ButWorkshopAdd
            // 
            this.ButWorkshopAdd.Location = new System.Drawing.Point(325, 532);
            this.ButWorkshopAdd.Name = "ButWorkshopAdd";
            this.ButWorkshopAdd.Size = new System.Drawing.Size(75, 23);
            this.ButWorkshopAdd.TabIndex = 6;
            this.ButWorkshopAdd.Text = "Subscribe";
            this.ButWorkshopAdd.UseVisualStyleBackColor = true;
            this.ButWorkshopAdd.Click += new System.EventHandler(this.WorkshopAdd_Click);
            // 
            // ButForward
            // 
            this.ButForward.Location = new System.Drawing.Point(230, 19);
            this.ButForward.Name = "ButForward";
            this.ButForward.Size = new System.Drawing.Size(75, 23);
            this.ButForward.TabIndex = 20;
            this.ButForward.Text = "Forward";
            this.ButForward.UseVisualStyleBackColor = true;
            this.ButForward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 518);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Item ID";
            // 
            // ButBack
            // 
            this.ButBack.Location = new System.Drawing.Point(149, 19);
            this.ButBack.Name = "ButBack";
            this.ButBack.Size = new System.Drawing.Size(75, 23);
            this.ButBack.TabIndex = 19;
            this.ButBack.Text = "Back";
            this.ButBack.UseVisualStyleBackColor = true;
            this.ButBack.Click += new System.EventHandler(this.Back_Click);
            // 
            // TBWorkshopAdd
            // 
            this.TBWorkshopAdd.Location = new System.Drawing.Point(9, 534);
            this.TBWorkshopAdd.Name = "TBWorkshopAdd";
            this.TBWorkshopAdd.Size = new System.Drawing.Size(310, 20);
            this.TBWorkshopAdd.TabIndex = 4;
            // 
            // LBWorkshop
            // 
            this.LBWorkshop.FormattingEnabled = true;
            this.LBWorkshop.Location = new System.Drawing.Point(7, 20);
            this.LBWorkshop.Name = "LBWorkshop";
            this.LBWorkshop.Size = new System.Drawing.Size(136, 485);
            this.LBWorkshop.TabIndex = 3;
            this.LBWorkshop.SelectedIndexChanged += new System.EventHandler(this.LBWorkshop_SelectedIndexChanged);
            // 
            // WorkShopBrowser
            // 
            this.WorkShopBrowser.AllowWebBrowserDrop = false;
            this.WorkShopBrowser.Location = new System.Drawing.Point(149, 48);
            this.WorkShopBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WorkShopBrowser.Name = "WorkShopBrowser";
            this.WorkShopBrowser.ScriptErrorsSuppressed = true;
            this.WorkShopBrowser.Size = new System.Drawing.Size(782, 431);
            this.WorkShopBrowser.TabIndex = 2;
            this.WorkShopBrowser.TabStop = false;
            this.WorkShopBrowser.Url = new System.Uri("https://steamcommunity.com/workshop/browse/?appid=232090&requiredtags[]=Maps", System.UriKind.Absolute);
            this.WorkShopBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WorkShopBrowser_DocumentCompleted);
            // 
            // WorkShopCollection
            // 
            this.WorkShopCollection.Location = new System.Drawing.Point(149, 485);
            this.WorkShopCollection.Name = "WorkShopCollection";
            this.WorkShopCollection.Size = new System.Drawing.Size(782, 20);
            this.WorkShopCollection.TabIndex = 1;
            this.WorkShopCollection.SelectedItemChanged += new System.EventHandler(this.WorkShopCollection_SelectedItemChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ServerMaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButBackupKFEngine);
            this.Controls.Add(this.LBKFEngine);
            this.Controls.Add(this.KFEngineOK);
            this.Controls.Add(this.ButBackupKFGame);
            this.Controls.Add(this.LBKFGame);
            this.Controls.Add(this.KFGameOK);
            this.Controls.Add(this.ServerLocationOK);
            this.Controls.Add(this.ButServerLocation);
            this.Controls.Add(this.TBServerLocation);
            this.Controls.Add(this.LBServerLocation);
            this.Controls.Add(this.LBTitle);
            this.Name = "ServerMaps";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBTitle;
        private System.Windows.Forms.LinkLabel LBServerLocation;
        private System.Windows.Forms.TextBox TBServerLocation;
        private System.Windows.Forms.Button ButServerLocation;
        private System.Windows.Forms.Label ServerLocationOK;
        private System.Windows.Forms.Label KFGameOK;
        private System.Windows.Forms.LinkLabel LBKFGame;
        private System.Windows.Forms.Button ButAddMaps;
        private System.Windows.Forms.Button ButBackupKFGame;
        private System.Windows.Forms.Label KFEngineOK;
        private System.Windows.Forms.LinkLabel LBKFEngine;
        private System.Windows.Forms.Button ButBackupKFEngine;
        private System.Windows.Forms.RichTextBox TBMaps;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser WorkShopBrowser;
        private System.Windows.Forms.ListBox LBWorkshop;
        private System.Windows.Forms.DomainUpDown WorkShopCollection;
        private System.Windows.Forms.Button ButWorkshopAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBWorkshopAdd;
        private System.Windows.Forms.Button ButHome;
        private System.Windows.Forms.Button ButForward;
        private System.Windows.Forms.Button ButBack;
        private System.Windows.Forms.Button ButSearch;
        private System.Windows.Forms.Label LBSearch;
        private System.Windows.Forms.TextBox TBSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}