using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MCLauncher.Library
{
    enum SourceType
    {
        NONE = 0,
        DISK = 1,
        USB = 2,
        CDROM = 3
    }

    class PlayingManager
    {
        static MediaLibrary usbMediaLibrary;
        static MediaLibrary cdMediaLibrary;

        static SourceType lastSource = SourceType.NONE;

        public static void ChangeDevice(SourceType device)
        {
            ChangeDevice(device, null);
        }

        public static void ChangeDevice(SourceType device, string folder)
        {
            switch (device)
            {
                case SourceType.DISK:
                    //currentLibrary = Library.MediaLibrary.Default;
                    MediaLibrary.Load();
                    break;

                case SourceType.USB:
                    //currentLibrary = new Library.MediaLibrary();
                    usbMediaLibrary = new MediaLibrary();
                    /*
                    DirectoryInfo musicFolder = new DirectoryInfo(folder);
                    usbMediaLibrary.Styles = new MusicStyle[musicFolder.GetDirectories().Length];
                    int i = 0;
                    foreach(DirectoryInfo subDir in musicFolder.GetDirectories())
                    {
                        usbMediaLibrary.Styles[i] = new MusicStyle(subDir.FullName);
                        usbMediaLibrary.Styles[i].SavePlayingSettings = false;
                        usbMediaLibrary.Styles[i].FillAlbumsData();
                        i++;
                    }
                    */
                    usbMediaLibrary.Styles = new MusicStyle[1];
                    usbMediaLibrary.Styles[0] = new MusicStyle(folder);
                    usbMediaLibrary.Styles[0].SavePlayingSettings = false;
                    usbMediaLibrary.Styles[0].FillAlbumsData();
                    PlayingSettings.Default = new PlayingSettings();
                    break;

                case SourceType.CDROM:
                    //currentLibrary = Library.MediaLibrary.CD;
                    cdMediaLibrary = new MediaLibrary();
                    //DirectoryInfo cd = new DirectoryInfo(drive);
                    cdMediaLibrary.Styles = new MusicStyle[1];
                    cdMediaLibrary.Styles[0] = new MusicStyle(folder);
                    cdMediaLibrary.Styles[0].SavePlayingSettings = false;
                    cdMediaLibrary.Styles[0].FillAlbumsData();
                    PlayingSettings.Default = new PlayingSettings();
                    break;
            }
            lastSource = device;
        }

        public static MediaLibrary GetMediaLibrary()
        {
            switch(lastSource)
            {
                case SourceType.DISK:
                    return Library.MediaLibrary.Default;
                case SourceType.USB:
                    return usbMediaLibrary;
                case SourceType.CDROM:
                    return cdMediaLibrary;
                default:
                    return Library.MediaLibrary.Default;
            }
        }
    }
}
