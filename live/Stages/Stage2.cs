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

        public List<refCopyItem> refs = new List<refCopyItem>();

        public override void WORK()
        {

            if (DATA._newExist)
            {
                // Console.WriteLine(CONST._INS + "НЕЧЕГО ДОБАВИТЬ");
                return;
            }
            init();

        }

        public void init()
        {
            refs.Add(new refCopyItem(){_type= "DOGANDCAT", newPass = PATH._newd, destinationpass = PATH.datad});
            refs.Add(new refCopyItem() { _type = "FRIENDS", newPass = PATH._newf, destinationpass = PATH.dataf });
            refs.Add(new refCopyItem() { _type = "WORKOUT", newPass = PATH._neww, destinationpass = PATH.dataw });

        }




        public Stage2(string name) : base(name)
        {
        }
    }


    public class refCopyItem
    {
        public string _type;
        public string newPass;
        public string destinationpass;
    }
}
