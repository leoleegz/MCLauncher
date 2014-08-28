using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class MainForm : Form
    {
        bool IsServerConnected = false;

        FoobarPlayer player;

        DriveDetector detector;

        public MainForm()
        {
            InitializeComponent();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
                this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();

            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStyle.Text = "";
            lblPlaying.Text = "";

            //载入配置信息
            Library.Settings.Load();

            Library.PlayingManager.ChangeDevice(Library.SourceType.DISK);
            
            Microsoft.Win32.SystemEvents.SessionEnding += new Microsoft.Win32.SessionEndingEventHandler(SystemEvents_SessionEnding);

            tmrStartUp.Start();
        }

        void SystemEvents_SessionEnding(object sender, Microsoft.Win32.SessionEndingEventArgs e)
        {
            player.Stop();
            player.Exit();
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibrarySettings settings = new LibrarySettings();
            settings.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                this.Hide();

                lblPlaying.Text = "";
            }
            else
            {
                player.Exit();
                detector.Dispose();
                UnregisterKeys();
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            Library.MusicStyle style = Library.PlayingManager.GetMediaLibrary().GetCurrentStyle();

            if (style == null)
                return;

            //从当前风格中随机挑选一个文件夹进行播放
            DoAlbumChanged(style.RandomAlbum());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Library.MusicStyle style = Library.PlayingManager.GetMediaLibrary().GetCurrentStyle();
            if (style == null)
                return;

            DoAlbumChanged(style.GetBrotherAlbum(true));
        }

        private void btnPrevStyle_Click(object sender, EventArgs e)
        {
            Library.MusicStyle style = Library.PlayingManager.GetMediaLibrary().ChangeStyle(false);
            if (style == null)
                return;

            DoStyleChanged(style);
        }

        private void btnNextStyle_Click(object sender, EventArgs e)
        {
            Library.MusicStyle style = Library.PlayingManager.GetMediaLibrary().ChangeStyle(false);
            if (style == null)
                return;

            DoStyleChanged(style);
        }

        private void DoStyleChanged(Library.MusicStyle style)
        {
            //folderOperator = new FolderOperator(style);
            lblStyle.Text = style.StyleRootFolder;

            btnRandom.PerformClick();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            Library.MusicStyle style = Library.PlayingManager.GetMediaLibrary().GetCurrentStyle();
            if (style == null)
                return;

            DoAlbumChanged(style.GetBrotherAlbum(false));
        }

        private void DoAlbumChanged(string album)
        {
            lblPlaying.Text = "";

            player.Stop();
            Application.DoEvents();

            if (album == null)
                return;

            lblPlaying.Text = album;

            try
            {
                string musicfiles = FolderOperator.GetPlayableFileList(album);
                player.AddAndPlayMusicFiles(musicfiles);
            }
            catch { }
        }

        private void tmrPlay_Tick(object sender, EventArgs e)
        {
            tmrPlay.Stop();
            player.Play();
        }

        private void ConnectToServer()
        {
            //试图连接服务器
            if (Library.Settings.Default.Server.Length > 0 && !IsServerConnected)
            {
                InfoMessage("连接服务器:" + Library.Settings.Default.Server);
                bool ret = NetOperator.Connect2(Library.Settings.Default.Server);
                if (!ret)
                {
                    InfoMessage("无法连接服务器");
                    IsServerConnected = false;
                    return;
                }
                else
                {
                    InfoMessage("服务器连接成功");
                    IsServerConnected = true;
                }
            }
        }

        private void tmrStartUp_Tick(object sender, EventArgs e)
        {
            tmrStartUp.Stop();

            if (Library.Settings.Default == null || Library.Settings.Default.PlayerPath == null)
            {
                LibrarySettings settingDialog = new LibrarySettings();
                settingDialog.ShowDialog(this);
            }

            player = new FoobarPlayer();
            player.ProgramBase = Library.Settings.Default.PlayerPath;
            player.Program = "\"" + Library.Settings.Default.PlayerPath + "\"";
            player.RandomPlay = Library.Settings.Default.RandomPlay;
            player.AutoPlay = Library.Settings.Default.AutoPlay;

            if (Library.Settings.Default.MonitorRemovableDevices)
            {
                detector = new DriveDetector();
                detector.DeviceArrived += new DriveDetectorEventHandler(detector_DeviceArrived);
                detector.DeviceRemoved += new DriveDetectorEventHandler(detector_DeviceRemoved);
                detector.QueryRemove += new DriveDetectorEventHandler(detector_QueryRemove);
            }

            Library.MediaLibrary startupLibrary = Library.PlayingManager.GetMediaLibrary();

            if (startupLibrary.ContainsNetworkFolders())
                NetOperator.ReconnectAllNetworkDrives();

            player.Start(); //启动播放器

            RegisterKeys(); //注册热键

            if (startupLibrary.Styles != null && startupLibrary.Styles.Length > 0)
            {
                StartPlayMusic(true);
            }
            else
            {
                InfoMessage("音乐数据库文件载入失败，或无数据");
            }
        }

        void StartPlayMusic(bool startup)
        {
            Library.MusicStyle style = Library.PlayingManager.GetMediaLibrary().GetLastStyle(startup);

            lblStyle.Text = style.StyleRootFolder;

            if (Library.Settings.Default.RandomPlay && startup)
            {
                btnRandom.PerformClick();
            }
            else
            {
                string album = style.GetLastAlbum(startup);
                DoAlbumChanged(album);
            }
        }

        void detector_QueryRemove(object sender, DriveDetectorEventArgs e)
        {
            //检查拔出的设备是否为当前的播放设备
            Library.MusicStyle style = Library.PlayingManager.GetMediaLibrary().GetCurrentStyle();
            if (style.StyleRootFolder.StartsWith(e.Drive))
            {
                player.Stop();
            }
        }

        void detector_DeviceRemoved(object sender, DriveDetectorEventArgs e)
        {
            //检查拔出的设备是否为当前的播放设备
            Library.MusicStyle style = Library.PlayingManager.GetMediaLibrary().GetCurrentStyle();
            if (style.StyleRootFolder.StartsWith(e.Drive))
            {
                Library.PlayingManager.ChangeDevice(Library.SourceType.DISK);
                StartPlayMusic(false);
            }
        }

        void detector_DeviceArrived(object sender, DriveDetectorEventArgs e)
        {
            try
            {
                DriveInfo di = new DriveInfo(e.Drive);
                if (di.DriveType == DriveType.CDRom && di.IsReady)
                {
                    //如果是光驱，并且已经插入了光盘
                    FolderOperator folderoperator = new FolderOperator(e.Drive);
                    if (folderoperator.FolderContainsMusic(new DirectoryInfo(e.Drive)))
                    {
                        Library.PlayingManager.ChangeDevice(Library.SourceType.CDROM, e.Drive);
                        StartPlayMusic(true);
                    }
                }
                else if (di.DriveType == DriveType.Removable && di.IsReady)
                {
                    //如果是USB设备
                    DirectoryInfo dir = new DirectoryInfo(e.Drive);
                    DirectoryInfo[] subDir = dir.GetDirectories(Library.Settings.Default.RemovableDeviceRootPath);
                    if (subDir != null && subDir.Length > 0)
                    {
                        Library.PlayingManager.ChangeDevice(Library.SourceType.USB, subDir[0].FullName);
                        StartPlayMusic(true);
                    }
                }
            }
            catch
            { }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            player.Pause();
        }

        private void InfoMessage(string message)
        {
            tbInfo.AppendText(message + "\r\n");
        }

        private void RegisterKeys()
        {
            HotkeyManager.AddKeys(Keys.Up, true, true, true, btnPrevStyle, this);
            HotkeyManager.AddKeys(Keys.Down, true, true, true, btnNextStyle, this);
            HotkeyManager.AddKeys(Keys.R, true, true, true, btnRandom, this);
            HotkeyManager.AddKeys(Keys.PageUp, true, true, true, btnPrev, this);
            HotkeyManager.AddKeys(Keys.PageDown, true, true, true, btnNext, this);
            HotkeyManager.AddKeys(Keys.E, true, true, true, btnEject, this);
            HotkeyManager.AddKeys(Keys.D, true, true, true, btnDump, this);
        }

        private void UnregisterKeys()
        {
            HotkeyManager.Unregister();
        }

        private void btnEject_Click(object sender, EventArgs e)
        {
            //获得当前播放的路径
            Library.MusicStyle style = Library.PlayingManager.GetMediaLibrary().GetCurrentStyle();
            string currentDrive = new DirectoryInfo(style.StyleRootFolder).Root.FullName;

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.CDRom)
                {
                    string driveletter = drive.Name.Substring(0, 1);

                    if (currentDrive.StartsWith(driveletter) && drive.IsReady)
                        player.Stop();

                    EjectMedia.Eject(driveletter);
                }
            }
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            //检查U盘是否准备好了
            try
            {
                DriveInfo drive = new DriveInfo(Library.Settings.Default.DumpDrive);
                if (!drive.IsReady)
                    return;

                DirectoryInfo root = new DirectoryInfo(drive.Name);
                if (root.GetDirectories("mp3") == null || root.GetDirectories("mp3").Length == 0 )
                {
                    root.CreateSubdirectory("mp3");
                }

                player.DumpMusic();
            }
            catch
            {
                return;
            }
        }
    }
}
