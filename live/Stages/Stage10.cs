using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using live.Entity.Base;

namespace live.Stages
{

    //TRAVEL
    public class Stagef10: Stage
    {

        public static string outfolder;
        public static string htmlfolder;
        public static string listname;                      //TRAVEL.html;
        public static string opath;                         //out//TRAVEL.html;
        public static string fpath;                         //ss.ru//TRAVEL.html;
        public static string picturesf;
        public static string templateList;
        public static string templateListItem;
        public static string itemtemplate;                  //для отдельной страницы
        public string imglistprefix = "data\\TRAVEL\\";

        public string liItem;
        public string diItem;

        public string imgtemplate1 = "";


        public override void WORK()
        {
            prefixWork();
            createList();
            createItems();
            saffixWork();
        }

        public void createItems()
        {
            imgtemplate1 = FILEWORK.ReadFileContent(PATH.templ + "\\" + TRAVEL._type.ToLower() + "\\img1item.txt");
            liItem = FILEWORK.ReadFileContent(PATH.templ + "\\" + TRAVEL._type.ToLower() + "\\ulitem.txt");
            diItem = FILEWORK.ReadFileContent(PATH.templ + "\\" + TRAVEL._type.ToLower() + "\\diitem.txt");

            string template = FILEWORK.ReadFileContent(itemtemplate);
            template = template.Replace("$header2", CONST.header2);
            template = template.Replace("$footer2", CONST.footer2);
            // string itemtemplateitem = FILEWORK.ReadFileContent(PATH.templ + "\\" + WORKOUT._type.ToUpper() + "\\itemworkoutitem.txt");

            foreach (var item in DATA._TRAVELS)
            {
                string result = template;
                result = result.Replace("$title", item.name);
                // 
                result = reseatMainInfo(item,  result);

                result = reseatTextInfo(item, result);


                string path = PATH.site + "\\data\\travel\\" + item.Id + ".html";

                FILEWORK.WriteFileContent(path, result);
                Console.WriteLine("+ " + path);


            }

        }

        private string reseatTextInfo(TRAVEL travel, string result)
        {

            string licontext = "";

            //тут будем сортированно выводить
            List<TRAVEL.LSTEXT> lstexts = new List<TRAVEL.LSTEXT>();
            foreach (string s in travel.order)
            {
                TRAVEL.LSTEXT item = travel.destrictions[s];
                lstexts.Add(item);
            }

            foreach (TRAVEL.LSTEXT item in lstexts)
            {
                string templ = liItem;
                string iday = item.day;
                templ = templ.Replace("$Id", iday.ToString());
                string rr = iday == travel.order.First() ? "active" : "";
                templ = templ.Replace("$active", rr);

                licontext = licontext + templ;
            }

            //foreach (KeyValuePair<string, TRAVEL.LSTEXT> keyValue in travel.destrictions)
            //{
            //    string templ = liItem;
            //    string iday = keyValue.Key;
            //    templ = templ.Replace("$Id", iday.ToString());
            //    string rr = iday == "1" ? "active" : "";
            //    templ = templ.Replace("$active", rr);

            //    licontext = licontext + templ;
            //}

            result = result.Replace("$liitems", licontext);



            string dicontext = "";

            foreach (TRAVEL.LSTEXT item in lstexts)
            {
                TRAVEL.LSTEXT val = item;
                string lena = val.l;
                lena = lena.Replace("\n", "<br>");

                string templ = diItem;
                string iday = item.day;
                templ = templ.Replace("$Id", iday.ToString());
                string rr = iday == travel.order.First() ? "active" : "";
                templ = templ.Replace("$active", rr);
                string s1 = "<div class='nametravelwho'>Лена</div><div class='first_div_capital_blue'><p >" + lena + "</p></div>";

                string sergey = val.s;
                sergey = sergey.Replace("\n", "<br>");

                string s2 = "<div class='nametravelwho'>Сергей</div><div class='first_div_capital_green'><p >" + sergey + "</p></div>"; ;
                templ = templ.Replace("$text", s1 + s2);

                dicontext = dicontext + templ;
            }
            //foreach (KeyValuePair<string, TRAVEL.LSTEXT> keyValue in travel.destrictions)
            //{
            //    TRAVEL.LSTEXT val = keyValue.Value;
            //    string lena = val.l;
            //    lena = lena.Replace("\n", "<br>");

            //    string templ = diItem;
            //    string iday = keyValue.Key;
            //    templ = templ.Replace("$Id", iday.ToString());
            //    string rr = iday == "1" ? "active" : "";
            //    templ = templ.Replace("$active", rr);
            //    string s1 = "<div class='nametravelwho'>Лена</div><div class='first_div_capital_blue'><p >" + lena + "</p></div>";

            //    string sergey = val.s;
            //    sergey = sergey.Replace("\n", "<br>");

            //    string s2 = "<div class='nametravelwho'>Сергей</div><div class='first_div_capital_green'><p >" + sergey + "</p></div>"; ;
            //    templ = templ.Replace("$text", s1 + s2);

            //    dicontext = dicontext + templ;
            //}

            result = result.Replace("$diitems", dicontext);


            return result;
        }

        private string reseatMainInfo(TRAVEL travel, string result)
        {

            List<string> images = new List<string>();
            images.AddRange(travel.mainIng);
            foreach (string img in travel.imgs)
            {
                string ig = DATA.RevImageDict[img];
                if (!images.Contains(ig))
                {
                    images.Add(ig);
                }
            }
            string res = "";
            foreach (string img in images)
            {
                string itimgs = imgtemplate1;
            //    string ig = DATA.RevImageDict[img];
                itimgs = itimgs.Replace("$image1", travel.Id + "/" + img);
                res = res + itimgs;
            }

            result = result.Replace("$items1", res);
            result = result.Replace("$title", travel.name);
            result = result.Replace("$ldate", travel.ldate);
            result = result.Replace("$desc", travel.description);
            result = result.Replace("$price", travel.lcount);
            result = result.Replace("$praceS", travel.praceS);
            result = result.Replace("$praceL", travel.praceL);


            return result;
        }

        public void createList()
        {
            string template = FILEWORK.ReadFileContent(templateList);
            string itemtemplate = FILEWORK.ReadFileContent(templateListItem);
            template = template.Replace("$header1", CONST.header1);
            template = template.Replace("$footer1", "");




            string itemFull = "";
            List<TRAVEL> travels = DATA._TRAVELS.OrderByDescending(o => o.Id).ToList();
            foreach (TRAVEL item in travels)
            {
                string itemres = itemtemplate;

                int index = 1;
                foreach (string img in item.mainIng)
                {
                    string sname = DATA.imageDict[img];
                    string rr = "$image" + index;
                    itemres = itemres.Replace(rr, imglistprefix + "\\" + item.Id + "\\" + img);
                    index++;
                }

                itemres = itemres.Replace("$city", item.name);
                itemres = itemres.Replace("$date", item.ldate);
                itemres = itemres.Replace("$price", item.lcount);
                itemres = itemres.Replace("$link", imglistprefix + "\\" + item.Id + ".html");
                itemFull = itemFull + itemres;
            }
            string result = template.Replace("param_models", itemFull);
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
            itemtemplate = PATH.templ + "\\" + TRAVEL._type.ToLower() + "\\item.html";
            //1. Очищение out
            File.Delete(fpath);

            FILEWORK.clearDir(outfolder);

            //2. Очищаем html
            FILEWORK.clearDir(htmlfolder);
        }


        public Stagef10(string name) : base(name)
        {
        }
    }
}
