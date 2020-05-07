using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live.Entity
{

    //базовый класс для Контентов
    public class CONTENT: ICreateHtml
    {
        //основные данные
        public int Id;
        public string _type;
        public DateTime date;
        public string title;
        public string mainText;
        public string mainImg;
        public List<string> imgs = new List<string>();
        public List<string> youtubs = new List<string>();
        


        //вспомогательные
        public bool hasYoutube;
        public bool hasImgs;
        public string link;
        public string dataFolderPath;
        public string infoPath;
        public List<string> txtContents = new List<string>();
   

        //для парсинга






    

        public void parse()
        {
            List<string> imgs = new List<string>();
            this.imgs = FILEWORK.GetAllFiles(dataFolderPath, imgs, ".jpg");
            this.hasImgs = this.imgs.Count > 0;

            List<string> txts = new List<string>();
            txts = FILEWORK.GetAllFiles(dataFolderPath, txts, ".txt");
            this.infoPath = txts[0];

            string content = FILEWORK.ReadFileContent(infoPath);
            String[] lines = content.Split(new string[] { "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }

                DateTime dateTime;
                if (DateTime.TryParse(line, out dateTime))
                {
                    this.date = dateTime;
                    continue;
                }

                if (line.Contains("youtu"))
                {
                    string youtube = parseYoutubs(line);
                    youtubs.Add(youtube);
                    hasYoutube = true;
                    continue;
                }

                if (line.Contains(".jpg"))
                {
                    mainImg = line;
                    continue;
                }

                txtContents.Add(line);



            }

            //теперь разрешаем title/соntent
            if (txtContents.Count == 1)
            {
                this.title = this.date.ToString("yyyy-MM-dd");
                this.mainText = txtContents[0];
            }

            if (txtContents.Count == 2)
            {

                txtContents = txtContents.OrderBy(o => o.Length).ToList();
                this.title = txtContents[0];
                this.mainText = txtContents[1];
            }


        }

        private string parseYoutubs(string line)
        {
            string result = "";
            String[] ll = line.Split(new string[] { "/" }, StringSplitOptions.None);
            string last = ll.Last();
            result = "https://www.youtube.com/embed/" + last;
            return result;
        }


        public string toString()
        {
            return _type;
        }

        public void getTemplate(string path)
        {

        }

        public void createHtmlString()
        {

        }

        public void createHtml()
        {

        }
    }
}
