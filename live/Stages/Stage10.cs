using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity.Base;

namespace live.Stages
{
    public class Stage10: Stage
    {

        public static string outfolder;
        public static string htmlfolder;
        public static string listname;                  //TRAVEL.html;
        public static string opath;                     //out//TRAVEL.html;
        public static string fpath;                     //ss.ru//TRAVEL.html;
        public static string picturesf;
        public static string templateList;
        public static string templateListItem;
        public static string itemtemplate;              //для отдельной страницы
        public string imglistprefix = "data\\TRAVEL\\";


        public override void WORK()
        {
            prefixWork();
            createList();
            //createItems();
            saffixWork();
        }

        public void createList()
        {
            string template = FILEWORK.ReadFileContent(templateList);
            string itemtemplate = FILEWORK.ReadFileContent(templateListItem);
            template = template.Replace("$header1", CONST.header1);
            template = template.Replace("$footer1", "");
            template = template.Replace("param_models", itemtemplate);

            string itemFull = "";
            List<WORKOUT> works = DATA._WORKOUT.OrderByDescending(o => o.Id).ToList();
            foreach (WORKOUT item in works)
            {
                //string itemres = itemtemplate;
                //string bi = "build" + item.Id;


                //itemres = itemres.Replace("$fancygroupfull", bi);

                //itemres = itemres.Replace("$fancygroupfull", bi);
                //itemres = itemres.Replace("$title", item.date.ToString("yyyy-MM-dd"));

                //string texts = string.Join("<br> <br>", item.txtContents.ToArray());
                //itemres = itemres.Replace("$text", texts);

                //List<string> used = new List<string>();
                //string i1 = item.mainImg;
                //string sname = DATA.imageDict[i1];

                //used.Add(sname);
                //itemres = itemres.Replace("$image1", imglistprefix + "\\" + item.Id + "\\" + i1);

                //string i2 = imgName(used, item);
                //itemres = itemres.Replace("$image2", imglistprefix + "\\" + item.Id + "\\" + i2);

                //string i3 = imgName(used, item);
                //itemres = itemres.Replace("$image3", imglistprefix + "\\" + item.Id + "\\" + i3);


                //string i4 = imgName(used, item);
                //itemres = itemres.Replace("$image4", imglistprefix + "\\" + item.Id + "\\" + i4);

                //string i5 = imgName(used, item);
                //itemres = itemres.Replace("$image5", imglistprefix + "\\" + item.Id + "\\" + i5);

                //string i6 = imgName(used, item);
                //itemres = itemres.Replace("$image6", imglistprefix + "\\" + item.Id + "\\" + i6);


                //string i7 = imgName(used, item);
                //itemres = itemres.Replace("$image7", imglistprefix + "\\" + item.Id + "\\" + i7);


                //itemres = itemres.Replace("$link", imglistprefix + "\\" + item.Id + ".html");

                //itemFull = itemFull + itemres;
            }
            string result = template.Replace("$items", itemFull);
            FILEWORK.WriteFileContent(opath, result);
            Console.WriteLine("+ " + fpath);
        }

        public void saffixWork()
        {
            //4. Копирование файлов
            File.Copy(opath, fpath);

            //5. Копирование из Pictures
            FILEWORK.CopyDir(picturesf, htmlfolder);
        }

        public void prefixWork()
        {
            //0 инит
            picturesf = PATH.datat;
            listname = TRAVEL._type.ToLower() + ".html";
            outfolder = PATH.outf + "\\" + TRAVEL._type.ToLower();
            fpath = PATH.site + "\\" + listname;
            htmlfolder = PATH.site + "\\data\\" + TRAVEL._type.ToLower();
            opath = outfolder + "\\" + listname;
            templateList = PATH.templ + "\\" + TRAVEL._type.ToLower() + "\\" + "catalog.html";
            templateListItem = PATH.templ + "\\" + TRAVEL._type.ToLower() + "\\" + "listitem.txt";
            imglistprefix = "data\\" + TRAVEL._type.ToLower();
            itemtemplate = PATH.templ + "\\" + TRAVEL._type.ToLower() + "\\itemTRAVEL.html";
            //1. Очищение out
            File.Delete(fpath);

            FILEWORK.clearDir(outfolder);

            //2. Очищаем html
            FILEWORK.clearDir(htmlfolder);
        }


        public Stage10(string name) : base(name)
        {
        }
    }
}
