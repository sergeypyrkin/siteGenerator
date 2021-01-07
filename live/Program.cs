using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using live.Entity;
using live.Stages;
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

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;


        public static void Main(string[] args)
        {

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

            stage5.EXECUTE();

            //stage6.EXECUTE();

            //stage7.EXECUTE();

            //stage8.EXECUTE();

            //stage9.EXECUTE();

            //stage10.EXECUTE();

            //stage11.EXECUTE();

            //stage12.EXECUTE();

            //stage13.EXECUTE();

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
