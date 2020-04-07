using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live.Stages
{
    public class Stage1 : Stage
    {


        public override void WORK()
        {
            DATA._newExist = FILEWORK.isEmptyDir(PATH._newd) && FILEWORK.isEmptyDir(PATH._neww) &&
                             FILEWORK.isEmptyDir(PATH._newf);
            if (DATA._newExist)
            {
                Console.WriteLine(CONST._INS + "НЕЧЕГО ДОБАВИТЬ");
                return;
            }
            else
            {
                Console.WriteLine(CONST._INS + "ЕСТЬ НОВЫЙ КОНТЕНТ");
            }
            checkDir(PATH._neww);
            checkDir(PATH._newb);

        }


        public void checkDir(String folder)
        {

            //если пустая то проходим
            if (FILEWORK.isEmptyDir(folder))
            {
                return;
            }

            //если содержит файл то пропускаем
            DirectoryInfo di = new DirectoryInfo(folder);
            
            FileInfo[] fi = di.GetFiles();
            if (fi.Length > 0)
            {
                throw new Exception(String.Format("{0} содержит недопустимые файлы", di.Name));

            }

        }

        public Stage1(string name) : base(name)
        {
        }
    }
}
