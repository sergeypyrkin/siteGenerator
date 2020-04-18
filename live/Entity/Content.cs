using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live.Entity
{

    //базовый класс для Контентов
    public class CONTENT
    {
        public int Id;
        public string _type;
        public DateTime date;
        public string title;
        public string mainText;
        public List<string> imgs;
        public List<string> youtubs;
        public bool hasYoutube;
        public bool hasImgs;
        public string link;


        public string toString()
        {
            return _type;
        }
    }
}
