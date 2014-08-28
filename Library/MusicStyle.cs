using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MCLauncher.Library
{
    [Serializable()]
    class MusicStyle
    {
        public string StyleRootFolder;          //风格类型
        public bool IsNetworkFolder;            //是否为网络文件夹
        public string[] MusicAlbums;            //所有音乐文件夹列表
        public bool SavePlayingSettings;       //是否保存播放设置

        [NonSerialized()]
        public bool SearchCompleted = false;    //是否已搜索完毕
        [NonSerialized()]
        public long ElapsedMS;                  //搜索所用的时间

        [NonSerialized()]
        private FolderOperator folderoperator;

        [NonSerialized()]
        private int albumIndex;

        [NonSerialized()]
        private Random random = new Random();

        public MusicStyle()
        {
            SearchCompleted = true;
            albumIndex = 0;
            SavePlayingSettings = true;
        }

        public MusicStyle(string rootFolder)
        {
            StyleRootFolder = rootFolder;
            SearchCompleted = false;
            SavePlayingSettings = true;
            albumIndex = 0;
            random = new Random();

            DirectoryInfo dir = new DirectoryInfo(rootFolder);
            DriveInfo drive = new DriveInfo(dir.Root.Name);
            if (drive.DriveType == DriveType.Network)
                IsNetworkFolder = true;
        }

        public string GetLastAlbum(bool startup)
        {
            if (MusicAlbums.Length == 0)
                return null;

            if (Settings.Default.RandomPlay && startup)
            {
                return RandomAlbum();
            }
            else
            {
                albumIndex = 0;
                for (int i = 0; i < MusicAlbums.Length; i++)
                {
                    if (MusicAlbums[i] == PlayingSettings.Default.LastAlbum)
                    {
                        albumIndex = i;
                    }
                }
                albumIndex = (albumIndex >= MusicAlbums.Length) ? 0 : albumIndex;
            }

            return MusicAlbums[albumIndex];
        }

        //填充所有音乐文件夹数据
        public void FillAlbumsData()
        {
            ArrayList alAlbums = new ArrayList();

            folderoperator = new FolderOperator(StyleRootFolder);

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            SearchMusicFolders(new DirectoryInfo(StyleRootFolder), alAlbums);

            watch.Stop();
            ElapsedMS = watch.ElapsedMilliseconds;

            MusicAlbums = (string[])alAlbums.ToArray(typeof(string));

            alAlbums.Clear();
            alAlbums = null;

            SearchCompleted = true;
        }

        private void SearchMusicFolders(DirectoryInfo currentFolder, ArrayList albums)
        {
            if (folderoperator.FolderContainsMusic(currentFolder))
            {
                albums.Add(currentFolder.FullName);
            }

            DirectoryInfo[] subDirs = currentFolder.GetDirectories();
            for (int i = 0; i < subDirs.Length; i++)
            {
                SearchMusicFolders(subDirs[i], albums);
            }
        }

        //随机专辑
        public string RandomAlbum()
        {
            if (MusicAlbums.Length == 0)
                return null;

            if (random == null)
                random = new Random();

            albumIndex = random.Next(MusicAlbums.Length);

            PlayingSettings.Default.LastAlbum = MusicAlbums[albumIndex];
            if (SavePlayingSettings)
            {
                PlayingSettings.Default.Save();
            }

            return MusicAlbums[albumIndex];
        }

        //获得相邻的专辑
        public string GetBrotherAlbum(bool next)
        {
            if (MusicAlbums.Length == 0)
                return null;

            int index = next ? albumIndex + 1 : albumIndex - 1;
            if (index < 0)
                index = MusicAlbums.Length - 1;
            else if (index >= MusicAlbums.Length)
                index = 0;

            albumIndex = index;

            PlayingSettings.Default.LastAlbum = MusicAlbums[albumIndex];
            if (SavePlayingSettings)
            {
                PlayingSettings.Default.Save();
            }

            return MusicAlbums[albumIndex];
        }
    }
}
