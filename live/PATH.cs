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

        public static void init()
        {
            string path = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
            int i = path.IndexOf("MYLIVE");
            path = path.Substring(0, i) + "MYLIVE\\";
            root = path;
            //root = Directory.GetCurrentDirectory;
        }



        public static void checking()
        {
            Console.WriteLine("CHECKING");
            Console.WriteLine("");
            check(root);
        }

        public static void check(string path)
        {
            if (Directory.Exists(root))
            {
                Console.WriteLine(path + "    OK");
            }
            else
            {
                Console.WriteLine(path + "    BAD");

            }
        }

    }
}
