using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity.Base;
using live.Stages;

namespace live
{
    public static class DATA
    {
        public static bool _newExist;
        public static Dictionary<string, string> imageDict = new Dictionary<string, string>();
        public static Dictionary<string, string> RevImageDict = new Dictionary<string, string>();


        public static List<DOGANDCAT> _DOGANDCAT = new List<DOGANDCAT>();
        public static List<FRIENDS> _FRIENDS = new List<FRIENDS>();
        public static List<SPORT> _SPORT = new List<SPORT>();
        public static List<WORKOUT> _WORKOUT = new List<WORKOUT>();
        public static List<FOOD> _FOOD = new List<FOOD>();





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
