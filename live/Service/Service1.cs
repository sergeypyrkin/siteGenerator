using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace live.Service
{

    //делаем сообтветтвие youtube = name = item
    public class Service1
    {

        public class DataYoutube
        {
            public string Name;
            public string rowUrl;
            public string embededUrl;
            public string ModelString;
        }

        public List<FileInfo> youtubs = new List<FileInfo>();
        public FileInfo html;
        public List<string> ynames = new List<string>();
        public List<DataYoutube> data = new List<DataYoutube>();
        public string content;

        //те которых не будет
        public List<string> isckl = new List<string>()
        {
            "https://www.youtube.com/embed/HJre-NmIjwg"
        };

        public void parseFiles()
        {
            DirectoryInfo di = new DirectoryInfo(PATH.videofolder);
            FileInfo[] diA = di.GetFiles();

            foreach (FileInfo f in diA)
            {
                string ext = f.Extension;
                switch (ext)
                {
                    case ".mp4":
                        youtubs.Add(f);
                        break;
                    case ".html":
                        html = f;
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }

            foreach (var y in youtubs)
            {
                string name = y.Name.Replace(".mp4", "");
                ynames.Add(name);
            }
        }


        private string parseYoutubs(string line)
        {
            string result = "";
            String[] ll = line.Split(new string[] { "/" }, StringSplitOptions.None);
            string last = ll.Last();
            result = "https://www.youtube.com/embed/" + last;
            result = result.Replace("watch?v=", "");
            return result;
        }

        public void parseHtml()
        {
            //тут собственно и парсинг
            foreach (var yns in ynames)
            {

                string reg = $">{yns}</a>";
                String[] row = content.Split(new string[] { reg }, StringSplitOptions.None);
                if (row.Length == 1)
                {
                    Console.WriteLine("Error: неправильный парскинг, скорее всего есть виедо которго нету на канале (обычно такое происходит когда задвоится)");
                    Console.ReadKey();
                    break;
                }
                String[] row2 = row[0].Split(new string[] { "href=" }, StringSplitOptions.None);
                string prelast = row2.Last();
                string last = prelast.Replace("\"", "");
                DataYoutube dy = new DataYoutube();
                dy.Name = yns;
                dy.rowUrl = last;
                string embedd = parseYoutubs(last);
                dy.embededUrl = embedd;
                data.Add(dy);
                string pass = new String(' ', 50 - yns.Length);
                Console.WriteLine(yns + pass + ": " + last);
            }

            data = data.Where(o => !isckl.Contains(o.embededUrl)).ToList();

        }

        public String niceString(String s1, String s2, String s3, int x1, int x2)
        {
            string res = "";
            string pass1 = new String(' ', x1 - s1.Length);
            string pre1 = s1 + pass1;


            string pass2 = new String(' ', x2 - s2.Length);
            string pre2 = pre1 + s2 + pass2;
            res = pre2 + s3;
            return res;
        }


        public void EXECUTE()
        {



            Console.WriteLine("PARSE FILES");
            Console.WriteLine("");
            Console.WriteLine("");

            parseFiles();

            content = FILEWORK.ReadFileContent(html.FullName);
            Console.WriteLine("START PARSING HTML");
            Console.WriteLine("");
            Console.WriteLine("");
            parseHtml();


            Console.WriteLine("START FOUND  ITEMS");
            Console.WriteLine("");
            Console.WriteLine("");
            foundItems();


            saveInfo();


            foreach (var d in data)
            {
                String r = niceString(d.ModelString, d.Name, d.embededUrl, 50, 50);
                Console.WriteLine(r);
            }


            foreach (var d in data)
            {
                if (String.IsNullOrEmpty(d.ModelString))
                {
                    Console.WriteLine("!!!!! no found for: "+  d.embededUrl);
                }
            }



        }

        public void saveInfo()
        {
            string res = "";

            foreach (var d in data)
            {
                String r = niceString(d.ModelString, d.Name, d.embededUrl, 50, 50);
                res = res + r + '\n';
            }

            FILEWORK.WriteFileContent(PATH.videofolderSave, res);
        }

        public void foundItems()
        {

            //тут собираем id моделей 

            foreach (var dataContent in DATA._CONTENT)
            {
                if (!dataContent.hasYoutube)
                {
                    continue;
                }

                foreach (var ystring in dataContent.youtubs)
                {
                    var data_youtube = data.FirstOrDefault(o => o.embededUrl == ystring);
                    if (data_youtube != null)
                    {
                        string modelString = dataContent._type + "_" + dataContent.Id;
                        data_youtube.ModelString = modelString;
                    }
                }
            }

            // и по тревелу
            foreach (var dataContent in DATA._TRAVELS)
            {


                foreach (var ystring in dataContent.youtubs)
                {


                    var data_youtube = data.FirstOrDefault(o => o.embededUrl == ystring);
                    if (data_youtube != null)
                    {
                        string modelString = "TRAVEL" + "_" + dataContent.Id;
                        data_youtube.ModelString = modelString;
                    }
                }
            }
        }
    }
}
