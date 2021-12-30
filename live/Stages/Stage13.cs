using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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



        public int items;
        public int imgs;
        public int youtubs;
        public string sizes;

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
            string listname = "report.html";
            fpath = PATH.site + "\\" + listname;
            templateList = PATH.templ + "\\report.html";
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
            result = executeType("travel", 1, result);
            result = executeType("work", 2, result);
            result = executeType("friends", 3, result);
            result = executeType("sport", 4, result);
            result = executeType("dog", 5, result);
            result = executeType("food", 6, result);
            result = executeType("book", 7, result);

            double catalogSize = 0;
            catalogSize = FILEWORK.sizeOfFolder(PATH.data, ref catalogSize); //Вызываем наш рекурсивный метод
            sizes = String.Format("{0} ГБ", catalogSize);
            result = result.Replace("$1", items.ToString());
            result = result.Replace("$2", imgs.ToString());
            result = result.Replace("$3", youtubs.ToString());
            result = result.Replace("$4", sizes);

            FILEWORK.WriteFileContent(fpath, result);
            Console.WriteLine("+ " + fpath);

        }

        private string executeType(string name, int i, string result)
        {
            int count = 0;
            int img = 0;
            int youtube = 0;
            if (name == "travel")
            {
                var items = DATA._TRAVELS;
                foreach (var item in items)
                {
                    count = count+1;
                    img = img + item.imgs.Count;
                    youtube = youtube + 0;
                }
            }

            if (name == "work")
            {
                var items = DATA._WORKOUT;
                foreach (var item in items)
                {
                    count = count + 1;
                    img = img + item.imgs.Count;
                    youtube = youtube + item.youtubs.Count;
                }
            }

            if (name == "friends")
            {
                var items = DATA._FRIENDS;
                foreach (var item in items)
                {
                    count = count + 1;
                    img = img + item.imgs.Count;
                    youtube = youtube + item.youtubs.Count;
                }
            }

            if (name == "sport")
            {
                var items = DATA._SPORT;
                foreach (var item in items)
                {
                    count = count + 1;
                    img = img + item.imgs.Count;
                    youtube = youtube + item.youtubs.Count;
                }
            }

            if (name == "dog")
            {
                var items = DATA._DOGANDCAT;
                foreach (var item in items)
                {
                    count = count + 1;
                    img = img + item.imgs.Count;
                    youtube = youtube + item.youtubs.Count;
                }
            }

            if (name == "food")
            {
                var items = DATA._FOOD;
                foreach (var item in items)
                {
                    count = count + 1;
                    img = img + item.imgs.Count;
                    youtube = youtube + item.youtubs.Count;
                }
            }

            if (name == "book")
            {
                var items = DATA._BOOK;
                foreach (var item in items)
                {
                    count = count + 1;
                    img = img + item.imgs.Count;
                    youtube = youtube + item.youtubs.Count;
                }
            }
            items = items + count;
            imgs = imgs + img;
            youtubs = youtubs + count;


            result = result.Replace("$col"+i.ToString(), count.ToString());
            result = result.Replace("$img" + i.ToString(), img.ToString());
            result = result.Replace("$youtube" + i.ToString(), youtube.ToString());


            return result;
        }


        public class TypeCounter
        {
            public string name;
            public int count;
            public int img;
            public int youtube;
        }





    }
}
