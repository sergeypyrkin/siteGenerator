using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live.Stages
{
    public class Stage1 : Stage
    {


        public override void WORK()
        {
            DATA._newExist = FILEWORK.isEmptyDir(PATH._newd) && FILEWORK.isEmptyDir(PATH._neww) &&
                             FILEWORK.isEmptyDir(PATH._neww);
            if (DATA._newExist)
            {
                Console.WriteLine(CONST._INS + "НЕЧЕГО ДОБАВИТЬ");
                return;
            }
            else
            {
                Console.WriteLine(CONST._INS + "ЕСТЬ НОВЫЙ КОНТЕКСТ");

            }
        }

        public Stage1(string name) : base(name)
        {
        }
    }
}
