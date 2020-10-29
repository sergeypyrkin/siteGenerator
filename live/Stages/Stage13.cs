using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using live.Entity;
using live.Entity.Base;

namespace live.Stages
{
    //index.html
    public class Stage13 : Stage
    {

        public static string outfolder;
        public static string htmlfolder;
        public static string listname;                  //index.html;
        public static string opath;                     //out//index.html;
        public static string fpath;                     //ss.ru//index.html;
        public static string picturesf;
        public static string templateList;
        public static string templateListItem;
        public static string itemtemplate;              //для отдельной страницы

        public string last10templ;



        public Stage13(string name) : base(name)
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
            string listname = "index.html";
            fpath = PATH.site + "\\" + listname;
            templateList = PATH.templ + "\\index.html";
            opath = outfolder + "\\" + listname;


            //1. Очищение out
            File.Delete(fpath);
        }


        public void createList()
        {
            string template = FILEWORK.ReadFileContent(templateList);
            template = template.Replace("$header1", CONST.header1);
            template = template.Replace("$footer1", CONST.footer1);
            string result = template;

            FILEWORK.WriteFileContent(fpath, result);
            Console.WriteLine("+ " + fpath);

        }



    }
}
