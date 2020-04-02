using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace live.Stages
{
    public class Stage1: Stage
    {

        public override void WORK()
        {
            int i = 0;

            List<string> files = new List<string>();
            files = FILEWORK.GetAllFiles(PATH.data, files, ".jpg");
            foreach (String f in files)
            {
                string fullName = f;
                String[] ll = f.Split(new string[] { "\\" }, StringSplitOptions.None);
                DATA.imageDict.Add(ll.Last(), fullName);
            }
            string last = files.Last();
            IMAGEWORKER.getSize(last);
        }

        public Stage1(string name) : base(name)
        {

        }
    }
}
