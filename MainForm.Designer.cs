namespace MCLauncher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlaying = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblStyle = new System.Windows.Forms.Label();
            this.tmrPlay = new System.Windows.Forms.Timer(this.components);
            this.tmrStartUp = new System.Windows.Forms.Timer(this.components);
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.btnEject = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnNextStyle = new System.Windows.Forms.Button();
            this.btnPrevStyle = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnDump = new System.Windows.Forms.Button();
            this.cmsTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Player Launcher";
            this.notifyIcon1.ContextMenuStrip = this.cmsTrayMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Music Player Laucher";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cmsTrayMenu
            // 
            this.cmsTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.cmsTrayMenu.Name = "cmsTrayMenu";
            this.cmsTrayMenu.Size = new System.Drawing.Size(132, 112);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.showToolStripMenuItem.Text = "&Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.settingsToolStripMenuItem.Text = "S&ettings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(128, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(128, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current Playing:";
            // 
            // lblPlaying
            // 
            this.lblPlaying.Location = new System.Drawing.Point(130, 161);
            this.lblPlaying.Name = "lblPlaying";
            this.lblPlaying.Size = new System.Drawing.Size(392, 43);
            this.lblPlaying.TabIndex = 5;
            this.lblPlaying.Text = "Playing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Style:";
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(130, 127);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(39, 17);
            this.lblStyle.TabIndex = 9;
            this.lblStyle.Text = "Style";
            // 
            // tmrPlay
            // 
            this.tmrPlay.Interval = 1000;
            this.tmrPlay.Tick += new System.EventHandler(this.tmrPlay_Tick);
            // 
            // tmrStartUp
            // 
            this.tmrStartUp.Interval = 200;
            this.tmrStartUp.Tick += new System.EventHandler(this.tmrStartUp_Tick);
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(15, 320);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.Size = new System.Drawing.Size(507, 141);
            this.tbInfo.TabIndex = 14;
            // 
            // btnEject
            // 
            this.btnEject.BackgroundImage = global::MCLauncher.Resource1.eject;
            this.btnEject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEject.FlatAppearance.BorderSize = 0;
            this.btnEject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEject.Location = new System.Drawing.Point(12, 214);
            this.btnEject.Name = "btnEject";
            this.btnEject.Size = new System.Drawing.Size(100, 100);
            this.btnEject.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnEject, "Eject CD");
            this.btnEject.UseVisualStyleBackColor = true;
            this.btnEject.Click += new System.EventHandler(this.btnEject_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackgroundImage = global::MCLauncher.Resource1.Pause;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Location = new System.Drawing.Point(319, 207);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 100);
            this.btnPause.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnPause, "Pause");
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackgroundImage = global::MCLauncher.Resource1.PrevAlbum;
            this.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(345, 12);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(88, 88);
            this.btnPrev.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnPrev, "Next Album");
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = global::MCLauncher.Resource1.Stop;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(422, 207);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 100);
            this.btnStop.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnStop, "Stop");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImage = global::MCLauncher.Resource1.Play;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(216, 207);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(100, 100);
            this.btnPlay.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnPlay, "Play");
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnNextStyle
            // 
            this.btnNextStyle.BackgroundImage = global::MCLauncher.Resource1.NextStyle;
            this.btnNextStyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNextStyle.FlatAppearance.BorderSize = 0;
            this.btnNextStyle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextStyle.Location = new System.Drawing.Point(105, 12);
            this.btnNextStyle.Name = "btnNextStyle";
            this.btnNextStyle.Size = new System.Drawing.Size(88, 88);
            this.btnNextStyle.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnNextStyle, "Next Style");
            this.btnNextStyle.UseVisualStyleBackColor = true;
            this.btnNextStyle.Click += new System.EventHandler(this.btnNextStyle_Click);
            // 
            // btnPrevStyle
            // 
            this.btnPrevStyle.BackgroundImage = global::MCLauncher.Resource1.PreStyle;
            this.btnPrevStyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrevStyle.FlatAppearance.BorderSize = 0;
            this.btnPrevStyle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevStyle.Location = new System.Drawing.Point(15, 12);
            this.btnPrevStyle.Name = "btnPrevStyle";
            this.btnPrevStyle.Size = new System.Drawing.Size(88, 88);
            this.btnPrevStyle.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnPrevStyle, "Previous Style");
            this.btnPrevStyle.UseVisualStyleBackColor = true;
            this.btnPrevStyle.Click += new System.EventHandler(this.btnPrevStyle_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = global::MCLauncher.Resource1.NextAlbum;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(434, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 88);
            this.btnNext.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnNext, "Next Album");
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.BackgroundImage = global::MCLauncher.Resource1.RandomAlbum;
            this.btnRandom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRandom.FlatAppearance.BorderSize = 0;
            this.btnRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandom.Location = new System.Drawing.Point(236, 12);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(88, 88);
            this.btnRandom.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnRandom, "Random Album in the Same Style");
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnDump
            // 
            this.btnDump.BackgroundImage = global::MCLauncher.Resource1.download;
            this.btnDump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDump.FlatAppearance.BorderSize = 0;
            this.btnDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDump.Location = new System.Drawing.Point(110, 214);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(100, 100);
            this.btnDump.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnDump, "Dump music");
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 473);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.btnEject);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblStyle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNextStyle);
            this.Controls.Add(this.btnPrevStyle);
            this.Controls.Add(this.lblPlaying);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnRandom);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Music Player Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.cmsTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cmsTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlaying;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnPrevStyle;
        private System.Windows.Forms.Button btnNextStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Timer tmrPlay;
        private System.Windows.Forms.Timer tmrStartUp;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Button btnEject;
        private System.Windows.Forms.Button btnDump;
    }
}