using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using live.Entity;
using live.Service;
using live.Stages;
using live.Test;
using live.Utils;

namespace live
{
    public class Program
    {
        /*
         Точка входа.
         */

        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(int hWnd, int nCmdShow);

        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();


        public static  String niceString(String s1, String s2, String s3, int x1, int x2)
        {
            string res = "";
            string pass1 = new String(' ', x1 - s1.Length);
            string pre1 = s1 + pass1;


            string pass2 = new String(' ', x2 - s2.Length);
            string pre2 = pre1 + s2 + pass2;
            res = pre2 + s3;
            return res;
        }



        public static void Main(string[] args)
        {

            //var test = new Test1();
            //Console.ReadKey();
            bool serv = false;
            //string s1 = niceString("123123", "sdfsdf", "sdfsdf", 50, 50);
            //Console.WriteLine(s1);
            //string s2 = niceString("1231sdfsdfsdf23", "sdfsaaaadf", "sdfsdf", 50, 50);
            //Console.WriteLine(s2);
            //Console.ReadKey();
            //return;
            string procName = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcessesByName(procName).Length != 1)
            {
                Console.WriteLine("УЖЕ ЕСТЬ ЕЩЕ ОДИН ЭКЗЕМПЛЯР ПРОГРАММЫ");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            // Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            // ShowWindow(ThisConsole, MAXIMIZE);
            //ShowWindow(ThisConsole, MAXIMIZE);
            //Thread.Sleep(1000);
            //Console.SetWindowSize(Console.WindowWidth, Console.LargestWindowHeight-1);
            var stage1 = new Stage1("ПРОВЕРКА");

            var stage2 = new Stage2("ДОБАВЛЯЕМ");

            var stage3 = new Stage3("ОБРАБОКА ФОТОГРАФИЙ");

            var stage4 = new Stage4("СОЗДАНИЕ МОДЕЛЕЙ");

            var stage5 = new Stage5("WORKOUT CREATING...");

            var stage6 = new Stage6("FRIENDS CREATING...");

            var stage7 = new Stage7("DOGANDCAT CREATING...");

            var stage8 = new Stage8("SPORT CREATING...");

            var stage9 = new Stage9("FOOD CREATING...");

            var stage10 = new Stagef10("TRAVEL CREATING...");

            var stage11 = new Stage11("CONTACT CREATING...");

            var stage12 = new Stage12("INDEX CREATING...");

            var stage13 = new Stage13("REPORT CREATING...");

            var stage14 = new Stage14("RANDOMOPENER CREATE...");

            var stage15 = new Stage15("BOOK CREATE...");


            Console.WriteLine("");
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();
            PATH.INIT();
            CONST.INIT();
            PATH.checking();
            FILEWORK.SIZE();

            stage1.EXECUTE();

            stage2.EXECUTE();

            stage3.EXECUTE();

            stage4.EXECUTE();


            if (serv)
            {
                var serv1 = new Service1();
                serv1.EXECUTE();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            stage14.EXECUTE();

            stage5.EXECUTE();

            stage6.EXECUTE();

            stage7.EXECUTE();

            stage8.EXECUTE();

            stage9.EXECUTE();

            stage15.EXECUTE();

            stage10.EXECUTE();

            stage11.EXECUTE();

            stage12.EXECUTE();


            stage13.EXECUTE();

            COUNTER.count();
            // Stop timing.
            stopwatch.Stop();
            //var wo = new WORKOUT();
            //Console.WriteLine(wo._type);

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
