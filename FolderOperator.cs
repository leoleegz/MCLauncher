using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace MCLauncher
{
    class FolderOperator
    {
        private string RootFolder;

        public static string LastSelectedFolder;

        private Random rnd;

        public FolderOperator(string rootFolder)
        {
            RootFolder = new DirectoryInfo(rootFolder).FullName;
            rnd = new Random();
        }

        // 随机挑选一个文件夹
        public string RandomFolder()
        {
            DirectoryInfo diRoot = new DirectoryInfo(RootFolder);
            try
            {
                // 循环100次
                for (int i = 0; i < 100; i++)
                {
                    DirectoryInfo folder = DrillDownMusicFolder(diRoot);
                    if (folder != null)
                        return folder.FullName;
                }
                
            }
            catch (Exception e)
            {
            }
            return null;
        }

        // 从当前文件夹往里随机挑选一个音乐文件夹
        private DirectoryInfo DrillDownMusicFolder(DirectoryInfo currentFolder)
        {
            // 如果当前文件夹有音乐文件
            if (GetPlayableFileList(currentFolder) != null)
            {
                return currentFolder;
            }

            DirectoryInfo[] subFolders = currentFolder.GetDirectories();
            if (subFolders.Length == 0)
            {
                //已经没有子文件夹了
                return null;
            }

            // 如果还有子文件夹，则随机挑选一个文件夹
            int index = rnd.Next(subFolders.Length);
            return DrillDownMusicFolder(subFolders[index]);
        }

        // 从当前文件夹往上搜寻音乐文件夹
        private DirectoryInfo DrillUpMusicFolder(DirectoryInfo currrentFolder)
        {
            // 如果当前文件夹有音乐文件
            if (GetPlayableFileList(currrentFolder) != null)
            {
                return currrentFolder;
            }

            // 如果已经搜索到了最顶层
            if (currrentFolder.FullName == RootFolder)
            {
                return null;
            }

            return DrillUpMusicFolder(currrentFolder.Parent);
        }

        public static string GetPlayableFileList(string folder)
        {
            return GetPlayableFileList(new DirectoryInfo(folder));
        }

        //获取一个文件夹下可播放的文件列表
        private static string GetPlayableFileList(DirectoryInfo currentFolder)
        {
            //搜索各种可播放的文件
            foreach (string pattern in Library.Settings.MusicFileType)
            {
                FileInfo[] fis = currentFolder.GetFiles(pattern);

                if (fis.Length > 0)
                {
                    //string[] files = fis.Join<string, FileInfo, int, ();
                    StringBuilder musicfiles = new StringBuilder();
                    foreach (FileInfo fi in fis)
                    {
                        musicfiles.Append("\"");
                        musicfiles.Append(fi.FullName);
                        musicfiles.Append("\" ");
                    }
                    return musicfiles.ToString();
                }
            }
            return null;
        }

        //文件夹下面是否包含可播放的音乐文件
        public bool FolderContainsMusic(DirectoryInfo folder)
        {
            //搜索各种可播放的文件
            try
            {
                foreach (string pattern in Library.Settings.MusicFileType)
                {
                    if (folder.GetFiles(pattern).Length > 0)
                    {
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }

        //得到相邻的音乐文件夹
        public string GetNeighbourFolder(string folder, bool next)
        {
            DirectoryInfo di = GetNeighbourFolder(new DirectoryInfo(folder), next);
            if (di != null)
                return di.FullName;
            else
                return null;
        }

        private DirectoryInfo GetNeighbourFolder(DirectoryInfo folder, bool next)
        {
            DirectoryInfo[] brothers = folder.Parent.GetDirectories();
            int currentIndex = 0;

            for (int i = 0; i < brothers.Length; i++)
            {
                if (brothers[i].FullName == folder.FullName)
                {
                    currentIndex = i;
                    break;
                }
            }

            int nextIndex = next ? currentIndex + 1 : currentIndex - 1;

            if (nextIndex == brothers.Length)
                nextIndex = 0;
            else if (nextIndex == 0)
                nextIndex = brothers.Length - 1;

            return brothers[nextIndex];
        }

        //获得最近的可播放的文件夹
        public string GetNearestMusicFolder(string folder, bool next)
        {
            DirectoryInfo di = GetNearestMusicFolder(new DirectoryInfo(folder), next);
            if (di != null)
                return di.FullName;
            else
                return null;
        }

        private DirectoryInfo GetNearestMusicFolder(DirectoryInfo currentFolder, bool next)
        {
            // 已经到了最顶层的文件夹
            if (currentFolder.FullName == RootFolder)
                return null;

            DirectoryInfo brother = GetNeighbourFolder(currentFolder, next);

            try
            {
                DirectoryInfo diFound = null;

                // 循环10次
                for (int j = 0; j < 10; j++)
                {
                    diFound = DrillDownMusicFolder(brother);
                    if (diFound != null)
                        return diFound;
                }

                // 如果找10次还没找到，就换上一级文件夹继续查找
                if (diFound == null)
                {
                    return GetNearestMusicFolder(currentFolder.Parent, next);
                }
            }
            catch
            { }
            return null;
        }

        public string GetNextFolder(string currentFolder)
        {
            DirectoryInfo diCurrent = new DirectoryInfo(currentFolder);
            //如果当前文件夹没有兄弟文件夹
            while (diCurrent.Parent.GetDirectories().Length == 1)
            {
                diCurrent = diCurrent.Parent;
            }
            return null;
        }

        public string GetPrevFolder(string currentFolder)
        {
            return null;
        }
    }
}
