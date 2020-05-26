using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live.Stages
{

    //contact.html
    public class Stage11: Stage
    {


        public static string outfolder;
        public static string htmlfolder;
        public static string listname;                  //workout.html;
        public static string opath;                     //out//workout.html;
        public static string fpath;                     //ss.ru//workout.html;
        public static string picturesf;
        public static string templateList;
        public static string templateListItem;
        public static string itemtemplate;              //для отдельной страницы


        public Stage11(string name) : base(name)
        {
        }

        public override void WORK()
        {
            prefixWork();
            createList();
        }

        public void prefixWork()
        {
            //0 инит
            string listname = "contact.html";
            fpath = PATH.site + "\\" + listname;
            templateList = PATH.templ + "\\contact.html";
            opath = outfolder + "\\" + listname;

            //1. Очищение out
            File.Delete(fpath);
        }


        public void createList()
        {
            string template = FILEWORK.ReadFileContent(templateList);
            template = template.Replace("$header1", CONST.header1);
            template = template.Replace("$footer1", CONST.footer1);
            string result  = template;
         
            FILEWORK.WriteFileContent(fpath, result);
            Console.WriteLine("+ " + fpath);

        }

    }
}
