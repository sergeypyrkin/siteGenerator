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
                             FILEWORK.isEmptyDir(PATH._newf) &&
                             FILEWORK.isEmptyDir(PATH._newfood);
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
            checkDir(PATH._newf);
            checkDir(PATH._newd);
            checkDir(PATH._news);
            //checkDir(PATH._newfood);


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
            foreach (var content in diA)
            {
                //проверка конкретный контент

                int number;

                bool success = Int32.TryParse(content.Name, out number);
                if (success)
                {
                    string newpath = FILEWORK.renameDir(content.FullName, String.Format("a{0}",content.Name));
                    Console.WriteLine("{0}wrong name: {1} ->renaming", CONST._INS, content.Name);
                }
            }
            DirectoryInfo[] diB = di.GetDirectories();

            foreach (var content in diB)
            {
                //проверка конкретный контент
                checkContent(content, di);
            }


        }

        private void checkContent(DirectoryInfo content, DirectoryInfo di)
        {



            string ins = new String(' ', 20 - di.Name.Length);
            Console.WriteLine(String.Format("{0}{1}{3}| {2}", CONST._INS, di.Name, content.Name, ins));
            FileInfo[] fileNews = content.GetFiles();




            //не пустой
            if (fileNews.Length == 0)
            {
                throw new Exception(String.Format(" {1} пуста", CONST._INSERR, content.Name));
            }
            //не должно быть вложенных папок
            DirectoryInfo[] diVlog = content.GetDirectories();
            if (diVlog.Length > 0)
            {
                throw new Exception(String.Format(" {1}  содержит вложенные папки", CONST._INSERR , content.Name));
            }
            //должно содержать хотябы одно изображение и описание
            List<string> imgs = new List<string>();
            imgs = FILEWORK.GetAllFiles(content.FullName, imgs, ".jpg");


            if (imgs.Count == 0)
            {
                throw new Exception(String.Format("{1} не содержит изображение", CONST._INSERR,  content.Name));
            }
            List<string> txts = new List<string>();
            txts = FILEWORK.GetAllFiles(content.FullName, txts, ".txt");


            if (txts.Count == 0)
            {
                throw new Exception(String.Format(" {1}  не содержит описание (txt)", CONST._INSERR , content.Name));
            }

            if (txts.Count > 1)
            {
                throw new Exception(String.Format(" {1} содержит больше одного описания (txt)", CONST._INSERR, content.Name));
            }

            string opispath = txts[0];
            string fcontent = FILEWORK.ReadFileContent(opispath);
            if (String.IsNullOrEmpty(fcontent))
            {
                throw new Exception(String.Format(" {1}  ПУСТОЕ ОПИСАНИЕ (txt)", CONST._INSERR, content.Name));

            }
        }

        public Stage1(string name) : base(name)
        {
        }
    }
}
