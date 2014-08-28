using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace MCLauncher
{
    class FoobarPlayer
    {
        public bool AutoPlay;
        public bool RandomPlay;

        public string ProgramBase;
        public string Program;

        private bool Exited = false;

        public void Start()
        {
            Exited = false;
            RemoveRunningFile();
            DoFoobarCommand(Program + " /stop");
        }

        //移除Foobar2000的running文件，防止启动时出现选择对话框
        private void RemoveRunningFile()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DirectoryInfo dir = new DirectoryInfo(folder);
            DirectoryInfo[] subDirs = dir.GetDirectories("foobar2000");
            if (subDirs != null && subDirs.Length > 0)
            {
                FileInfo[] files = subDirs[0].GetFiles("running");
                if (files != null & files.Length > 0)
                {
                    files[0].Delete();
                }
            }
            else
            {
                //找foobar2000的文件夹
                FileInfo foobar = new FileInfo(this.ProgramBase);
                FileInfo[] files = foobar.Directory.GetFiles("running");
                if (files != null & files.Length > 0)
                {
                    files[0].Delete();
                }
            }
        }

        public void AddAndPlayMusicFiles(string musicFiles)
        {
            if (!Exited)
            {
                DoFoobarCommand(Program + " /command:clear");
                //DoFoobarCommand(Program + " /playnow " + musicFiles);
                DoFoobarCommand(Program, "/playnow " + musicFiles);
            }
        }

        public void Stop()
        {
            if (!Exited)
            {
                //DoFoobarCommand(Program + " /stop");
                DoFoobarCommand(Program, "/stop");
            }
        }

        public void Play()
        {
            if (!Exited)
            {
                //DoFoobarCommand(Program + " /play");
                DoFoobarCommand(Program, "/play");
            }
        }

        public void Pause()
        {
            if (!Exited)
            {
                //DoFoobarCommand(Program + " /pause");
                DoFoobarCommand(Program, "/pause");
            }
        }

        public void PlayPause()
        {
            if (!Exited)
            {
                DoFoobarCommand(Program + " /playpause");
                DoFoobarCommand(Program, "/playpause");
            }
        }

        public void DumpMusic()
        {
            DoFoobarCommand(Program, "/runcmd-playlist=\"Convert/mp3-dump\"");
        }

        public void Exit()
        {
            if (!Exited)
            {
                Exited = true;
                //DoFoobarCommand(Program + " /exit");
                DoFoobarCommand(Program, "/exit");
            }
        }

        private void DoFoobarCommand(string program, string argument)
        {
            try
            {
                using (Process p = Process.Start(new ProcessStartInfo
                {
                    FileName = program,
                    Arguments = argument,
                    WindowStyle = ProcessWindowStyle.Minimized
                }))
                {
                }
            }
            catch { }
        }

        private void DoFoobarCommand(string command)
        {
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.StandardInput.WriteLine(command);
                proc.WaitForExit(500);
                proc.StandardInput.WriteLine("exit");
                proc.WaitForExit();
                /*
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
                */
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            //return Flag;
        }
    }
}
