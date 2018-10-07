using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace NukeContracts.Business
{
    public static class IDSearch
    {
        public static readonly Dictionary<string,string> Items = new Dictionary<string, string>();
                
        public async static void BuildItemList()
        {
            StreamReader sr = new StreamReader(@"App_Data\typeids.csv");
            string content = sr.ReadToEnd().Replace("\"", "");
            sr.Close();

            TextFieldParser parser = new TextFieldParser(new StringReader(content));
            parser.SetDelimiters(",");

            await Task.Run(() =>
            {
                while (!parser.EndOfData)
                {
                    try
                    {
                        string[] tempStr = parser.ReadFields();
                        Items[tempStr[0]] = tempStr[1];
                    }
                    catch (MalformedLineException e)
                    {
                        Debug.WriteLine($"MalformedLineException : {e.Message}");
                    }
                }
            });
        }
    }
}
