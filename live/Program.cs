using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
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
            // Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            // ShowWindow(ThisConsole, MAXIMIZE);
            //ShowWindow(ThisConsole, MAXIMIZE);
            //Thread.Sleep(1000);
            //Console.SetWindowSize(Console.WindowWidth, Console.LargestWindowHeight-1);
            var stage1 = new Stage1("ПРОВЕРКА");

            var stage3 = new Stage3("ОБРАБОКА ФОТОГРАФИЙ");

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

                stage3.EXECUTE();
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

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
