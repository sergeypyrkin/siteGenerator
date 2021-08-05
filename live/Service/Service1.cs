using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        break;
                    }
                }
            }


            foreach (var d in data)
            {
                if (String.IsNullOrEmpty(d.ModelString))
                {
                    Console.WriteLine("!!!!! no found for: "+  d.embededUrl);
                }
            }






        }
    }
}
