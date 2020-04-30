using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity.Base;

namespace live.Stages
{
    public class Stage5 : Stage
    {

        public static string outfolder; 
        public static string htmlfolder;
        public static string listname;       //workout.html;
        public static string opath;          //out//workout.html;
        public static string fpath;          //ss.ru//workout.html;
        public static string picturesf;


        public Stage5(string name) : base(name)
        {
        }

        public override void WORK()
        {
            prefixWork();
            //3. Создание htmlFile
            FILEWORK.WriteFileContent(opath, "Hello WORLD");
            saffixWork();


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
    }
}



