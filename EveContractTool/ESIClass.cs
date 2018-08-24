using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace EveContractTool
{
    public class ESIClass
    {
        const string BaseURL = "https://esi.evetech.net/latest/";

        public ESIClass()
        {
        }

        public T ExecuteESI<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new System.Uri(BaseURL);
            var response = client.Execute<T>(request);
            
            return response.Data;
        }

        public List<ContractCall> GetContracts(string regionid)
        {
            var request = new RestRequest($"contracts/public/{regionid}/?datasource=tranquility&page=1");
            List <ContractCall> contracts = new List<ContractCall>();
            for (int i = 0; i < 1; i++)
            {
                contracts.Add(ExecuteESI<ContractCall>(request));
            }

            return contracts;
        }
    }
}
