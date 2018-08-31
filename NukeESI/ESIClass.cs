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
        const string BaseURL = "https://esi.evetech.net/latest/";
        public int XPages {get; set;}

        public ESIClass()
        {
        }

        public T ExecuteESI<T>(string requestString) where T : new()
        {
            var request = new RestRequest(requestString + "&page=1");
            var client = new RestClient();
            client.UserAgent = "EveContractTool-Nuke Michael";
            client.BaseUrl = new System.Uri(BaseURL);
            var response = client.Execute<T>(request);
            var header = response.Headers.SingleOrDefault(Parameter => Parameter.Name == "X-Pages");
            XPages = (int)header.Value;
            return response.Data;
        }

        public List<ContractCall> GetContracts(string regionid)
        {
            string request = $"contracts/public/{regionid}/?datasource=tranquility";
            List<ContractCall> contracts = new List<ContractCall>();
            contracts = ExecuteESI<List<ContractCall>>(request);
            
            return contracts;
        }

        public List<ContractContents> pullContract(int contract_id)
        {
            string request = $"contracts/public/items/{contract_id}/?datasource=tranquility";
            List<ContractContents> contents = new List<ContractContents>();
            contents = ExecuteESI<List<ContractContents>>(request);

            return contents;
        }
    }
}
