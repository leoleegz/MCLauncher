using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCLauncher.Library
{
    [Serializable()]
    class LibrayType
    {
        public const string FIXED = "fixed";            //本地硬盘
        public const string NETWORK = "network";        //网络共享文件
        public const string UDISK = "udisk";            //U盘文件
        public const string CDROM = "cdrom";            //光盘
    }
}
