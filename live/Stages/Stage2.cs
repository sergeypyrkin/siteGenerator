using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity;

namespace live.Stages
{
    public class Stage2 : Stage
    {

        //на этом этапе, копируем новый контент в папки data + приводим в порядок ихний info.txt



        public override void WORK()
        {

            if (DATA._newExist)
            {
                // Console.WriteLine(CONST._INS + "НЕЧЕГО ДОБАВИТЬ");
                return;
            }

        }



        public Stage2(string name) : base(name)
        {
        }
    }



}
