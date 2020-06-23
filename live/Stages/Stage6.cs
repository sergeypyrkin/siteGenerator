using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity.Base;

namespace live.Stages
{
    public class Stage6: Stage
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

        public string imglistprefix = "data\\friends\\";

        public Stage6(string name) : base(name)
        {

            prefixWork();
            //createList();
            //createItems();
            //saffixWork();
        }


        public void prefixWork()
        {
            //0 инит
            picturesf = PATH.dataw;
            listname = FRIENDS._type.ToLower() + ".html";
            outfolder = PATH.outf + "\\" + FRIENDS._type.ToLower();
            fpath = PATH.site + "\\" + listname;
            htmlfolder = PATH.site + "\\data\\" + FRIENDS._type.ToLower();
            opath = outfolder + "\\" + listname;
            templateList = PATH.templ + "\\" + FRIENDS._type.ToLower() + "\\" + FRIENDS._type.ToLower() + "list.html";
            templateListItem = PATH.templ + "\\" + FRIENDS._type.ToLower() + "\\" + FRIENDS._type.ToLower() + "listitem.txt";
            imglistprefix = "data\\" + FRIENDS._type.ToLower();
            itemtemplate = PATH.templ + "\\" + FRIENDS._type.ToLower() + "\\itemworkout.html";
            //1. Очищение out
            File.Delete(fpath);

            FILEWORK.clearDir(outfolder);

            //2. Очищаем html
            FILEWORK.clearDir(htmlfolder);
        }

    }
}
