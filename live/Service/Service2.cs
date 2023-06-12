using live.Entity;
using live.Entity.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace live.Service
{
    //выяснилось что возможно не все картинки присутствуют хз как конечно
    //тут их будем проверять и вяснять
    public class Service2
    {

        public Dictionary<string, string> parsedDict = new Dictionary<string, string>();
        public bool hasError = false;
        public Dictionary<string,string> uploadDict = new Dictionary<string, string>();


        public void EXECUTE()
        {
            fill();
            foreach (KeyValuePair<string, string> keyValue in parsedDict)
            {
                string folder1 = keyValue.Key;
                string folder2 = keyValue.Value;

                //1. проверка корня
                if (!Directory.Exists(folder1)) {
                    Console.WriteLine($" no dir {folder1}");

                }

                if (!Directory.Exists(folder2))
                {
                    Console.WriteLine($" no dir {folder2}");
                }

                //2. проверка саб дерикторив
                var folder1_dict1 = getListFolder(folder1);
                var folder1_dict2 = getListFolder(folder2);
                compareFoldersItself(folder1, folder2, folder1_dict1, folder1_dict2);
                compareFoldersInner(folder1, folder2, folder1_dict1, folder1_dict2);

            }

        }

        private void compareFoldersInner(string folder1, string folder2, Dictionary<string, string> folder1_dict, Dictionary<string, string> folder2_dict)
        {
            List<string> keys1 = folder1_dict.Keys.ToList();
            List<string> keys2 = folder2_dict.Keys.ToList();

            foreach (var key in keys1)
            {
                string f1 = folder1_dict[key];
                string f2 = folder2_dict[key];

                List<string> fles1 = Directory.GetFiles(f1).ToList();
                List<string> fles2 = Directory.GetFiles(f2).ToList();
                var dict1 = getFileName(fles1);
                var dict2 = getFileName(fles2);

                foreach (KeyValuePair<string, string> keyValue in dict1)
                {
                    string shortName = keyValue.Key;
                    string fullname = keyValue.Value;
                    if (!dict2.ContainsKey(shortName))
                    {
                        Console.WriteLine(fullname);
                        uploadDict.Add(fullname, f2);
                    }
                }


                foreach (KeyValuePair<string, string> keyValue in dict2)
                {
                    string shortName = keyValue.Key;
                    string fullname = keyValue.Value;
                    if (!dict1.ContainsKey(shortName))
                    {
                        Console.WriteLine(fullname);
                        uploadDict.Add(fullname, f1);
                    }
                }

            }

            foreach (KeyValuePair<string, string> keyValue in uploadDict)
            {
                string filename = keyValue.Key;
                string destination = keyValue.Value;

                try
                {
                    FileInfo f = new FileInfo(filename);
                    string shortname = f.Name;
                    destination = destination + "\\" + shortname;
                    FILEWORK.moveFile(filename, destination);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }


        }


        //получаем dict шорт найм длинное найт
        public Dictionary<string, string> getFileName(List<string> filename)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var item in filename)
            {
                String[] lines = item.Split(new string[] { "\\" }, StringSplitOptions.None);
                string shortName = lines.Last();
                result.Add(shortName, item);    
            }
            return result;
        }

        private void compareFoldersItself(string folder1, string folder2, Dictionary<string, string> folder1_dict, Dictionary<string, string> folder2_dict)
        {
            List<string> keys1 = folder1_dict.Keys.ToList();
            List<string> keys2 = folder2_dict.Keys.ToList();
            bool bcomp = true;

            foreach (string s in keys1)
            {
                if (!keys2.Contains(s))
                {
                    Console.WriteLine(s);
                    bcomp = false;
                }
            }
            foreach (string s in keys2)
            {
                if (!keys1.Contains(s))
                {
                    Console.WriteLine(s);
                    bcomp = false;

                }
            }

        }

        private Dictionary<string,string> getListFolder(string folder)
        {

            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (string d in Directory.GetDirectories(folder))
            {
                String[] lines = d.Split(new string[] { "\\" }, StringSplitOptions.None);
                string lf = lines.Last();
                result.Add(lf, d);
            }
            return result;
        }

        public void fill()
        {
            parsedDict.Add(PATH.datab, PATH.site + "\\data\\book\\");
            parsedDict.Add(PATH.datad, PATH.site + "\\data\\dogandcat\\");
            parsedDict.Add(PATH.datafood, PATH.site + "\\data\\food\\");
            parsedDict.Add(PATH.dataf, PATH.site + "\\data\\friends\\");
            parsedDict.Add(PATH.datas, PATH.site + "\\data\\sport\\");
            parsedDict.Add(PATH.datat, PATH.site + "\\data\\travel\\");
            parsedDict.Add(PATH.dataw, PATH.site + "\\data\\workout\\");
        }
    }


}
