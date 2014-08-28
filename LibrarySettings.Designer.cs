namespace MCLauncher
{
    partial class LibrarySettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowsePlayer = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dlgPlayer = new System.Windows.Forms.OpenFileDialog();
            this.btnAddStyle = new System.Windows.Forms.Button();
            this.fbdStyleFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.cbRandom = new System.Windows.Forms.CheckBox();
            this.cbAutoPlay = new System.Windows.Forms.CheckBox();
            this.tbPlayer = new System.Windows.Forms.TextBox();
            this.lbStyles = new System.Windows.Forms.ListBox();
            this.btnRemoveStyle = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.bgwScanFolders = new System.ComponentModel.BackgroundWorker();
            this.cbMonitorRemovable = new System.Windows.Forms.CheckBox();
            this.tbRDRootPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDumpDrive = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Style Folders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Player";
            // 
            // btnBrowsePlayer
            // 
            this.btnBrowsePlayer.Location = new System.Drawing.Point(436, 40);
            this.btnBrowsePlayer.Name = "btnBrowsePlayer";
            this.btnBrowsePlayer.Size = new System.Drawing.Size(28, 22);
            this.btnBrowsePlayer.TabIndex = 4;
            this.btnBrowsePlayer.Text = "...";
            this.btnBrowsePlayer.UseVisualStyleBackColor = true;
            this.btnBrowsePlayer.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(356, 399);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 32);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dlgPlayer
            // 
            this.dlgPlayer.FileName = "foobar2000.exe";
            this.dlgPlayer.Title = "Select A Music Player";
            // 
            // btnAddStyle
            // 
            this.btnAddStyle.Location = new System.Drawing.Point(436, 73);
            this.btnAddStyle.Name = "btnAddStyle";
            this.btnAddStyle.Size = new System.Drawing.Size(28, 22);
            this.btnAddStyle.TabIndex = 8;
            this.btnAddStyle.Text = "+";
            this.btnAddStyle.UseVisualStyleBackColor = true;
            this.btnAddStyle.Click += new System.EventHandler(this.btnAddStyle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Server";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(111, 12);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(166, 22);
            this.tbServer.TabIndex = 10;
            // 
            // cbRandom
            // 
            this.cbRandom.AutoSize = true;
            this.cbRandom.Checked = true;
            this.cbRandom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRandom.Location = new System.Drawing.Point(111, 336);
            this.cbRandom.Name = "cbRandom";
            this.cbRandom.Size = new System.Drawing.Size(114, 21);
            this.cbRandom.TabIndex = 6;
            this.cbRandom.Text = "Random Play";
            this.cbRandom.UseVisualStyleBackColor = true;
            // 
            // cbAutoPlay
            // 
            this.cbAutoPlay.AutoSize = true;
            this.cbAutoPlay.Checked = true;
            this.cbAutoPlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoPlay.Location = new System.Drawing.Point(111, 309);
            this.cbAutoPlay.Name = "cbAutoPlay";
            this.cbAutoPlay.Size = new System.Drawing.Size(90, 21);
            this.cbAutoPlay.TabIndex = 5;
            this.cbAutoPlay.Text = "Auto Play";
            this.cbAutoPlay.UseVisualStyleBackColor = true;
            // 
            // tbPlayer
            // 
            this.tbPlayer.Location = new System.Drawing.Point(111, 40);
            this.tbPlayer.Name = "tbPlayer";
            this.tbPlayer.Size = new System.Drawing.Size(319, 22);
            this.tbPlayer.TabIndex = 3;
            // 
            // lbStyles
            // 
            this.lbStyles.FormattingEnabled = true;
            this.lbStyles.ItemHeight = 16;
            this.lbStyles.Location = new System.Drawing.Point(111, 73);
            this.lbStyles.Name = "lbStyles";
            this.lbStyles.Size = new System.Drawing.Size(319, 132);
            this.lbStyles.TabIndex = 11;
            // 
            // btnRemoveStyle
            // 
            this.btnRemoveStyle.Location = new System.Drawing.Point(436, 101);
            this.btnRemoveStyle.Name = "btnRemoveStyle";
            this.btnRemoveStyle.Size = new System.Drawing.Size(28, 22);
            this.btnRemoveStyle.TabIndex = 12;
            this.btnRemoveStyle.Text = "-";
            this.btnRemoveStyle.UseVisualStyleBackColor = true;
            this.btnRemoveStyle.Click += new System.EventHandler(this.btnRemoveStyle_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(112, 212);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 17);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "label4";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(436, 155);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(28, 22);
            this.btnMoveUp.TabIndex = 14;
            this.btnMoveUp.Text = "^";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(436, 183);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(28, 22);
            this.btnMoveDown.TabIndex = 15;
            this.btnMoveDown.Text = "v";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(322, 212);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(108, 30);
            this.btnScan.TabIndex = 16;
            this.btnScan.Text = "&Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // bgwScanFolders
            // 
            this.bgwScanFolders.WorkerReportsProgress = true;
            this.bgwScanFolders.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwScanFolders_DoWork);
            this.bgwScanFolders.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwScanFolders_ProgressChanged);
            this.bgwScanFolders.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwScanFolders_RunWorkerCompleted);
            // 
            // cbMonitorRemovable
            // 
            this.cbMonitorRemovable.AutoSize = true;
            this.cbMonitorRemovable.Checked = true;
            this.cbMonitorRemovable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMonitorRemovable.Location = new System.Drawing.Point(111, 256);
            this.cbMonitorRemovable.Name = "cbMonitorRemovable";
            this.cbMonitorRemovable.Size = new System.Drawing.Size(199, 21);
            this.cbMonitorRemovable.TabIndex = 17;
            this.cbMonitorRemovable.Text = "Monitor removable devices";
            this.cbMonitorRemovable.UseVisualStyleBackColor = true;
            // 
            // tbRDRootPath
            // 
            this.tbRDRootPath.Location = new System.Drawing.Point(329, 280);
            this.tbRDRootPath.Name = "tbRDRootPath";
            this.tbRDRootPath.Size = new System.Drawing.Size(101, 22);
            this.tbRDRootPath.TabIndex = 18;
            this.tbRDRootPath.Text = "Music";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Removable device root path";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Dump music to USB drive";
            // 
            // tbDumpDrive
            // 
            this.tbDumpDrive.Location = new System.Drawing.Point(329, 365);
            this.tbDumpDrive.Name = "tbDumpDrive";
            this.tbDumpDrive.Size = new System.Drawing.Size(101, 22);
            this.tbDumpDrive.TabIndex = 21;
            // 
            // LibrarySettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 443);
            this.ControlBox = false;
            this.Controls.Add(this.tbDumpDrive);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbRDRootPath);
            this.Controls.Add(this.cbMonitorRemovable);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRemoveStyle);
            this.Controls.Add(this.lbStyles);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddStyle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbRandom);
            this.Controls.Add(this.cbAutoPlay);
            this.Controls.Add(this.btnBrowsePlayer);
            this.Controls.Add(this.tbPlayer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "LibrarySettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.AppSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPlayer;
        private System.Windows.Forms.Button btnBrowsePlayer;
        private System.Windows.Forms.CheckBox cbAutoPlay;
        private System.Windows.Forms.CheckBox cbRandom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.OpenFileDialog dlgPlayer;
        private System.Windows.Forms.Button btnAddStyle;
        private System.Windows.Forms.FolderBrowserDialog fbdStyleFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.ListBox lbStyles;
        private System.Windows.Forms.Button btnRemoveStyle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnScan;
        private System.ComponentModel.BackgroundWorker bgwScanFolders;
        private System.Windows.Forms.CheckBox cbMonitorRemovable;
        private System.Windows.Forms.TextBox tbRDRootPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDumpDrive;
    }
}

