namespace KF2Tool
{
    partial class ServerMut
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
            this.button3 = new System.Windows.Forms.Button();
            this.LBKFEngine = new System.Windows.Forms.LinkLabel();
            this.KFEngineOK = new System.Windows.Forms.Label();
            this.ServerLocationOK = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TBServerLocation = new System.Windows.Forms.TextBox();
            this.LBServerLocation = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButSearch = new System.Windows.Forms.Button();
            this.ButHome = new System.Windows.Forms.Button();
            this.LBSearch = new System.Windows.Forms.Label();
            this.TBSearch = new System.Windows.Forms.TextBox();
            this.ButForward = new System.Windows.Forms.Button();
            this.ButBack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TBMutAdd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ButMut = new System.Windows.Forms.Button();
            this.ButAct = new System.Windows.Forms.Button();
            this.ButWorkshopAdd = new System.Windows.Forms.Button();
            this.LBItemID = new System.Windows.Forms.Label();
            this.TBWorkshopAdd = new System.Windows.Forms.TextBox();
            this.LBWorkshop = new System.Windows.Forms.ListBox();
            this.WorkShopBrowser = new System.Windows.Forms.WebBrowser();
            this.WorkShopCollection = new System.Windows.Forms.DomainUpDown();
            this.TBMutators = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBActors = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(605, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "Backup KFEngine.ini";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // LBKFEngine
            // 
            this.LBKFEngine.AutoSize = true;
            this.LBKFEngine.Location = new System.Drawing.Point(511, 46);
            this.LBKFEngine.Name = "LBKFEngine";
            this.LBKFEngine.Size = new System.Drawing.Size(53, 13);
            this.LBKFEngine.TabIndex = 21;
            this.LBKFEngine.TabStop = true;
            this.LBKFEngine.Text = "KFEngine";
            this.LBKFEngine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LBKFEngine_LinkClicked);
            // 
            // KFEngineOK
            // 
            this.KFEngineOK.AutoSize = true;
            this.KFEngineOK.Location = new System.Drawing.Point(570, 46);
            this.KFEngineOK.Name = "KFEngineOK";
            this.KFEngineOK.Size = new System.Drawing.Size(29, 13);
            this.KFEngineOK.TabIndex = 20;
            this.KFEngineOK.Text = "Wait";
            // 
            // ServerLocationOK
            // 
            this.ServerLocationOK.AutoSize = true;
            this.ServerLocationOK.Location = new System.Drawing.Point(100, 26);
            this.ServerLocationOK.Name = "ServerLocationOK";
            this.ServerLocationOK.Size = new System.Drawing.Size(29, 13);
            this.ServerLocationOK.TabIndex = 19;
            this.ServerLocationOK.Text = "Wait";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TBServerLocation
            // 
            this.TBServerLocation.Location = new System.Drawing.Point(15, 43);
            this.TBServerLocation.Name = "TBServerLocation";
            this.TBServerLocation.Size = new System.Drawing.Size(419, 20);
            this.TBServerLocation.TabIndex = 17;
            this.TBServerLocation.TextChanged += new System.EventHandler(this.TBServerLocation_TextChanged);
            // 
            // LBServerLocation
            // 
            this.LBServerLocation.AutoSize = true;
            this.LBServerLocation.Location = new System.Drawing.Point(12, 26);
            this.LBServerLocation.Name = "LBServerLocation";
            this.LBServerLocation.Size = new System.Drawing.Size(82, 13);
            this.LBServerLocation.TabIndex = 16;
            this.LBServerLocation.TabStop = true;
            this.LBServerLocation.Text = "Server Location";
            this.LBServerLocation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LBServerLocation_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "KF2 Tool";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ButSearch);
            this.groupBox2.Controls.Add(this.ButHome);
            this.groupBox2.Controls.Add(this.LBSearch);
            this.groupBox2.Controls.Add(this.TBSearch);
            this.groupBox2.Controls.Add(this.ButForward);
            this.groupBox2.Controls.Add(this.ButBack);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TBMutAdd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ButMut);
            this.groupBox2.Controls.Add(this.ButAct);
            this.groupBox2.Controls.Add(this.ButWorkshopAdd);
            this.groupBox2.Controls.Add(this.LBItemID);
            this.groupBox2.Controls.Add(this.TBWorkshopAdd);
            this.groupBox2.Controls.Add(this.LBWorkshop);
            this.groupBox2.Controls.Add(this.WorkShopBrowser);
            this.groupBox2.Controls.Add(this.WorkShopCollection);
            this.groupBox2.Location = new System.Drawing.Point(315, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(937, 599);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Workshop";
            // 
            // ButSearch
            // 
            this.ButSearch.Location = new System.Drawing.Point(602, 20);
            this.ButSearch.Name = "ButSearch";
            this.ButSearch.Size = new System.Drawing.Size(75, 23);
            this.ButSearch.TabIndex = 35;
            this.ButSearch.Text = "Find";
            this.ButSearch.UseVisualStyleBackColor = true;
            this.ButSearch.Click += new System.EventHandler(this.ButSearch_Click);
            // 
            // ButHome
            // 
            this.ButHome.Location = new System.Drawing.Point(313, 20);
            this.ButHome.Name = "ButHome";
            this.ButHome.Size = new System.Drawing.Size(75, 23);
            this.ButHome.TabIndex = 14;
            this.ButHome.Text = "Home";
            this.ButHome.UseVisualStyleBackColor = true;
            this.ButHome.Click += new System.EventHandler(this.Home_Click);
            // 
            // LBSearch
            // 
            this.LBSearch.AutoSize = true;
            this.LBSearch.Location = new System.Drawing.Point(394, 25);
            this.LBSearch.Name = "LBSearch";
            this.LBSearch.Size = new System.Drawing.Size(72, 13);
            this.LBSearch.TabIndex = 34;
            this.LBSearch.Text = "Search by ID:";
            // 
            // TBSearch
            // 
            this.TBSearch.Location = new System.Drawing.Point(472, 22);
            this.TBSearch.Name = "TBSearch";
            this.TBSearch.Size = new System.Drawing.Size(124, 20);
            this.TBSearch.TabIndex = 33;
            // 
            // ButForward
            // 
            this.ButForward.Location = new System.Drawing.Point(231, 20);
            this.ButForward.Name = "ButForward";
            this.ButForward.Size = new System.Drawing.Size(75, 23);
            this.ButForward.TabIndex = 13;
            this.ButForward.Text = "Forward";
            this.ButForward.UseVisualStyleBackColor = true;
            this.ButForward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // ButBack
            // 
            this.ButBack.Location = new System.Drawing.Point(150, 20);
            this.ButBack.Name = "ButBack";
            this.ButBack.Size = new System.Drawing.Size(75, 23);
            this.ButBack.TabIndex = 12;
            this.ButBack.Text = "Back";
            this.ButBack.UseVisualStyleBackColor = true;
            this.ButBack.Click += new System.EventHandler(this.Back_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label4.Location = new System.Drawing.Point(402, 583);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(316, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "It should say on the workshop file what to add and where to add it";
            // 
            // TBMutAdd
            // 
            this.TBMutAdd.Location = new System.Drawing.Point(402, 560);
            this.TBMutAdd.Name = "TBMutAdd";
            this.TBMutAdd.Size = new System.Drawing.Size(367, 20);
            this.TBMutAdd.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 547);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Add Item to server";
            // 
            // ButMut
            // 
            this.ButMut.Location = new System.Drawing.Point(778, 570);
            this.ButMut.Name = "ButMut";
            this.ButMut.Size = new System.Drawing.Size(153, 23);
            this.ButMut.TabIndex = 8;
            this.ButMut.Text = "Add item to server as mutator";
            this.ButMut.UseVisualStyleBackColor = true;
            this.ButMut.Click += new System.EventHandler(this.button4_Click);
            // 
            // ButAct
            // 
            this.ButAct.Location = new System.Drawing.Point(778, 547);
            this.ButAct.Name = "ButAct";
            this.ButAct.Size = new System.Drawing.Size(153, 23);
            this.ButAct.TabIndex = 7;
            this.ButAct.Text = "Add item to server as actor";
            this.ButAct.UseVisualStyleBackColor = true;
            this.ButAct.Click += new System.EventHandler(this.button2_Click);
            // 
            // ButWorkshopAdd
            // 
            this.ButWorkshopAdd.Location = new System.Drawing.Point(321, 566);
            this.ButWorkshopAdd.Name = "ButWorkshopAdd";
            this.ButWorkshopAdd.Size = new System.Drawing.Size(75, 23);
            this.ButWorkshopAdd.TabIndex = 6;
            this.ButWorkshopAdd.Text = "Subscribe";
            this.ButWorkshopAdd.UseVisualStyleBackColor = true;
            this.ButWorkshopAdd.Click += new System.EventHandler(this.WorkshopAdd_Click_1);
            // 
            // LBItemID
            // 
            this.LBItemID.AutoSize = true;
            this.LBItemID.Location = new System.Drawing.Point(4, 552);
            this.LBItemID.Name = "LBItemID";
            this.LBItemID.Size = new System.Drawing.Size(41, 13);
            this.LBItemID.TabIndex = 5;
            this.LBItemID.Text = "Item ID";
            // 
            // TBWorkshopAdd
            // 
            this.TBWorkshopAdd.Location = new System.Drawing.Point(5, 568);
            this.TBWorkshopAdd.Name = "TBWorkshopAdd";
            this.TBWorkshopAdd.Size = new System.Drawing.Size(310, 20);
            this.TBWorkshopAdd.TabIndex = 4;
            // 
            // LBWorkshop
            // 
            this.LBWorkshop.FormattingEnabled = true;
            this.LBWorkshop.Location = new System.Drawing.Point(7, 20);
            this.LBWorkshop.Name = "LBWorkshop";
            this.LBWorkshop.Size = new System.Drawing.Size(136, 524);
            this.LBWorkshop.TabIndex = 3;
            this.LBWorkshop.SelectedIndexChanged += new System.EventHandler(this.LBWorkshop_SelectedIndexChanged);
            // 
            // WorkShopBrowser
            // 
            this.WorkShopBrowser.AllowWebBrowserDrop = false;
            this.WorkShopBrowser.Location = new System.Drawing.Point(149, 49);
            this.WorkShopBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WorkShopBrowser.Name = "WorkShopBrowser";
            this.WorkShopBrowser.ScriptErrorsSuppressed = true;
            this.WorkShopBrowser.Size = new System.Drawing.Size(782, 469);
            this.WorkShopBrowser.TabIndex = 2;
            this.WorkShopBrowser.TabStop = false;
            this.WorkShopBrowser.Url = new System.Uri("https://steamcommunity.com/workshop/browse/?appid=232090&requiredtags[]=Mutators", System.UriKind.Absolute);
            this.WorkShopBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WorkShopBrowser_DocumentCompleted);
            // 
            // WorkShopCollection
            // 
            this.WorkShopCollection.Location = new System.Drawing.Point(149, 524);
            this.WorkShopCollection.Name = "WorkShopCollection";
            this.WorkShopCollection.Size = new System.Drawing.Size(782, 20);
            this.WorkShopCollection.TabIndex = 1;
            this.WorkShopCollection.SelectedItemChanged += new System.EventHandler(this.WorkShopCollection_SelectedItemChanged);
            // 
            // TBMutators
            // 
            this.TBMutators.Location = new System.Drawing.Point(15, 86);
            this.TBMutators.Name = "TBMutators";
            this.TBMutators.Size = new System.Drawing.Size(294, 273);
            this.TBMutators.TabIndex = 24;
            this.TBMutators.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Current Actors";
            // 
            // TBActors
            // 
            this.TBActors.Location = new System.Drawing.Point(12, 378);
            this.TBActors.Name = "TBActors";
            this.TBActors.Size = new System.Drawing.Size(294, 291);
            this.TBActors.TabIndex = 27;
            this.TBActors.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Current Mutators";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(728, 45);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(57, 13);
            this.linkLabel1.TabIndex = 31;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "KF2Server";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(791, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Wait";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(826, 41);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(123, 23);
            this.button5.TabIndex = 32;
            this.button5.Text = "Backup KF2Server.bat";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ServerMut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TBActors);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TBMutators);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.LBKFEngine);
            this.Controls.Add(this.KFEngineOK);
            this.Controls.Add(this.ServerLocationOK);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TBServerLocation);
            this.Controls.Add(this.LBServerLocation);
            this.Controls.Add(this.label1);
            this.Name = "ServerMut";
            this.Text = "ServerMut";
            this.Load += new System.EventHandler(this.ServerMut_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel LBKFEngine;
        private System.Windows.Forms.Label KFEngineOK;
        private System.Windows.Forms.Label ServerLocationOK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TBServerLocation;
        private System.Windows.Forms.LinkLabel LBServerLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ButWorkshopAdd;
        private System.Windows.Forms.Label LBItemID;
        private System.Windows.Forms.TextBox TBWorkshopAdd;
        private System.Windows.Forms.ListBox LBWorkshop;
        private System.Windows.Forms.WebBrowser WorkShopBrowser;
        private System.Windows.Forms.DomainUpDown WorkShopCollection;
        private System.Windows.Forms.Button ButAct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButMut;
        private System.Windows.Forms.TextBox TBMutAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox TBMutators;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox TBActors;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button ButHome;
        private System.Windows.Forms.Button ButForward;
        private System.Windows.Forms.Button ButBack;
        private System.Windows.Forms.Button ButSearch;
        private System.Windows.Forms.Label LBSearch;
        private System.Windows.Forms.TextBox TBSearch;
    }
}