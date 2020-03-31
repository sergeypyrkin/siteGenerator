using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace live
{
    public class Worker
    {
        public void stage1()
        {
            int i = 0;
            Console.WriteLine("");
            Console.WriteLine("Обработка новых фото");
            List<string> files = new List<string>();
            files = FILEWORK.GetAllFiles(PATH.data, files);
            foreach (string s in files)
            {
                FileInfo f = new FileInfo(s);
                Console.WriteLine(f.Name);
            }
        }
    }
}
