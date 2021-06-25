using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity.Base;

namespace live.Stages
{

    //friends
    public class Stage5 : Stage
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


        public string imglistprefix = "data\\workout\\";


        public Stage5(string name) : base(name)
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
            string itemtemplateitem = FILEWORK.ReadFileContent(PATH.templ +"\\"+WORKOUT._type.ToUpper()+ "\\itemworkoutitem.txt");

            foreach (var item in DATA._WORKOUT)
            {
                //пока Deprecated. слишком дохуя и не надежно.
                //if (!DATA.isAddItem(item))
                //{
                //    continue;
                //}
                string result = template;
                result = result.Replace("$Id", item.Id.ToString());
                result = result.Replace("$date", item.date.ToString("yyyy-MM-dd"));
                result = result.Replace("$mainImg",item.Id+"/"+item.mainImg);

                string texts = string.Join("<br> <br>", item.txtContents.ToArray());
                result = result.Replace("$text", "<p>"+texts+"</p>");
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
                    string itimgs = !isOne ? CONST.youtube1: CONST.youtube2;
                    itimgs = itimgs.Replace("$srcitem", you);
                    youcont = youcont + itimgs;

                }
                result = result.Replace("$youtubs", youcont);
                result = result.Replace("$fancygroupfull", bi);



                string path = PATH.site + "\\data\\workout\\"+item.Id + ".html";

                FILEWORK.WriteFileContent(path, result);
                Console.WriteLine("+ " + path);


            }

        }


        public void prefixWork()
        {
            //0 инит
            picturesf = PATH.dataw;
            listname = WORKOUT._type.ToLower() + ".html";
            outfolder = PATH.outf + "\\" + WORKOUT._type.ToLower();
            fpath = PATH.site + "\\" + listname;
            htmlfolder = PATH.site + "\\data\\" + WORKOUT._type.ToLower();
            opath = outfolder + "\\" + listname;
            templateList = PATH.templ + "\\"+ WORKOUT._type.ToLower() +"\\"+WORKOUT._type.ToLower() + "list.html";
            templateListItem = PATH.templ + "\\" + WORKOUT._type.ToLower()+ "\\" + WORKOUT._type.ToLower() + "listitem.txt";
            imglistprefix = "data\\" + WORKOUT._type.ToLower();
            itemtemplate = PATH.templ + "\\" + WORKOUT._type.ToLower()+ "\\itemworkout.html";
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

        public void createList()
        {
            string template = FILEWORK.ReadFileContent(templateList);
            string itemtemplate = FILEWORK.ReadFileContent(templateListItem);
            template = template.Replace("$header1", CONST.header1);
            template = template.Replace("$footer1", CONST.footer1);
            string itemFull = "";
            List<WORKOUT> works = DATA._WORKOUT.OrderByDescending(o => o.Id).ToList();
            foreach (WORKOUT item in works)
            {
                string itemres = itemtemplate;
                string bi = "build" + item.Id;


                itemres = itemres.Replace("$fancygroupfull", bi);

                itemres = itemres.Replace("$fancygroupfull", bi);
                itemres = itemres.Replace("$title", item.date.ToString("yyyy-MM-dd"));

                string texts = string.Join("<br> <br>", item.txtContents.ToArray());
                itemres = itemres.Replace("$text", texts);

                List<string> used = new List<string>();
                string i1 = item.mainImg;
                string sname = DATA.imageDict[i1];

                used.Add(sname);
                itemres = itemres.Replace("$image1", imglistprefix + "\\"+item.Id+"\\"+i1);

                string i2 = imgName(used, item);
                itemres = itemres.Replace("$image2", imglistprefix + "\\" + item.Id + "\\" + i2);

                string i3 = imgName(used, item);
                itemres = itemres.Replace("$image3", imglistprefix + "\\" + item.Id + "\\" + i3);


                string i4 = imgName(used, item);
                itemres = itemres.Replace("$image4", imglistprefix + "\\" + item.Id + "\\" + i4);

                string i5 = imgName(used, item);
                itemres = itemres.Replace("$image5", imglistprefix + "\\" + item.Id + "\\" + i5);

                string i6 = imgName(used, item);
                itemres = itemres.Replace("$image6", imglistprefix + "\\" + item.Id + "\\" + i6);


                string i7 = imgName(used, item);
                itemres = itemres.Replace("$image7", imglistprefix + "\\" + item.Id + "\\" + i7);


                itemres = itemres.Replace("$link", imglistprefix  +"\\" +item.Id+ ".html");

                itemFull = itemFull + itemres;
            }
            string result = template.Replace("$items", itemFull);
            FILEWORK.WriteFileContent(opath, result);
            Console.WriteLine("+ "+ fpath);

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
    }
}



