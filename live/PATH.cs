using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live
{
    public static class PATH
    {

        //исходная папка
        public static string root = "C:\\Users\\Programmist\\Desktop\\MYLIVE";
        public static string data = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\DATA";
        public static string test = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\TEST";
        public static string _new = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\_NEW";

        public static string _newf = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\_NEW\\FRIENDS";
        public static string _neww = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\_NEW\\WORKOUT";
        public static string _newd = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\_NEW\\DOGANDCAT";




        public static string imgProcessedFile = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\DATA\\parsed.txt";


        public static void init()
        {
            string path = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
            int i = path.IndexOf("MYLIVE");
            path = path.Substring(0, i) + "MYLIVE\\";
            root = path;
            data = root + "DATA";
            test = root + "TEST";
            _new = root + "_NEW";
            _newd = _new + "\\DOGANDCAT";
            _newf = _new + "\\FRIENDS";
            _neww = _new + "\\WORKOUT";

            imgProcessedFile = data + "\\parsed.txt";

        }



        public static void checking()
        {
            Console.WriteLine("CHECKING");
            Console.WriteLine("");
            check(root);
            check(data);
            check(test);
            check(_new);
            check(_newd);
            check(_newf);
            check(_neww);



        }

        public static void check(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine(CONST._INS + path + "    OK");
            }
            else
            {
                Console.WriteLine(CONST._INS + path + "    BAD");
            }
        }

    }
}
