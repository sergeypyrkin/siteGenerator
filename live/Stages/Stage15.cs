using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity.Base;

namespace live.Stages
{

    //КНИГИ
    public class Stage15 : Stage
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

        public string imglistprefix = "data\\food\\";

        public Stage15(string name) : base(name)
        {


        }


        public override void WORK()
        {
            //prefixWork();
            //createList();
            ////createItems();
            //saffixWork();
        }


        private void createItems()
        {
            string template = FILEWORK.ReadFileContent(itemtemplate);
            template = template.Replace("$header2", CONST.header2);
            template = template.Replace("$footer2", CONST.footer2);
            string itemtemplateitem = FILEWORK.ReadFileContent(PATH.templ + "\\" + FOOD._type.ToUpper() + "\\itemfooditem.txt");

            foreach (var item in DATA._FOOD)
            {
                string result = template;
                result = result.Replace("$Id", item.Id.ToString());
                result = result.Replace("$date", item.date.ToString("yyyy-MM-dd"));
                result = result.Replace("$mainImg", item.Id + "/" + item.mainImg);

                string texts = string.Join("<br> <br>", item.txtContents.ToArray());
                result = result.Replace("$text", "<p>" + texts + "</p>");

                string imgres = "";
                List<string> imgs = item.imgs.Where(o => o != DATA.imageDict[item.mainImg]).ToList();
                foreach (string img in imgs)
                {
                    string itimgs = itemtemplateitem;
                    string ig = DATA.RevImageDict[img];
                    itimgs = itimgs.Replace("$image", item.Id + "/" + ig);
                    string bi = "build" + item.Id;
                    itimgs = itimgs.Replace("$fancygroupfull", bi);

                    imgres = imgres + itimgs;

                }
                string youcont = "";
                foreach (string you in item.youtubs)
                {
                    bool isOne = item.youtubs.Count == 1 || (item.youtubs.Last() == you && item.youtubs.Count % 2 != 0);
                    string itimgs = !isOne ? CONST.youtube1 : CONST.youtube2;
                    itimgs = itimgs.Replace("$srcitem", you);
                    youcont = youcont + itimgs;

                }
                result = result.Replace("$youtubs", youcont);

                result = result.Replace("$images", imgres);


                string path = PATH.site + "\\data\\food\\" + item.Id + ".html";

                FILEWORK.WriteFileContent(path, result);
                Console.WriteLine("+ " + path);


            }

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
            template = template.Replace("$numcats", DATA._FOOD.Count.ToString());


            string itemFull = "";
            List<FOOD> friends = DATA._FOOD.OrderByDescending(o => o.Id).ToList();
            foreach (FOOD item in friends)
            {

                if (item.Id == 8)
                {

                }
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
                itemres = itemres.Replace("$text", "<p>" + texts + "</p>");
                itemFull = itemFull + itemres;
            }
            string result = template.Replace("param_models", itemFull);
            FILEWORK.WriteFileContent(opath, result);
            Console.WriteLine("+ " + fpath);

        }


        public void prefixWork()
        {
            //0 инит
            picturesf = PATH.datafood;
            listname = FOOD._type.ToLower() + ".html";
            outfolder = PATH.outf + "\\" + FOOD._type.ToLower();
            fpath = PATH.site + "\\" + listname;
            htmlfolder = PATH.site + "\\data\\" + FOOD._type.ToLower();
            opath = outfolder + "\\" + listname;
            templateList = PATH.templ + "\\" + FOOD._type.ToLower() + "\\catalog.html";
            templateListItem = PATH.templ + "\\" + FOOD._type.ToLower() + "\\listitem.txt";
            imglistprefix = "data\\" + FOOD._type.ToLower();
            itemtemplate = PATH.templ + "\\" + FOOD._type.ToLower() + "\\itemfood.html";
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
