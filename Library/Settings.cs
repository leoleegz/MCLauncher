using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace MCLauncher.Library
{
    [Serializable()]
    class Settings
    {
        public string PlayerPath;               //播放器的路径
        public bool RandomPlay;                 //是否随机播放
        public bool AutoPlay;                   //是否自动播放

        public string Server;                   //播放服务器

        public bool MonitorRemovableDevices;    //是否监控USB、光驱等设备
        public string RemovableDeviceRootPath;  //USB设备根目录

        public string DumpDrive;                //音乐导出的U盘盘符
        public const string CONVERTERNAME = "mp3-dump";   //转换器的名字

        public const string LIBFILENAME = "library.xml";
        public const string SAVEFILENAME = "settings.xml";
        public const string PLAYFILENAME = "playing.xml";
        public static string[] MusicFileType = new string[] { "*.cue", "*.flac", "*.ape", "*.wav", "*.aac", "*.mp3", "*.cda" };

        public static Settings Default;

        public Settings()
        {
            RandomPlay = true;
            AutoPlay = true;
            Server = "";
            MonitorRemovableDevices = true;
            RemovableDeviceRootPath = "Music";
        }

        public void Save()
        {
            using (FileStream stream = new FileStream(SAVEFILENAME, FileMode.Create))
            {
                SoapFormatter formatter = new SoapFormatter();

                try
                {
                    formatter.Serialize(stream, this);
                }
                catch (SerializationException se)
                { }
                finally
                {
                    stream.Close();
                }
            }
        }

        public static void Load()
        {
            Settings settings = null;
            try
            {
                using (FileStream stream = new FileStream(SAVEFILENAME, FileMode.Open))
                {
                    SoapFormatter formatter = new SoapFormatter();
                    try
                    {
                        settings = (Settings)formatter.Deserialize(stream);
                    }
                    catch (SerializationException se)
                    { }
                    finally
                    {
                        stream.Close();
                    }
                }
            }
            catch (Exception ex) { }

            if (settings == null)
                settings = new Settings();

            Default = settings;
        }
    }
}
