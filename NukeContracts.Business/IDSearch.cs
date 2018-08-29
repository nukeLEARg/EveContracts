using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

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
            return found.item_name;
        }


        private void buildItemList()
        {
            List<string> splitted = new List<string>();
            string fileList = GetCSV("https://www.fuzzwork.co.uk/resources/typeids.csv");
            string[] tempStr;

            tempStr = fileList.Split(',');

            foreach (string item in tempStr)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    splitted.Add(item);
                }
            }

            for(int i = 0; i<splitted.Count; i+=3)
            {
                items.Add(new Item(splitted[i],splitted[i+1]));
            }
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
