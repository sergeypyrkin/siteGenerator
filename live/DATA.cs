using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Stages;

namespace live
{
    public static class DATA
    {
        public static bool _newExist;
        public static Dictionary<string, string> imageDict = new Dictionary<string, string>();
        public static Dictionary<string, string> RevImageDict = new Dictionary<string, string>();
        



        //баловство
        public static string getImgFullPath(string path)
        {
            if (path.Contains("\\"))
            {
                return path;
            }
            return imageDict[path];
        }
       
    }
}
