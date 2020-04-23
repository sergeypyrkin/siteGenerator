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
        public string dataFolderPath;
        public string infoPath;
    

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
                
            }
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
