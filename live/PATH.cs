using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity;
using live.Stages;

namespace live
{
    public static class PATH
    {


        public static List<refItem> refs = new List<refItem>();

        public static string site = "Z:\\home\\ss.ru\\www";
        public static string DESKTOP = "C:\\Users\\Programmist";

        //исходная папка
        public static string root = $"{DESKTOP}\\MYLIVE";
        public static string data = $"{DESKTOP}\\MYLIVE\\DATA";
        public static string test = $"{DESKTOP}\\MYLIVE\\TEST";
        public static string _new = $"{DESKTOP}\\MYLIVE\\_NEW";
        public static string outf = $"{DESKTOP}\\MYLIVE\\OUT";
        public static string templ = $"{DESKTOP}\\MYLIVE\\TEMPLATES";


        public static string _newf = $"{DESKTOP}\\MYLIVE\\_NEW\\FRIENDS";
        public static string _neww = $"{DESKTOP}\\MYLIVE\\_NEW\\WORKOUT";
        public static string _newd = $"{DESKTOP}\\MYLIVE\\_NEW\\DOGANDCAT";
        public static string _newb = $"{DESKTOP}\\MYLIVE\\_NEW\\BOOK";
        public static string _news = $"{DESKTOP}\\MYLIVE\\_NEW\\SPORT";
        public static string _newfood = $"{DESKTOP}\\MYLIVE\\_NEW\\FOOD";

        public static string datat = $"{DESKTOP}\\MYLIVE\\DATA\\PICTURES\\TRAVEL";

        public static string dataf = $"{DESKTOP}\\MYLIVE\\DATA\\PICTURES\\FRIENDS";
        public static string dataw = $"{DESKTOP}\\MYLIVE\\DATA\\PICTURES\\WORKOUT";
        public static string datad = $"{DESKTOP}\\MYLIVE\\DATA\\PICTURES\\DOGANDCAT";
        public static string datab = $"{DESKTOP}\\MYLIVE\\DATA\\PICTURES\\BOOK";

        public static string datas = $"{DESKTOP}\\MYLIVE\\DATA\\PICTURES\\SPORT";
        public static string datafood = $"{DESKTOP}\\MYLIVE\\DATA\\PICTURES\\FOOD";

        public static string videofolder = $"{DESKTOP}\\MYLIVE\\DATA\\VIDEO";
        public static string videofolderSave = $"{DESKTOP}\\MYLIVE\\DATA\\VIDEO\\info.txt";



        public static string imgProcessedFile = $"{DESKTOP}\\MYLIVE\\DATA\\parsed.txt";


        public static void INIT()
        {
            string path = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
            int i = path.IndexOf("MYLIVE");
            path = path.Substring(0, i) + "MYLIVE\\";
            root = path;
            data = root + "DATA";
            test = root + "TEST";
            outf = root + "OUT";
            templ = root + "TEMPLATES";
            _new = root + "_NEW";
            _newd = _new + "\\DOGANDCAT";
            _newf = _new + "\\FRIENDS";
            _neww = _new + "\\WORKOUT";
            _newb = _new + "\\BOOK";
            _news = _new + "\\SPORT";
            _newfood = _new + "\\FOOD";



            datad = data + "\\PICTURES\\DOGANDCAT";
            datab = data + "\\PICTURES\\BOOK";
            dataf = data + "\\PICTURES\\FRIENDS";
            dataw = data + "\\PICTURES\\WORKOUT";
            datas = data + "\\PICTURES\\SPORT";
            datafood = data + "\\PICTURES\\FOOD";
            datat = data + "\\PICTURES\\TRAVEL";


            imgProcessedFile = data + "\\parsed.txt";
          




            refs.Add(new refItem() { _type = "DOGANDCAT", newPass = PATH._newd, destinationPass = PATH.datad, htmlPath = "" });
            refs.Add(new refItem() { _type = "FRIENDS", newPass = PATH._newf, destinationPass = PATH.dataf, htmlPath = "" });
            refs.Add(new refItem() { _type = "WORKOUT", newPass = PATH._neww, destinationPass = PATH.dataw, htmlPath = "" });
            refs.Add(new refItem() { _type = "SPORT", newPass = PATH._news, destinationPass = PATH.datas, htmlPath = "" });
            refs.Add(new refItem() { _type = "FOOD", newPass = PATH._newfood, destinationPass = PATH.datafood, htmlPath = "" });
            refs.Add(new refItem() { _type = "BOOK", newPass = PATH._newb, destinationPass = PATH.datab, htmlPath = "" });


        }



        public static void checking()
        {
            Console.WriteLine("INIT");
            check(root);
            check(data);
            check(test);

            check(_new);
            check(_newd);
            check(_newf);
            check(_neww);
            check(_newb);
            check(_news);
            check(_newfood);

            check(datad);
            check(dataw);
            check(dataf);
            check(datas);
            check(datafood);
            check(datat);

            check(site);
            check(outf);
            check(templ);



        }

        public static void check(string path)
        {
            string ins = new String(' ', 60 - path.Length);

            if (Directory.Exists(path))
            {
                Console.WriteLine(CONST._INS + path +ins+ "OK");
            }
            else
            {
                Console.WriteLine(CONST._INS + path + ins+"BAD");
            }
        }

    }
}
