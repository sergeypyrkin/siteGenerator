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

    //ОБРАБОКА ФОТОГРАФИЙ
    public class Stage3: Stage
    {
        public List<string> proceed = new List<string>();
        public List<string> newproceed = new List<string>();
        public double size1 = 0;
        public double size2 = 0;
        public bool added = false; 


        public void getProcced()
        {
            string contentProceed = FILEWORK.ReadFileContent(PATH.imgProcessedFile);
            String[] row = contentProceed.Split(new string[] { "\n" }, StringSplitOptions.None);
            foreach (string st in row)
            {
                if (String.IsNullOrEmpty(st))
                {
                    return;
                }
                proceed.Add(st);
            }
        }





        public void setProcced()
        {
            List<string> res = new List<string>();
            res.AddRange(proceed);
            res.AddRange(newproceed);
            string result = string.Join("\n", res);
            FILEWORK.WriteFileContent(PATH.imgProcessedFile, result);
        }




        public override void WORK()
        {
            getProcced();

            List<string> files = new List<string>();
            files = FILEWORK.GetAllFiles(PATH.data, files, ".jpg");
            foreach (String f in files)
            {
                string fullName = f;
                String[] ll = f.Split(new string[] { "\\" }, StringSplitOptions.None);
                string fname = ll.Last();
                DATA.imageDict.Add(fname, fullName);
                DATA.RevImageDict.Add(fullName, fname);
                if (!proceed.Contains(fname))
                {
                    newproceed.Add(fname);
                }
                

            }


            foreach (string s in newproceed)
            {
                List<double> res = IMAGEWORKER.lessImageSet(s);
                size1 = size1 + res[0];
                size2 = size2 + res[1];
                added = true;
            }
            setProcced();

            if (added)
            {
                Console.WriteLine("{0} {1}->{2}", CONST._INS, size1,size2);
            }

        }

        public Stage3(string name) : base(name)
        {
        }
    }
}
