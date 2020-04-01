using System;
using System.Diagnostics;
using System.Threading;
using live.Stages;

namespace live
{
    public class Program
    {
        /*
         Точка входа.
         */
       
        public static void Main(string[] args)
        {
            var stage1 = new Stage1("ОБРАБОКА ФОТОГРАФИЙ");




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

            stage1.EXECUTE();
            // Stop timing.
            stopwatch.Stop();

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
