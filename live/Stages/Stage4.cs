using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity;
using live.Entity.Base;

namespace live.Stages
{
    public class Stage4: Stage
    {
        public override void WORK()
        {
            foreach (var rf in PATH.refs)
            {
                createModels(rf.destinationPass);
            }
        }

        private void createModels(string dirPathFull)
        {
            int j = 0;
            DirectoryInfo di = new DirectoryInfo(dirPathFull);
            string name = di.Name;
            DirectoryInfo[] diA = di.GetDirectories();
            foreach (var f in diA)
            {
                CONTENT content = getContent(f, name);
            }



        }

        private CONTENT getContent(DirectoryInfo directoryInfo, String name)
        {
            CONTENT cont = new CONTENT();
            return cont;
            switch (name)
            {
                case "DOGANDCAT":
                   // DOGANDCAT content = new DOGANDCAT();
                    break;
                case "FRIENDS":
                    Console.WriteLine("Two");
                    break;
                case "SPORT":
                    Console.WriteLine("Two");
                    break;
                case "WORKOUT":
                    Console.WriteLine("Two");
                    break;

                default:
                    Console.WriteLine("WRONG TYPE!!!");
                    break;
            }
        }

        //Создание моделей
        public Stage4(string name) : base(name)
        {

        }
    }
}
