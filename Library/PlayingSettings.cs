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
    class PlayingSettings
    {
        public static PlayingSettings Default;

        public string LastStyle;            //上次播放的风格
        public string LastAlbum;            //上次播放的专辑

        public void Save()
        {
            using (FileStream stream = new FileStream(Settings.PLAYFILENAME, FileMode.Create))
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
            PlayingSettings playing = null;
            try
            {
                using (FileStream stream = new FileStream(Settings.PLAYFILENAME, FileMode.Open))
                {
                    SoapFormatter formatter = new SoapFormatter();
                    try
                    {
                        playing = (PlayingSettings)formatter.Deserialize(stream);
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

            if (playing == null)
                playing = new PlayingSettings();

            Default = playing;
        }
    }
}
