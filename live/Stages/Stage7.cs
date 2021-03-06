﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity.Base;

namespace live.Stages
{

    //dogandcat
    public class Stage7 : Stage
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

        public string imglistprefix = "data\\dogandcat\\";

        public Stage7(string name) : base(name)
        {


        }


        public override void WORK()
        {
            prefixWork();
            createList();
            createItems();
            saffixWork();
        }


        private void createItems()
        {
            string template = FILEWORK.ReadFileContent(itemtemplate);
            template = template.Replace("$header2", CONST.header2);
            template = template.Replace("$footer2", CONST.footer2);
            string itemtemplateitem = FILEWORK.ReadFileContent(PATH.templ + "\\" + DOGANDCAT._type.ToUpper() + "\\itemdogandcatitem.txt");

            foreach (var item in DATA._DOGANDCAT)
            {
                string result = template;
                result = result.Replace("$Id", item.Id.ToString());
                result = result.Replace("$date", item.date.ToString("yyyy-MM-dd"));
                result = result.Replace("$mainImg", item.Id + "/" + item.mainImg);

                string texts = string.Join("<br> <br>", item.txtContents.ToArray());
                result = result.Replace("$text", "<p>" + texts + "</p>");
                string bi = "build" + item.Id;
                //боковые КОНТЕНТ //либо ютуб первый либо картинки
                if (item.hasYoutube)
                {
                    //правый ютуб
                    string you = item.you1[0];
                    string ycont = CONST.youtubeRight;
                    ycont = ycont.Replace("$srcitem", you);
                    result = result.Replace("$leftcontent", ycont);
                }
                else
                {
                    //правые картинки
                    string imgres = "";
                    List<string> imgs = item.img1;
                    foreach (string img in imgs)
                    {
                        string itimgs = itemtemplateitem;
                        string ig = DATA.RevImageDict[img];
                        itimgs = itimgs.Replace("$image", item.Id + "/" + ig);
                        imgres = imgres + itimgs;
                    }
                    result = result.Replace("$leftcontent", imgres);
                }

                //отстаточные картинки
                string imgsco = "";
                List<string> imgs2 = item.img2;
                foreach (string img in imgs2)
                {
                    string itimgs = itemtemplateitem;
                    string ig = DATA.RevImageDict[img];
                    itimgs = itimgs.Replace("$image", item.Id + "/" + ig);
                    imgsco = imgsco + itimgs;
                }
                result = result.Replace("$images", imgsco);

                string youcont = "";
                foreach (string you in item.you2)
                {
                    bool isOne = item.you2.Count == 1 || (item.you2.Last() == you && item.you2.Count % 2 != 0);
                    string itimgs = !isOne ? CONST.youtube1 : CONST.youtube2;
                    itimgs = itimgs.Replace("$srcitem", you);
                    youcont = youcont + itimgs;

                }
                result = result.Replace("$youtubs", youcont);
                result = result.Replace("$fancygroupfull", bi);



                string path = PATH.site + "\\data\\dogandcat\\" + item.Id + ".html";

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

            string itemFull = "";
            List<DOGANDCAT> friends = DATA._DOGANDCAT.OrderByDescending(o => o.Id).ToList();
            foreach (DOGANDCAT item in friends)
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
            picturesf = PATH.datad;
            listname = DOGANDCAT._type.ToLower() + ".html";
            outfolder = PATH.outf + "\\" + DOGANDCAT._type.ToLower();
            fpath = PATH.site + "\\" + listname;
            htmlfolder = PATH.site + "\\data\\" + DOGANDCAT._type.ToLower();
            opath = outfolder + "\\" + listname;
            templateList = PATH.templ + "\\" + DOGANDCAT._type.ToLower() + "\\catalog.html";
            templateListItem = PATH.templ + "\\" + DOGANDCAT._type.ToLower() + "\\listitem.txt";
            imglistprefix = "data\\" + DOGANDCAT._type.ToLower();
            itemtemplate = PATH.templ + "\\" + DOGANDCAT._type.ToLower() + "\\itemdogandcat.html";
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
