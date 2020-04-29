using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live.Utils
{
    public static class COUNTER
    {
        //количество контента (ВСЕГО)
        public static int contentCount;

        public static int imgCount;
        public static int youCount;

        public static void count()
        {
            foreach (var content in DATA._CONTENT)
            {
                imgCount = imgCount + content.imgs.Count;
                youCount = youCount + content.youtubs.Count;
                contentCount = contentCount + 1;

            }
            Console.WriteLine("=====                                                        =====");
            Console.WriteLine("{3}CONTENT: {0} IMAGES: {1} YOUTUBS: {2}", contentCount, imgCount, youCount, CONST._INS);
            Console.WriteLine("=====                                                        =====");
            Console.WriteLine("");
            Console.WriteLine("");

        }
    }
}
