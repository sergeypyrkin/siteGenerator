using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live.Entity.Base
{
    public class WORKOUT: CONTENT
    {
        public string _type = "WORKOUT";

        public void toString()
        {
            Console.WriteLine("!!! "+_type);
        }

    }
}
