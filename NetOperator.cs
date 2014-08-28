using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Management;
using System.IO;
using System.Threading;

namespace MCLauncher
{
    class NetOperator
    {
        public static bool Connect(string server)
        {
            return Connect(server, "Guest", "");
        }

        public static bool Connect(string server, string user, string password)
        {
            ConnectionOptions options = new ConnectionOptions();
            options.Username = user;   //could   be   in   domain\user   format 
            options.Password = password;
            ManagementScope scope = new ManagementScope(
                    string.Format("\\\\{0}\\root\\cimv2 ", server),
                    options);
            try
            {
                scope.Connect();
                ManagementObject disk = new ManagementObject(
                           scope,
                           new ManagementPath("Win32_logicaldisk= 'c: ' "),
                           null);
                disk.Get();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static bool Connect2(string server)
        {
            bool Flag = false;
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
                string dosLine = @"net view \\" + server;
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
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
            return Flag;

        }

        //重新连接所有的网络盘符
        public static void ReconnectAllNetworkDrives()
        {
            var p = Process.Start(new ProcessStartInfo
            {
                FileName = "net",
                Arguments = "use",
                RedirectStandardOutput = true,
                UseShellExecute = false
            });
            var str = p.StandardOutput.ReadToEnd();
            foreach (string s in str.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var s2 = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (s2.Length >= 2 && s2[1][1] == ':')
                    Map(s2[1][0].ToString());
            }
        }

        private static void Map(string drive)
        {
            if (!new DriveInfo(drive).IsReady)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "explorer",
                        Arguments = drive + ":\\",
                        WindowStyle = ProcessWindowStyle.Minimized
                    });
                    Thread.Sleep(500);
                    foreach (Process p in Process.GetProcessesByName("explorer"))
                    {
                        if (p.MainWindowTitle.EndsWith(@"(" + drive + ":)",
                                    StringComparison.CurrentCultureIgnoreCase))
                        {
                            p.Kill();
                        }
                    }
                }
                catch { }
            }
        }
    }
}
