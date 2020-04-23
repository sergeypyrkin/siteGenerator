using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live.Entity
{
    public interface ICreateHtml
    {
        void getTemplate(string path);
        void createHtmlString();
        void createHtml();
    }
}
