using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live
{
    public class FILEWORK
    {

        public static List<string> GetAllFiles(string sDir, List<string> files)
        {
            
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        files.Add(f);
                    }
                    GetAllFiles(d,files);
                }
                return files;
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
                return new List<string>();
            }

        }
    }
}
