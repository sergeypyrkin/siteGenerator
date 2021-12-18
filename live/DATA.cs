using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using live.Entity;
using live.Entity.Base;
using live.Stages;

namespace live
{
    public static class DATA
    {
        public static bool _newExist;
        public static bool forceUpdate = false; // если true то будет перезаписывать все файлы
        public static Dictionary<string, string> imageDict = new Dictionary<string, string>();
        public static Dictionary<string, string> RevImageDict = new Dictionary<string, string>();
        public static Dictionary<string, bool> longImgDict = new Dictionary<string, bool>(); //определяем широкоформатность

        public static List<CONTENT> _CONTENT = new List<CONTENT>();
        public static List<DOGANDCAT> _DOGANDCAT = new List<DOGANDCAT>();
        public static List<FRIENDS> _FRIENDS = new List<FRIENDS>();
        public static List<SPORT> _SPORT = new List<SPORT>();
        public static List<WORKOUT> _WORKOUT = new List<WORKOUT>();
        public static List<FOOD> _FOOD = new List<FOOD>();
        public static List<BOOK> _BOOK = new List<BOOK>();

        public static List<TRAVEL> _TRAVELS = new List<TRAVEL>();
        public static Dictionary<string, string> _newContent = new Dictionary<string, string>();

        public static bool isAddItem(CONTENT content)
        {
            if (forceUpdate)
            {
                return true;
            }

            string _type = "";
            if (content is WORKOUT)
            {
                _type = "WORKOUT";
            }

            if (content is FRIENDS)
            {
                _type = "FRIENDS";
            }

            if (content is FOOD)
            {
                _type = "FOOD";
            }

            if (content is SPORT)
            {
                _type = "SPORT";
            }

            if (content is DOGANDCAT)
            {
                _type = "DOGANDCAT";
            }
            int _id = content.Id;
            string spref = _type + "_" + _id;
            if (_newContent.ContainsKey(spref))
            {
                return true;
            }
            return false;
        }

        public static List<CONTENT> get10Last()
        {
            List<CONTENT> result = new List<CONTENT>();
            var list = DATA._CONTENT.Where(o=>o is WORKOUT || o is FRIENDS || o is DOGANDCAT || o is SPORT).OrderByDescending(o => o.date).ToList();
            int i = 0;
            foreach (var cont in list)
            {
                if (i > CONST.MAX_INDEX_NEWS_LENGTH)
                {
                    break;
                }
                result.Add(cont);
                i++;

            }
            return result;
        }


        //берем определенный контент
        public static CONTENT getContent(String _type, int id)
        {
            CONTENT cont = null;

            switch (_type)
            {
                case "DOGANDCAT":
                    return _DOGANDCAT.FirstOrDefault(o => o.Id == id);

                    break;
                case "FRIENDS":
                    return _FRIENDS.FirstOrDefault(o => o.Id == id);

                    break;
                case "SPORT":
                    return _SPORT.FirstOrDefault(o => o.Id == id);

                    break;
                case "WORKOUT":
                    return _WORKOUT.FirstOrDefault(o => o.Id == id);

                    break;
                case "FOOD":
                    return _FOOD.FirstOrDefault(o => o.Id == id);
                    break;
                case "BOOK":
                    return _BOOK.FirstOrDefault(o => o.Id == id);
                    break;

                default:
                    break;
            }
            return cont;
        }

        //берем определенное путешествие
        public static TRAVEL getTravel(int id)
        {
            TRAVEL travel = null;
            return _TRAVELS.FirstOrDefault(o => o.Id == id);
        }








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
