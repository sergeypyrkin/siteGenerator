using System;
using System.Diagnostics;
using System.Threading;

namespace live
{
    public class Program
    {
        /*
         Точка входа.
         */
       
        public static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();
            PATH.init();
            PATH.checking();
            Worker work = new Worker();
            // 1ю обработка фотографий
            work.stage1();


            // Stop timing.
            stopwatch.Stop();

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
