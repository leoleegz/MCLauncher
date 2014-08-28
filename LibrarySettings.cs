using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCLauncher
{
    public partial class LibrarySettings : Form
    {
        System.Diagnostics.Stopwatch stopwatch;

        public LibrarySettings()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Library.Settings.Default.AutoPlay = cbAutoPlay.Checked;
            Library.Settings.Default.RandomPlay = cbRandom.Checked;
            Library.Settings.Default.Server = tbServer.Text;
            Library.Settings.Default.PlayerPath = tbPlayer.Text;
            Library.Settings.Default.DumpDrive = tbDumpDrive.Text;

            Library.Settings.Default.MonitorRemovableDevices = cbMonitorRemovable.Checked;
            Library.Settings.Default.RemovableDeviceRootPath = tbRDRootPath.Text;

            Library.Settings.Default.Save();

            this.Close();
        }

        private void AppSettings_Load(object sender, EventArgs e)
        {
            InfoMessage("");
            lbStyles.Items.Clear();

            tbServer.Text = Library.Settings.Default.Server;
            tbPlayer.Text = Library.Settings.Default.PlayerPath;
            cbRandom.Checked = Library.Settings.Default.RandomPlay;
            cbAutoPlay.Checked = Library.Settings.Default.AutoPlay;

            cbMonitorRemovable.Checked = Library.Settings.Default.MonitorRemovableDevices;
            tbRDRootPath.Text = Library.Settings.Default.RemovableDeviceRootPath;

            tbDumpDrive.Text = Library.Settings.Default.DumpDrive;

            if (Library.MediaLibrary.Default.Styles != null)
            {
                foreach (Library.MusicStyle style in Library.MediaLibrary.Default.Styles)
                {
                    lbStyles.Items.Add(style.StyleRootFolder);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dlgPlayer.Filter = "Execute files (*.exe)|*.exe";
            dlgPlayer.RestoreDirectory = true;
            if (dlgPlayer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbPlayer.Text = dlgPlayer.FileName;
            }
        }

        private void btnAddStyle_Click(object sender, EventArgs e)
        {
            if (fbdStyleFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string stylefolder = fbdStyleFolder.SelectedPath;
                foreach (string style in lbStyles.Items)
                {
                    if (style == stylefolder)
                        return;
                }

                lbStyles.Items.Add(stylefolder);
            }
        }

        private void btnRemoveStyle_Click(object sender, EventArgs e)
        {
            if (lbStyles.SelectedIndex >= 0)
                lbStyles.Items.RemoveAt(lbStyles.SelectedIndex);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if(lbStyles.SelectedIndex > 0)
            {
                string item = lbStyles.SelectedItem as string;
                int index = lbStyles.SelectedIndex;
                lbStyles.Items.RemoveAt(lbStyles.SelectedIndex);
                lbStyles.Items.Insert(index - 1, item);
                lbStyles.SetSelected(index - 1, true);
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lbStyles.SelectedIndex < lbStyles.Items.Count - 1 && lbStyles.SelectedIndex >= 0)
            {
                string item = lbStyles.SelectedItem as string;
                int index = lbStyles.SelectedIndex;
                lbStyles.Items.RemoveAt(lbStyles.SelectedIndex);
                lbStyles.Items.Insert(index + 1, item);
                lbStyles.SetSelected(index + 1, true);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            StringCollection styles = new StringCollection();
            foreach (string item in lbStyles.Items)
            {
                styles.Add(item);
            }

            Library.MediaLibrary.Default.Styles = new Library.MusicStyle[styles.Count];

            InfoMessage("开始扫描");
            stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            bgwScanFolders.RunWorkerAsync(styles);
        }

        private void bgwScanFolders_DoWork(object sender, DoWorkEventArgs e)
        {
            //bgwScanFolders.ReportProgress(
            StringCollection styles = e.Argument as StringCollection;
            int i = 0;
            foreach (string style in styles)
            {
                Library.MediaLibrary.Default.Styles[i] = new Library.MusicStyle(style);
                bgwScanFolders.ReportProgress(0, style);
                Library.MediaLibrary.Default.Styles[i].FillAlbumsData();
                i++;
            }
        }

        private void bgwScanFolders_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string stylefolder = e.UserState as string;
            InfoMessage(string.Format("正在扫描{0}", stylefolder));
        }

        private void bgwScanFolders_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopwatch.Stop();
            InfoMessage(string.Format("扫描完成，耗时{0}ms.", stopwatch.ElapsedMilliseconds));

            Library.MediaLibrary.Default.Save();
        }

        private void InfoMessage(string message)
        {
            lblStatus.Text = message;
        }
    }
}
