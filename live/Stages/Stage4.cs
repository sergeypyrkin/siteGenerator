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
            Console.WriteLine("");

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
                string path = f.FullName;
                CONTENT content = getContent(path, name);
                j++;
            }

            string ins = new String(' ', 20 - name.Length);

            Console.WriteLine(String.Format("{0}{1} {2} {4} {3}", CONST._INS, "MODELS: ", name, j,ins));



        }

        private CONTENT getContent(String name, string _type)
        {
            CONTENT content = new CONTENT();
            switch (_type)
            {
                case "DOGANDCAT":
                    content = new DOGANDCAT();
                    break;
                case "FRIENDS":
                    content = new FRIENDS();
                    break;
                case "SPORT":
                    content = new SPORT();
                    break;
                case "WORKOUT":
                    content = new WORKOUT();
                    break;

                default:
                    Console.WriteLine("WRONG TYPE!!!");
                    break;
            }
            fillContent(content, name, _type);
            return content;
        }

        //заполняемые данные
        private void fillContent(CONTENT content, string name, string type)
        {
        }

        //Создание моделей
        public Stage4(string name) : base(name)
        {

        }
    }
}
