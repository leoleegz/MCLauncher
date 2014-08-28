using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace MCLauncher.Library
{
    [Serializable()]
    class MediaLibrary
    {
        public static MediaLibrary Default;
        public static MediaLibrary USB;
        public static MediaLibrary CD;

        public MusicStyle[] Styles;

        [NonSerialized()]
        private int styleIndex;           //当前风格

        //是否包含网络文件夹
        public bool ContainsNetworkFolders()
        {
            foreach (MusicStyle style in Styles)
            {
                if (style.IsNetworkFolder)
                    return true;
            }
            return false;
        }

        public MusicStyle GetCurrentStyle()
        {
            if (Styles == null || Styles.Length == 0)
                return null;

            return Styles[styleIndex];
        }

        //得到上次播放风格
        public MusicStyle GetLastStyle(bool startup)
        {
            if (Styles.Length == 0)
                return null;

            if (Settings.Default.RandomPlay && startup)
            {
                // 随机播放一个风格
                Random rnd = new Random();
                styleIndex = rnd.Next(Styles.Length); 
            }
            else
            {
                styleIndex = 0;
                for (int i = 0; i < Styles.Length; i++ )
                {
                    if (Styles[i].StyleRootFolder == PlayingSettings.Default.LastStyle)
                    {
                        styleIndex = i;
                    }
                }
                styleIndex = (styleIndex >= Styles.Length) ? 0 : styleIndex;
            }

            return Styles[styleIndex];
        }

        public MusicStyle ChangeStyle(bool next)
        {
            if (Styles.Length == 0)
                return null;

            if (next)
            {
                styleIndex++;
                if (styleIndex >= Styles.Length)
                    styleIndex = 0;
            }
            else
            {
                styleIndex--;
                if (styleIndex < 0)
                    styleIndex = Styles.Length - 1;
            }

            return Styles[styleIndex];
        }

        public void Save()
        {
            using (FileStream stream = new FileStream(Settings.LIBFILENAME, FileMode.Create))
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
            MediaLibrary library = null;
            try
            {
                using (FileStream stream = new FileStream(Settings.LIBFILENAME, FileMode.Open))
                {
                    SoapFormatter formatter = new SoapFormatter();
                    try
                    {
                        library = (MediaLibrary)formatter.Deserialize(stream);
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

            if (library == null)
                library = new MediaLibrary();

            PlayingSettings.Load();

            Default = library;
        }
    }
}
