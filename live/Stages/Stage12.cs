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
    public class Stage12 : Stage
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



        public Stage12(string name) : base(name)
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

            last10templ = FILEWORK.ReadFileContent(PATH.templ + "\\index\\last10item.txt");

            //1. Очищение out
            File.Delete(fpath);
        }


        public void createList()
        {
            string template = FILEWORK.ReadFileContent(templateList);
            template = template.Replace("$header1", CONST.header1);
            template = template.Replace("$footer1", CONST.footer1);
            string result = template;
            result = createLast10(result);
            result = createBiGWork(result);

            FILEWORK.WriteFileContent(fpath, result);
            Console.WriteLine("+ " + fpath);

        }

        private string createBiGWork(string result)
        {
            WORKOUT workout = DATA.getContent("WORKOUT", 5) as WORKOUT;
            string youCont = CONST.youtube3;
            youCont = youCont.Replace("$srcitem", workout.youtubs.First());

            result = result.Replace("$workDigYoutube", youCont);
            string texts = string.Join("<br> <br>", workout.txtContents.ToArray());

            result = result.Replace("$workDigText", texts);

            return result;
        }


        //последние 10 новостей
        public string createLast10(string res)
        {
            string result = res;

            List<CONTENT> contents = DATA.get10Last();

            string itemsCont = "";
            foreach (CONTENT item in contents)
            {
                string ii = last10templ;
                ii = ii.Replace("$text", item.date.ToString("yyyy-MM-dd"));
                string i1 = item.mainImg;

                string _type = "";
                if (item is FOOD)
                {
                    _type = "food";
                }

                if (item is WORKOUT)
                {
                    _type = "workout";
                }

                if (item is SPORT)
                {
                    _type = "sport";
                }


                if (item is DOGANDCAT)
                {
                    _type = "dogandcat";
                }


                if (item is FRIENDS)
                {
                    _type = "friends";
                }



                string imglistprefix = "data\\" + _type;

                string imgPath = imglistprefix + "\\" + item.Id + "\\" + i1;
                ii = ii.Replace("$img", imgPath);

                ii = ii.Replace("$link", imglistprefix + "\\" + item.Id + ".html");


                itemsCont = itemsCont + ii;
            }

            result = result.Replace("$last10", itemsCont);




            return result;
        }


    }
}
