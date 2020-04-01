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
            WORK();
            stopwatch.Stop();
            report();
        }

        public virtual void report()
        {
            Console.WriteLine(NAME + " | " + stopwatch.Elapsed);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public virtual void WORK()
        {
            
        }


    }
}
