using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity;
using Microsoft.SqlServer.Server;

namespace live.Stages
{
    public class Stage2 : Stage
    {

        //на этом этапе, копируем новый контент в папки data + приводим в порядок ихний info.txt

        public int _stIndex = 1;

        public override void WORK()
        {

            if (DATA._newExist)
            {
                // Console.WriteLine(CONST._INS + "НЕЧЕГО ДОБАВИТЬ");
                return;
            }

            foreach (var _ref in PATH.refs)
            {
                int stIndex = getStartIndex(_ref.destinationPass);

            }

        }

        public int getStartIndex(string path)
        {
            int max = _stIndex;
            string[] diA = Directory.GetDirectories(path);
            List<int> names = new List<int>();
            foreach (string s in diA)
            {
                String[] ll = s.Split(new string[] { "\\" }, StringSplitOptions.None);
                String last = ll.Last();
                int i = Convert.ToInt32(last);
                names.Add(i);
            }
            if (names.Count > 0)
            {
                max = names.Max(t => t);
                max = max + 1;
            }
            return max;
        }



        public Stage2(string name) : base(name)
        {
        }
    }



}
