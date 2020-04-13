﻿using System;
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

        //исходная папка
        public static string root = "C:\\Users\\Programmist\\Desktop\\MYLIVE";
        public static string data = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\DATA";
        public static string test = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\TEST";
        public static string _new = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\_NEW";

        public static string _newf = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\_NEW\\FRIENDS";
        public static string _neww = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\_NEW\\WORKOUT";
        public static string _newd = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\_NEW\\DOGANDCAT";
        public static string _newb = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\_NEW\\BADSTAGE";
        public static string _news = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\_NEW\\SPORT";


        public static string dataf = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\DATA\\PICTURES\\FRIENDS";
        public static string dataw = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\DATA\\PICTURES\\WORKOUT";
        public static string datad = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\DATA\\PICTURES\\DOGANDCAT";
        public static string datas = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\DATA\\PICTURES\\SPORT";



        public static string imgProcessedFile = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\DATA\\parsed.txt";


        public static void init()
        {
            string path = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
            int i = path.IndexOf("MYLIVE");
            path = path.Substring(0, i) + "MYLIVE\\";
            root = path;
            data = root + "DATA";
            test = root + "TEST";
            _new = root + "_NEW";
            _newd = _new + "\\DOGANDCAT";
            _newf = _new + "\\FRIENDS";
            _neww = _new + "\\WORKOUT";
            _newb = _new + "\\BADSTAGE";
            _news = _new + "\\SPORT";



            datad = data + "\\PICTURES\\DOGANDCAT";
            dataf = data + "\\PICTURES\\FRIENDS";
            dataw = data + "\\PICTURES\\WORKOUT";
            datas = data + "\\PICTURES\\SPORT";
            imgProcessedFile = data + "\\parsed.txt";
            




            refs.Add(new refItem() { _type = "DOGANDCAT", newPass = PATH._newd, destinationPass = PATH.datad, htmlPath = "" });
            refs.Add(new refItem() { _type = "FRIENDS", newPass = PATH._newf, destinationPass = PATH.dataf, htmlPath = "" });
            refs.Add(new refItem() { _type = "WORKOUT", newPass = PATH._neww, destinationPass = PATH.dataw, htmlPath = "" });
            refs.Add(new refItem() { _type = "SPORT", newPass = PATH._news, destinationPass = PATH.datas, htmlPath = "" });

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
            check(datad);
            check(dataw);
            check(dataf);





        }

        public static void check(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine(CONST._INS + path + "    OK");
            }
            else
            {
                Console.WriteLine(CONST._INS + path + "    BAD");
            }
        }

    }
}
