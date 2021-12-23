using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity;
using Microsoft.SqlServer.Server;

namespace live.Stages
{
    public class Stage2 : Stage
    {

        //на этом этапе, копируем новый контент в папки data + приводим в порядок ихний info.txt


        public override void WORK()
        {

            if (DATA._newExist)
            {
                // Console.WriteLine(CONST._INS + "НЕЧЕГО ДОБАВИТЬ");
                return;
            }



            foreach (var _ref in PATH.refs)
            {
                DirectoryInfo di = new DirectoryInfo(_ref.newPass);

                if (_ref._type == "FOOD")
                {
                    //для котов
                    catParseWork(_ref, di);
                   
                    continue;
                }


                DirectoryInfo[] diA = di.GetDirectories();
                int stIndex = getStartIndex(_ref.destinationPass);
                foreach (var content in diA)
                {

                    string ins = new String(' ', 20 - "CHANGE".Length);

                    //переписываем данные файла info.txt
                    Console.WriteLine(String.Format("{0}{1}{3}| {2}", CONST._INS, "CHANGE", content.Name, ins));
                    changeInfoContent(content);
                }


                DirectoryInfo[] diAAfter1 = di.GetDirectories();
                foreach (var content in diAAfter1)
                {
                    FILEWORK.renameDir(content.FullName, stIndex.ToString());
                    stIndex = stIndex + 1;
                }

                DirectoryInfo[] diAAfter2 = di.GetDirectories();

                foreach (var content in diAAfter2)
                {
                    addNewContent(content);
                    string ins = new String(' ', 20 - "COPY".Length);
                    //переписываем данные файла info.txt
                    Console.WriteLine(String.Format("{0}{1}{3}| {2}", CONST._INS, "COPY", content.Name, ins));
                    string oldName = content.FullName;
                    string newName = _ref.destinationPass + "\\" + content.Name;
                    FILEWORK.moveDir(oldName, newName);
                    // changeInfoContent(content);
                }
            }

        }

        private void addNewContent(DirectoryInfo content)
        {
            int index = Convert.ToInt32(content.Name);
            string _type = content.Parent.Name;
            string spref = _type + "_" + index;
            DATA._newContent.Add(spref, _type);

        }

        private void catParseWork(refItem _ref, DirectoryInfo di)
        {
            int stIndex2 = getStartIndex(_ref.destinationPass);
            FileInfo[] fi = di.GetFiles();
            foreach (var content in fi)
            {

                string ins = new String(' ', 20 - "CHANGE".Length);

                //переписываем данные файла info.txt
                Console.WriteLine(String.Format("{0}{1}{3}| {2}", CONST._INS, "CHANGE", content.Name, ins));
                //1. создаем папкочку
                string pass = _ref.destinationPass + "//" + stIndex2.ToString();
                Directory.CreateDirectory(pass);
                //2. копируем картинку
                string fname = content.FullName;
                string relPath = _ref.destinationPass + "//" + stIndex2.ToString() + "//";
                string destname = relPath + content.Name;
                File.Move(fname, destname);
                //3. создание txt
                string newName = relPath + "info.txt";
                //File.Create(newName);
                //4. запись даты
                FileInfo f = new FileInfo(destname);
                var d = File.GetLastWriteTime(destname);
                string tdade = d.ToString("yyyy-MM-dd HH:mm:ss");

                string newContent = tdade + "\n\n";
                FILEWORK.WriteFileContent(newName, newContent);
                stIndex2++;

                // changeInfoContent(content);
            }
        }


        public void changeInfoContent(DirectoryInfo content)
        {
            List<string> txts = new List<string>();
            txts = FILEWORK.GetAllFiles(content.FullName, txts, ".txt");
            string txtFi = txts[0];
            string fc = FILEWORK.ReadFileContent(txtFi);


            List<string> imgs = new List<string>();
            imgs = FILEWORK.GetAllFiles(content.FullName, imgs, ".jpg");
            string imgFi = imgs[0];

            FileInfo f = new FileInfo(imgFi);
            var d = File.GetLastWriteTime(imgFi);
            string tdade = d.ToString("yyyy-MM-dd HH:mm:ss");

            string newContent = tdade + "\n\n"+fc;
            FILEWORK.WriteFileContent(txtFi, newContent);

            //меняем название на info.txt
            FileInfo f2 = new FileInfo(txtFi);

            string newName = content.FullName + "\\info.txt"; 
            System.IO.File.Move(f2.FullName, newName);



        }

        public int getStartIndex(string path)
        {
            int max = 0;
            string[] diA = Directory.GetDirectories(path);
            List<int> names = new List<int>();
            foreach (string s in diA)
            {
                String[] ll = s.Split(new string[] { "\\" }, StringSplitOptions.None);
                String last = ll.Last();
                int i = Convert.ToInt32(last);
                names.Add(i);
            }
            if (names.Count > 0)
            {
                max = names.Max(t => t);
            }
            max = max + 1;
            return max;
        }



        public Stage2(string name) : base(name)
        {
        }
    }



}
