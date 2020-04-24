using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace live
{

    //классдля работы с изображениями
    public static class IMAGEWORKER
    {
        //максимальные размеры изображения
        public static int MW = 1250;
        public static int MH = 1250;

        //возвращает размеры до и после
        public static List<double> lessImageSet(string path)
        {

            try
            {
                path = DATA.imageDict[path];
                List<double> sizes = new List<double>();
                double size1 = FILEWORK.sizeOfFile(path);
                var imgStream = File.OpenRead(path);
                Image yourImage = Image.FromStream(imgStream); //загрузили изображение         
                imgStream.Close(); //закрыли поток
                Size sz = nwSizeMain(yourImage);
                yourImage = resizeImage(yourImage, sz); //изменили размер
                string finPath = path;
                yourImage.Save(finPath, ImageFormat.Jpeg); //сохранили
                double size2 = FILEWORK.sizeOfFile(finPath);
                reportTransformImage(path, size1, size2);
                sizes.Add(size1);
                sizes.Add(size2);
                return sizes;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: обработки изображения " + path);
                Console.WriteLine(e.Message);
                return new List<double>();
            }

        }





        public static void reportTransformImage(string path, double size1, double size2)
        {
            String p = String.Format("{0} -> {1}", size1, size2);
            string ins = new String(' ', 12 - p.Length);
            String message = String.Format(CONST._INS + "NEW IMAGE  | {1} -> {2} {3} |  {0} ", path, size1,size2,ins);
            Console.WriteLine(message);
        }

        public static Size nwSizeMain(Image imgToResize)
        {
            int w = imgToResize.Width;
            int h = imgToResize.Height;
            double k1 = (1.0)*MW / w;
            double k2 = (1.0) * MH / h;
            double k = Math.Min(k1, k2);
            Size sz = new Size(Convert.ToInt32(imgToResize.Width*k), Convert.ToInt32(imgToResize.Height * k));
            return sz;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            Image result = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage((Image) result))
            {
              
                g.InterpolationMode = InterpolationMode.High;
                g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
                g.Dispose();
            }
            return result;
        }
    }
}
