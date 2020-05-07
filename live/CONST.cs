using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live
{
    public static class CONST
    {
        public static string _INS = "              ";
        
        public static string _INSERR = "!!!!!!!!!!!!!";

        public static string _INS2 =  new String(' ', 20);


        public static string header1;
        public static string footer1;

        public static string header2;
        public static string footer2;

        public static string youtube1;

        public static void INIT()
        {
            header1 = FILEWORK.ReadFileContent(PATH.templ + "\\header1.txt");
            footer1 = FILEWORK.ReadFileContent(PATH.templ + "\\footer1.txt");

            header2 = FILEWORK.ReadFileContent(PATH.templ + "\\header2.txt");
            footer2 = FILEWORK.ReadFileContent(PATH.templ + "\\footer2.txt");

            youtube1 = FILEWORK.ReadFileContent(PATH.templ + "\\youtube1.txt");


        }

    }
}
