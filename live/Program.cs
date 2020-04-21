using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using live.Entity;
using live.Stages;

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


            Console.WriteLine("");
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();
            PATH.init();
            PATH.checking();
            FILEWORK.SIZE();

            try
            {
                stage1.EXECUTE();

                stage2.EXECUTE();

                stage3.EXECUTE();

                stage4.EXECUTE();
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("{0} {1}", CONST._INSERR, ex.Message));
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
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
