using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using live.Entity.Base;

namespace live.Stages
{
    //randomopener.js
    public class Stage14 : Stage
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



        public int items;
        public int imgs;
        public int youtubs;
        public string sizes;

        public string last10templ;
        public Stage14(string name) : base(name)
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
            string listname = "randomopener.js";
            fpath = PATH.site + "\\js\\" + listname;
            templateList = PATH.templ + "\\randomopener.js";
            opath = outfolder + "\\" + listname;


            //1. Очищение out
            File.Delete(fpath);

        }


        public void createList()
        {
            string template = FILEWORK.ReadFileContent(templateList);
            string result = template;


            List<string> urls = new List<string>();

            foreach (var travel in DATA._TRAVELS)
            {
                string link = "http://kapybara.ru/data/travel/" + travel.Id.ToString() + ".html";
                urls.Add("'" + link + "'");

            }

            foreach (var content in DATA._CONTENT)
            {
                if (content is FOOD)
                {
                    continue;
                }
                urls.Add("'"+content.link+ "'");
            }
            var lr = String.Join(", \n         ", urls.ToArray());
            result = result.Replace("$urls", lr);
            FILEWORK.WriteFileContent(fpath, result);
            Console.WriteLine("+ " + fpath);

        }
    }
}
