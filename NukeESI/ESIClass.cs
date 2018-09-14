using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace NukeESI
{
    public class ESIClass
    {
        const string BaseURL = "https://esi.evetech.net/";
        public int XPages {get; set;}

        public ESIClass()
        {
        }

        public T ExecuteESI<T>(string requestString, int page) where T : new()
        {
            var request = new RestRequest(requestString + $"&page={page}");
            var client = new RestClient();
            client.UserAgent = "EveContractTool-Nuke Michael";
            client.BaseUrl = new System.Uri(BaseURL);
            var response = client.Execute<T>(request);
            var header = response.Headers.SingleOrDefault(Parameter => Parameter.Name == "X-Pages");
            if (header != null)
            {
                int pages = 0;
                Int32.TryParse(header.Value.ToString(), out pages);
                XPages = pages;
            }
            else
            {
                string shitbroke = "shitbroke";
            }
            return response.Data;
        }

        public List<ContractCall> GetContracts(string regionid)
        {
            XPages = 1;
            string request = $"v1/contracts/public/{regionid}/?datasource=tranquility";
            List<ContractCall> contractsFinal = new List<ContractCall>();
            contractsFinal = ExecuteESI<List<ContractCall>>(request,1);
            for(int page = 2; page<=XPages; page++)
            {
                List<ContractCall> contracts = ExecuteESI<List<ContractCall>>(request, page);
                contractsFinal.AddRange(contracts);
            }
            return contractsFinal;
        }

        public List<ContractContents> pullContract(int contract_id)
        {
            string request = $"v1/contracts/public/items/{contract_id}/?datasource=tranquility";
            List<ContractContents> contents = new List<ContractContents>();
            contents = ExecuteESI<List<ContractContents>>(request,1);

            return contents;
        }
    }
}
