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


        }


        public override void WORK()
        {
            prefixWork();
            createList();
            //createItems();
            saffixWork();
        }


        public string imgName(List<string> used, WORKOUT item)
        {
            string img = item.imgs.FirstOrDefault(o => !used.Contains(o));
            if (img != null)
            {
                used.Add(img);
                string name = DATA.RevImageDict[img];
                return name;

            }
            return "";
        }


        public void createList()
        {
            string template = FILEWORK.ReadFileContent(templateList);
            string itemtemplate = FILEWORK.ReadFileContent(templateListItem);
            template = template.Replace("$header1", CONST.header1);
            template = template.Replace("$footer1", "");

            string itemFull = "";
            List<FRIENDS> friends = DATA._FRIENDS.OrderByDescending(o => o.Id).ToList();
            foreach (FRIENDS item in friends)
            {
                string itemres = itemtemplate;

                int index = 1;
                //foreach (string img in item.mainIng)
                //{
                //    string sname = DATA.imageDict[img];
                //    string rr = "$image" + index;
                //    itemres = itemres.Replace(rr, imglistprefix + "\\" + item.Id + "\\" + img);
                //    index++;
                //}

                 string rr = "$image" + index;
                 itemres = itemres.Replace(rr, imglistprefix + "\\" + item.Id + "\\" + item.mainImg);
                //itemres = itemres.Replace("$city", item.name);
                itemres = itemres.Replace("$date", item.date.ToString("yyyy-MM-dd"));
                //itemres = itemres.Replace("$price", item.lcount);
                itemres = itemres.Replace("$link", imglistprefix + "\\" + item.Id + ".html");

                string texts = string.Join("<br>", item.txtContents.ToArray());
                itemres = itemres.Replace("$text","<p>" +texts+"</p>");
                itemFull = itemFull + itemres;
            }
            string result = template.Replace("param_models", itemFull);
            FILEWORK.WriteFileContent(opath, result);
            Console.WriteLine("+ " + fpath);

        }


        public void prefixWork()
        {
            //0 инит
            picturesf = PATH.dataf;
            listname = FRIENDS._type.ToLower() + ".html";
            outfolder = PATH.outf + "\\" + FRIENDS._type.ToLower();
            fpath = PATH.site + "\\" + listname;
            htmlfolder = PATH.site + "\\data\\" + FRIENDS._type.ToLower();
            opath = outfolder + "\\" + listname;
            templateList = PATH.templ + "\\" + FRIENDS._type.ToLower() + "\\catalog.html";
            templateListItem = PATH.templ + "\\" + FRIENDS._type.ToLower() + "\\listitem.txt";
            imglistprefix = "data\\" + FRIENDS._type.ToLower();
            itemtemplate = PATH.templ + "\\" + FRIENDS._type.ToLower() + "\\itemworkout.html";
            //1. Очищение out
            File.Delete(fpath);

            FILEWORK.clearDir(outfolder);

            //2. Очищаем html
            FILEWORK.clearDir(htmlfolder);
        }

        public void saffixWork()
        {
            //4. Копирование файлов
            File.Copy(opath, fpath);

            //5. Копирование из Pictures
            FILEWORK.CopyDir(picturesf, htmlfolder);
        }

    }
}
