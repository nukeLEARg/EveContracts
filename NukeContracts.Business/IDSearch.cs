using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace NukeContracts.Business
{
    public class IDSearch
    {
        public List<Item> items { get; set; }

        public IDSearch()
        {
            items = new List<Item>();
            buildItemList();
        }


        public string getName(int id)
        {
            var found = items.SingleOrDefault(Item => Item.type_id == id);
            if (found != null)
                return found.item_name;
            else
                return "name not found";
        }


        private void buildItemList()
        {
            List<string> splitted = new List<string>();
            string fileList = GetCSV("https://www.fuzzwork.co.uk/resources/typeids.csv");

            TextFieldParser parser = new TextFieldParser(new StringReader(fileList));
            
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            while (!parser.EndOfData)
            {
                try
                {
                    string[] tempStr = parser.ReadFields();
                    items.Add(new Item(tempStr[0], tempStr[1]));
                }
                catch(MalformedLineException e)
                {
                    items.Add(new Item("-1","ERROR"));
                }

            }
            //Item test = items[2937];
            int x = 1;
        }
        
        private string GetCSV(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            
            return results;
        }
    }

    

}
