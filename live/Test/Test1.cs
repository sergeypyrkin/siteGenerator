using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace live.Test
{

    public class Test1
    {

        public string logi = "C:\\Users\\Programmist\\Desktop\\MYLIVE\\DATA\\VIDEO\\logi.html";
        public Dictionary<string, User> dict = new Dictionary<string, User>();
        public Test1()
        {
        
            string content = FILEWORK.ReadFileContent(logi);
            String[] lines = content.Split(new string[] { "\n" }, StringSplitOptions.None);
            User cu = null;
            
            foreach (string  s  in lines)
            {
                if (s.Contains("TTD_HOCKEY ENTER Calendar"))
                {
                    User u = parseUser(s);
                    cu = u;
                    if (!dict.ContainsKey(u.Name))
                    {
                        dict.Add(u.Name, u);
                    }

                }

                if (cu != null)
                {
                    if (s.Contains("Physical address ........................ :"))
                    {
                        string name = parseName(s);
                        User u = dict[cu.Name];
                        if (!u.hosts.Contains(name))
                        {
                            u.hosts.Add(name);
                        }
                        cu = null;

                    }

                }
            }

            foreach (KeyValuePair<string, User> keyValue in dict)
            {
                Console.WriteLine("===================");

                Console.WriteLine(keyValue.Key);
                var result = String.Join(", ", keyValue.Value.hosts.ToArray());
                Console.WriteLine(result);

            }

        }

        private string parseName(String line)
        {

            String[] sl = line.Split(new string[] { "Physical address ........................ :" }, StringSplitOptions.None);
            string uname = sl[1];

            String[] sl2 = uname.Split(new string[] { "\n" }, StringSplitOptions.None);

            String s = sl2[0];
            return s;
        }

        private User parseUser(string s)
        {
            String[] lines = s.Split(new string[] { "TTD_HOCKEY ENTER Calendar" }, StringSplitOptions.None);
            String preLine = lines[1];

            String[] lines2 = preLine.Split(new string[] { "(" }, StringSplitOptions.None);
            String name = lines2[0];



            User u = new User();
            u.Name = name;
            return u;
        }


        public class User
        {
            public string Name;
            public List<String> hosts = new List<string>();
        }

    }
}
