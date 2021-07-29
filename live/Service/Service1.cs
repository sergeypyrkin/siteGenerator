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
        }
    }
}
