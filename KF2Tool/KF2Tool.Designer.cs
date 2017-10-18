namespace KF2Tool
{
    partial class KF2Tool
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
            this.LBKF2LatestNews = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButClient = new System.Windows.Forms.Button();
            this.ButServerMaps = new System.Windows.Forms.Button();
            this.TBKF2LatestNews = new System.Windows.Forms.RichTextBox();
            this.ButServerMutators = new System.Windows.Forms.Button();
            this.ButServerConfig = new System.Windows.Forms.Button();
            this.TBServerLocation = new System.Windows.Forms.TextBox();
            this.ButUpdateServer = new System.Windows.Forms.Button();
            this.LBServerLocation = new System.Windows.Forms.Label();
            this.ButServerLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBKF2LatestNews
            // 
            this.LBKF2LatestNews.AutoSize = true;
            this.LBKF2LatestNews.Location = new System.Drawing.Point(12, 9);
            this.LBKF2LatestNews.Name = "LBKF2LatestNews";
            this.LBKF2LatestNews.Size = new System.Drawing.Size(66, 13);
            this.LBKF2LatestNews.TabIndex = 1;
            this.LBKF2LatestNews.Text = "Latest News";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1212, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // ButClient
            // 
            this.ButClient.Location = new System.Drawing.Point(473, 12);
            this.ButClient.Name = "ButClient";
            this.ButClient.Size = new System.Drawing.Size(104, 23);
            this.ButClient.TabIndex = 3;
            this.ButClient.Text = "Client";
            this.ButClient.UseVisualStyleBackColor = true;
            this.ButClient.Click += new System.EventHandler(this.Client_Click);
            // 
            // ButServerMaps
            // 
            this.ButServerMaps.Location = new System.Drawing.Point(473, 70);
            this.ButServerMaps.Name = "ButServerMaps";
            this.ButServerMaps.Size = new System.Drawing.Size(104, 23);
            this.ButServerMaps.TabIndex = 4;
            this.ButServerMaps.Text = "Server Maps";
            this.ButServerMaps.UseVisualStyleBackColor = true;
            this.ButServerMaps.Click += new System.EventHandler(this.ServerMaps_Click);
            // 
            // TBKF2LatestNews
            // 
            this.TBKF2LatestNews.Location = new System.Drawing.Point(15, 26);
            this.TBKF2LatestNews.Name = "TBKF2LatestNews";
            this.TBKF2LatestNews.ReadOnly = true;
            this.TBKF2LatestNews.Size = new System.Drawing.Size(454, 245);
            this.TBKF2LatestNews.TabIndex = 5;
            this.TBKF2LatestNews.Text = "Connecting...";
            // 
            // ButServerMutators
            // 
            this.ButServerMutators.Location = new System.Drawing.Point(473, 99);
            this.ButServerMutators.Name = "ButServerMutators";
            this.ButServerMutators.Size = new System.Drawing.Size(104, 23);
            this.ButServerMutators.TabIndex = 6;
            this.ButServerMutators.Text = "Server Mutators";
            this.ButServerMutators.UseVisualStyleBackColor = true;
            this.ButServerMutators.Click += new System.EventHandler(this.ServerMutators_Click);
            // 
            // ButServerConfig
            // 
            this.ButServerConfig.Location = new System.Drawing.Point(473, 41);
            this.ButServerConfig.Name = "ButServerConfig";
            this.ButServerConfig.Size = new System.Drawing.Size(104, 23);
            this.ButServerConfig.TabIndex = 7;
            this.ButServerConfig.Text = "Server Config";
            this.ButServerConfig.UseVisualStyleBackColor = true;
            this.ButServerConfig.Click += new System.EventHandler(this.ServerConfig_Click);
            // 
            // TBServerLocation
            // 
            this.TBServerLocation.Location = new System.Drawing.Point(15, 305);
            this.TBServerLocation.Name = "TBServerLocation";
            this.TBServerLocation.Size = new System.Drawing.Size(392, 20);
            this.TBServerLocation.TabIndex = 9;
            this.TBServerLocation.TextChanged += new System.EventHandler(this.TBServerLocation_TextChanged);
            // 
            // ButUpdateServer
            // 
            this.ButUpdateServer.Location = new System.Drawing.Point(484, 303);
            this.ButUpdateServer.Name = "ButUpdateServer";
            this.ButUpdateServer.Size = new System.Drawing.Size(93, 23);
            this.ButUpdateServer.TabIndex = 10;
            this.ButUpdateServer.Text = "Update Server";
            this.ButUpdateServer.UseVisualStyleBackColor = true;
            this.ButUpdateServer.Click += new System.EventHandler(this.ButUpdateServer_Click);
            // 
            // LBServerLocation
            // 
            this.LBServerLocation.AutoSize = true;
            this.LBServerLocation.Location = new System.Drawing.Point(15, 286);
            this.LBServerLocation.Name = "LBServerLocation";
            this.LBServerLocation.Size = new System.Drawing.Size(82, 13);
            this.LBServerLocation.TabIndex = 11;
            this.LBServerLocation.Text = "Server Location";
            this.LBServerLocation.Click += new System.EventHandler(this.ServerLocation_Click_1);
            // 
            // ButServerLocation
            // 
            this.ButServerLocation.Location = new System.Drawing.Point(413, 303);
            this.ButServerLocation.Name = "ButServerLocation";
            this.ButServerLocation.Size = new System.Drawing.Size(65, 23);
            this.ButServerLocation.TabIndex = 19;
            this.ButServerLocation.Text = "Browse";
            this.ButServerLocation.UseVisualStyleBackColor = true;
            this.ButServerLocation.Click += new System.EventHandler(this.ServerLocation_Click);
            // 
            // KF2Tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 334);
            this.Controls.Add(this.ButServerLocation);
            this.Controls.Add(this.LBServerLocation);
            this.Controls.Add(this.ButUpdateServer);
            this.Controls.Add(this.TBServerLocation);
            this.Controls.Add(this.ButServerConfig);
            this.Controls.Add(this.ButServerMutators);
            this.Controls.Add(this.TBKF2LatestNews);
            this.Controls.Add(this.ButServerMaps);
            this.Controls.Add(this.ButClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBKF2LatestNews);
            this.Name = "KF2Tool";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.KF2Tool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBKF2LatestNews;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButClient;
        private System.Windows.Forms.Button ButServerMaps;
        private System.Windows.Forms.RichTextBox TBKF2LatestNews;
        private System.Windows.Forms.Button ButServerMutators;
        private System.Windows.Forms.Button ButServerConfig;
        private System.Windows.Forms.TextBox TBServerLocation;
        private System.Windows.Forms.Button ButUpdateServer;
        private System.Windows.Forms.Label LBServerLocation;
        private System.Windows.Forms.Button ButServerLocation;
    }
}

