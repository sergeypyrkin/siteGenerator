using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live.Entity.Base
{
    public class TRAVEL
    {
        public static string _type = "TRAVEL";


        public int Id;
        public string name;  //НИЖНИЙ НОВГОРОД
        public string ldate; //1-2мая
        public string lcount; //5000
        public List<string> mainIng = new List<string>();
        public List<string> imgs = new List<string>();
        public Dictionary<int, string> destrictions = new Dictionary<int, string>();
        public string description;

        public string praceS;
        public string praceL;



        public string dataFolderPath;
    }
}
