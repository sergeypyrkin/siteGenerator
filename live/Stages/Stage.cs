using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live.Stages
{

    //БАЗОВЫЙ КЛАСС ДЛЯ ЭТАПОВ

    public  class Stage
    {
        public string NAME = "";
        public Stopwatch stopwatch;
        public int exitCode = 0;

        public Stage(string name)
        {
            this.NAME = name;
        }

        public virtual void EXECUTE()
        {
            
            stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("");
            Console.WriteLine(NAME);
            try
            {
                WORK();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(String.Format("{0} ERROR: {1}",CONST._INSERR, NAME));
                throw new Exception(ex.Message);

            }
            stopwatch.Stop();
            report();
        }

        public virtual void report()
        {
           // Console.WriteLine(NAME + " | " + stopwatch.Elapsed);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public virtual void WORK()
        {
            
        }


    }
}
