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

        public static void init()
        {
            string path = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
            int i = path.IndexOf("MYLIVE");
            path = path.Substring(0, i) + "MYLIVE\\";
            root = path;
            data = root + "DATA";
            test = root + "TEST";

            //root = Directory.GetCurrentDirectory;
        }



        public static void checking()
        {
            Console.WriteLine("CHECKING");
            Console.WriteLine("");
            check(root);
            check(data);
            check(test);

        }

        public static void check(string path)
        {
            if (Directory.Exists(root))
            {
                Console.WriteLine(CONST.ins + path + "    OK");
            }
            else
            {
                Console.WriteLine(CONST.ins + path + "    BAD");

            }
        }

    }
}
