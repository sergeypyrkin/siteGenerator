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
               // Console.WriteLine(CONST._INS + "НЕЧЕГО ДОБАВИТЬ");
                return;
            }
            else
            {
               // Console.WriteLine(CONST._INS + "ЕСТЬ НОВЫЙ КОНТЕНТ");
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
            

            //проверка на недопустимые файлы
            FileInfo[] fi = di.GetFiles();
            if (fi.Length > 0)
            {
                throw new Exception(String.Format("{0} содержит недопустимые файлы", di.Name));
            }

            //проверка на пустые папки внутри
            DirectoryInfo[] diA = di.GetDirectories();
            foreach (var news in diA)
            {
                //проверка конкретный контент
                checkContent(news, di);
            }


        }

        private void checkContent(DirectoryInfo news, DirectoryInfo di)
        {

            string ins = new String(' ', 20 - di.Name.Length);
            Console.WriteLine(String.Format("{0}{1}{3}| {2}", CONST._INS, di.Name, news.Name, ins));
            FileInfo[] fileNews = news.GetFiles();

            //не пустой
            if (fileNews.Length == 0)
            {
                throw new Exception(String.Format("{0} из раздела {1} пуста", news.Name, di.Name));
            }
        }

        public Stage1(string name) : base(name)
        {
        }
    }
}
