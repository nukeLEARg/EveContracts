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
        public string header;
        public ESIClass()
        {
        }

        public T ExecuteESI<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.UserAgent = "EveContractTool-Nuke Michael";
            client.BaseUrl = new System.Uri(BaseURL);
            var response = client.Execute<T>(request);
            foreach (var head in response.Headers)
            {
                header += head.Name + ": " + head.Value + " ";
            }
            return response.Data;
        }

        public List<ContractCall> GetContracts(string regionid)
        {
            var request = new RestRequest($"contracts/public/{regionid}/?datasource=tranquility&page=1");
            List <ContractCall> contracts = new List<ContractCall>();
            contracts = ExecuteESI<List<ContractCall>>(request);

            return contracts;
        }
    }
}
