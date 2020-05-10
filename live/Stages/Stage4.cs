using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using live.Entity;
using live.Entity.Base;

namespace live.Stages
{
    public class Stage4: Stage
    {
        public override void WORK()
        {
            Console.WriteLine("");


            //создание TRAVEL
            createTravels();


            //создание обычных моделей
            foreach (var rf in PATH.refs)
            {
                createModels(rf.destinationPass);
            }


        }

        public void createTravels()
        {
            DirectoryInfo di = new DirectoryInfo(PATH.datat);
            string _type = di.Name;
            DirectoryInfo[] diA = di.GetDirectories();

            foreach (DirectoryInfo f in diA)
            {
                createTravel(f);
            }
            int j = DATA._TRAVELS.Count();
            string ins = new String(' ', 20 - "TRAVEL".Length);
            Console.WriteLine(String.Format("{0}{1} {2} {4} {3}", CONST._INS, "MODELS: ", "TRAVEL", j, ins));

        }

        public void createTravel(DirectoryInfo f)
        {
            TRAVEL travel = new TRAVEL();
            string name = f.Name;
            travel.dataFolderPath = f.FullName;

            travel.Id = Convert.ToInt32(name);
            string content = FILEWORK.ReadFileContent(f.FullName + "//info.txt");
            String[] lines = content.Split(new string[] { "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }
                if (travel.name == null)
                {
                    travel.name = line;
                    continue;
                }

                if (travel.ldate == null)
                {
                    travel.ldate = line;
                    continue;
                }

                if (travel.lcount == null)
                {
                    travel.lcount = line;
                    continue;
                }

                if (line.Contains(".jpg"))
                {
                    travel.mainIng.Add(line);
                }


            }

            List<string> imgs = new List<string>();
            travel.imgs = FILEWORK.GetAllFiles(travel.dataFolderPath, imgs, ".jpg");

            List<string> txts = new List<string>();
            txts = FILEWORK.GetAllFiles(travel.dataFolderPath, txts, ".txt");
            foreach (string s in txts)
            {
                FileInfo ff = new FileInfo(s);
                string fname = ff.Name;
                String[] ll = fname.Split(new string[] { ".txt" }, StringSplitOptions.None);
                string shortName = ll[0];
                int number;
                bool success = Int32.TryParse(shortName, out number);
                if (success)
                {
                    string cont = FILEWORK.ReadFileContent(ff.FullName);
                    travel.destrictions.Add(number, cont);

                }
            }

            DATA._TRAVELS.Add(travel);
        }



        private void createModels(string dirPathFull)
        {
            int j = 0;
            DirectoryInfo di = new DirectoryInfo(dirPathFull);
            string _type = di.Name;
            DirectoryInfo[] diA = di.GetDirectories();
            foreach (var f in diA)
            {
                string path = f.FullName;
                CONTENT content = getContent(path, _type);
                j++;

                switch (_type)
                {
                    case "DOGANDCAT":
                        DATA._DOGANDCAT.Add(content as DOGANDCAT);
                        DATA._CONTENT.Add(content);

                        break;
                    case "FRIENDS":
                        DATA._FRIENDS.Add(content as FRIENDS);
                        DATA._CONTENT.Add(content);

                        break;
                    case "SPORT":
                        DATA._SPORT.Add(content as SPORT);
                        DATA._CONTENT.Add(content);

                        break;
                    case "WORKOUT":
                        DATA._WORKOUT.Add(content as WORKOUT);
                        DATA._CONTENT.Add(content);

                        break;
                    case "FOOD":
                        DATA._FOOD.Add(content as FOOD);
                        DATA._CONTENT.Add(content);

                        break;

                    default:
                        Console.WriteLine("WRONG TYPE!!!");
                        break;
                }

            }
            DATA._DOGANDCAT = DATA._DOGANDCAT.OrderBy(o => o.Id).ToList();
            DATA._FRIENDS = DATA._FRIENDS.OrderBy(o => o.Id).ToList();
            DATA._SPORT = DATA._SPORT.OrderBy(o => o.Id).ToList();
            DATA._WORKOUT = DATA._WORKOUT.OrderBy(o => o.Id).ToList();
            DATA._FOOD = DATA._FOOD.OrderBy(o => o.Id).ToList();


            string ins = new String(' ', 20 - _type.Length);

            Console.WriteLine(String.Format("{0}{1} {2} {4} {3}", CONST._INS, "MODELS: ", _type, j,ins));



        }

        private CONTENT getContent(String path, string _type)
        {
            CONTENT content = new CONTENT();


            switch (_type)
            {
                case "DOGANDCAT":
                    content = new DOGANDCAT();
                    break;
                case "FRIENDS":
                    content = new FRIENDS();
                    break;
                case "SPORT":
                    content = new SPORT();
                    break;
                case "WORKOUT":
                    content = new WORKOUT();
                    break;
                case "FOOD":
                    content = new FOOD();
                    break;
                default:
                    Console.WriteLine("WRONG TYPE!!!");
                    break;
            }

            String[] ll = path.Split(new string[] {"\\"}, StringSplitOptions.None);
            string si = ll.Last();
            content.Id = Convert.ToInt32(si);
            content.dataFolderPath = path;
            content.parse();
            return content;
        }

        //заполняемые данные


        //Создание моделей
        public Stage4(string name) : base(name)
        {

        }
    }
}
