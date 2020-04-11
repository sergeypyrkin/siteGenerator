using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live.Stages
{
    public class Stage2 : Stage
    {

        public List<refItem> refs = new List<refItem>();

        public override void WORK()
        {
            init();

            if (DATA._newExist)
            {
                // Console.WriteLine(CONST._INS + "НЕЧЕГО ДОБАВИТЬ");
                return;
            }

        }

        public void init()
        {
            refs.Add(new refItem() { _type= "DOGANDCAT", newPass = PATH._newd, destinationPass = PATH.datad});
            refs.Add(new refItem() { _type = "FRIENDS", newPass = PATH._newf, destinationPass = PATH.dataf });
            refs.Add(new refItem() { _type = "WORKOUT", newPass = PATH._neww, destinationPass = PATH.dataw });
            PATH.refs = refs;
        }




        public Stage2(string name) : base(name)
        {
        }
    }


    public class refItem
    {
        public string _type;
        public string newPass;
        public string destinationPass;
        public string htmlPath;
    }
}
