using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace live
{
    public class FILEWORK
    {
        //FILEWORK.ReadFileContent(PATH.imgProcessedFile);
        //FILEWORK.WriteFileContent(PATH.imgProcessedFile, "2222\n234234");
        public static string ReadFileContent(string path)
        {
            string res = "";
            string[] lines = File.ReadAllLines(path);
            res = string.Join("\n", lines);
            return res;
        }

        public static void WriteFileContent(string path, string content)
        {
            File.WriteAllText(path, content);
            return;
        }


        public static List<string> GetAllFiles(string sDir, List<string> files, string ext="")
        {
            
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    if (!isParsed(f, ext))
                    {
                        continue;
                    }
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    //foreach (string f in Directory.GetFiles(d))
                    //{
                    //    if (!isParsed(f, ext))
                    //    {
                    //        continue;
                    //    }
                    //    files.Add(f);
                    //}
                    GetAllFiles(d,files, ext);
                }
                return files;
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
                return new List<string>();
            }

        }

        public static bool isParsed(string f, string ext)
        {
            if (String.IsNullOrEmpty(ext))
            {
                return true;
            }
            FileInfo file = new FileInfo(f);
            return file.Extension == ext;

        }


        public static void SIZE()
        {
            string pathToDirectory = PATH.root;
            double catalogSize = 0;
            catalogSize = sizeOfFolder(pathToDirectory, ref catalogSize); //Вызываем наш рекурсивный метод
            if (catalogSize != 0)
            {
                Console.WriteLine(CONST.ins+ "{1} ГБ", pathToDirectory, catalogSize);
            }
            else
            {
                Console.WriteLine("Каталог {0} пуст.", pathToDirectory);
            }
        }

        public static double sizeOfFile(String path)
        {
            FileInfo f = new FileInfo(path);
            double r = f.Length;
            return Math.Round((double)(r / 1024 / 1024), 1);
        }



        public static double sizeOfFolder(string folder, ref double catalogSize)
        {
            try
            {
                //В переменную catalogSize будем записывать размеры всех файлов, с каждым
                //новым файлом перезаписывая данную переменную
                DirectoryInfo di = new DirectoryInfo(folder);
                DirectoryInfo[] diA = di.GetDirectories();
                FileInfo[] fi = di.GetFiles();
                //В цикле пробегаемся по всем файлам директории di и складываем их размеры
                foreach (FileInfo f in fi)
                {
                    //Записываем размер файла в байтах
                    catalogSize = catalogSize + f.Length;
                }
                //В цикле пробегаемся по всем вложенным директориям директории di 
                foreach (DirectoryInfo df in diA)
                {
                    //рекурсивно вызываем наш метод
                    sizeOfFolder(df.FullName, ref catalogSize);
                }
                //1ГБ = 1024 Байта * 1024 КБайта * 1024 МБайта
                return Math.Round((double)(catalogSize / 1024 / 1024 / 1024), 1);
            }
            //Начинаем перехватывать ошибки
            //DirectoryNotFoundException - директория не найдена
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
                return 0;
            }
            //UnauthorizedAccessException - отсутствует доступ к файлу или папке
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                return 0;
            }
            //Во всех остальных случаях
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка. Обратитесь к администратору. Ошибка: " + ex.Message);
                return 0;
            }
        }
    }
}
