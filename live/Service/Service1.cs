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

        public List<FileInfo> youtubs = new List<FileInfo>();
        public FileInfo html;
        public List<string> ynames = new List<string>();

        public void EXECUTE()
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
            string content = FILEWORK.ReadFileContent(html.FullName);

            foreach (var y in youtubs)
            {
                string name = y.Name.Replace(".mp4", "");
                ynames.Add(name);
            }

            //тут собственно и парсинг
            foreach (var yns in ynames)
            {
                 Console.WriteLine("===========");
                 Console.WriteLine(yns);
                 string reg = $">{yns}</a>";
                 String[] row = content.Split(new string[] {reg}, StringSplitOptions.None);
                 if (row.Length == 1)
                 {
                     Console.WriteLine("Error: неправильный парскинг, скорее всего есть виедо которго нету на канале (обычно такое происходит когда задвоится)" );
                     Console.ReadKey();
                     break;
                 }
                 String[] row2 = row[0].Split(new string[] {"href=" }, StringSplitOptions.None);
                 string prelast = row2.Last();
                 string last = prelast.Replace("\"", "");
                 Console.WriteLine(last);
            }



            List<String> lines = content.Split(new char[] { '\t' }).ToList();
        }
    }
}
