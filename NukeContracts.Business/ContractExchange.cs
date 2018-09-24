using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NukeESI;

namespace NukeContracts.Business
{
    public class ContractExchange
    {
        public static readonly List<Object> regions = new List<Object> { new { Name = "Derelik", id = 10000001 }, new { Name = "The Forge", id = 10000002 },
            new { Name = "Vale of the Silent", id = 10000003 }, new { Name = "UUA-F4", id = 10000004 }, new { Name = "Detorid", id = 10000005 }, new { Name = "Wicked Creek", id = 10000006 },
            new { Name = "Cache", id = 10000007 }, new { Name = "Scalding Pass", id = 10000008 }, new { Name = "Insmother", id = 10000009 }, new { Name = "Tribute", id = 10000010 },
            new { Name = "Great Wildlands", id = 10000011 }, new { Name = "Curse", id = 10000012 }, new { Name = "Malpais", id = 10000013 }, new { Name = "Catch", id = 10000014 },
            new { Name = "Venal", id = 10000015 }, new { Name = "Lonetrek", id = 10000016 }, new { Name = "J7HZ-F", id = 10000017 }, new { Name = "The Spire", id = 10000018 },
            new { Name = "A821-A", id = 10000019 }, new { Name = "Tash-Murkon", id = 10000020 }, new { Name = "Outer Passage", id = 10000021 }, new { Name = "Stain", id = 10000022 },
            new { Name = "Pure Blind", id = 10000023 }, new { Name = "Immensea", id = 10000025 }, new { Name = "Etherium Reach", id = 10000027 }, new { Name = "Molden Heath", id = 10000028 },
            new { Name = "Geminate", id = 10000029 }, new { Name = "Heimatar", id = 10000030 }, new { Name = "Impass", id = 10000031 }, new { Name = "Sinq Laison", id = 10000032 },
            new { Name = "The Citadel", id = 10000033 }, new { Name = "The Kalevala Expanse", id = 10000034 }, new { Name = "Deklein", id = 10000035 }, new { Name = "Devoid", id = 10000036 },
            new { Name = "Everyshore", id = 10000037 }, new { Name = "The Bleak Lands", id = 10000038 }, new { Name = "Esoteria", id = 10000039 }, new { Name = "Oasa", id = 10000040 },
            new { Name = "Syndicate", id = 10000041 }, new { Name = "Metropolis", id = 10000042 }, new { Name = "Domain", id = 10000043 }, new { Name = "Solitude", id = 10000044 },
            new { Name = "Tenal", id = 10000045 }, new { Name = "Fade", id = 10000046 }, new { Name = "Providence", id = 10000047 }, new { Name = "Placid", id = 10000048 },
            new { Name = "Khanid", id = 10000049 }, new { Name = "Querious", id = 10000050 }, new { Name = "Cloud Ring", id = 10000051 }, new { Name = "Kador", id = 10000052 },
            new { Name = "Cobalt Edge", id = 10000053 }, new { Name = "Aridia", id = 10000054 }, new { Name = "Branch", id = 10000055 }, new { Name = "Feythabolis", id = 10000056 },
            new { Name = "Outer Ring", id = 10000057 }, new { Name = "Fountain", id = 10000058 }, new { Name = "Paragon Soul", id = 10000059 }, new { Name = "Delve", id = 10000060 },
            new { Name = "Tenerifis", id = 10000061 }, new { Name = "Omist", id = 10000062 }, new { Name = "Period Basis", id = 10000063 }, new { Name = "Essence", id = 10000064 },
            new { Name = "Kor-Azor", id = 10000065 }, new { Name = "Perrigen Falls", id = 10000066 }, new { Name = "Genesis", id = 10000067 }, new { Name = "Verge Vendor", id = 10000068 },
            new { Name = "Black Rise", id = 10000069 } };
        public List<Contract>[] Contracts;
        private int region;
        public int pages = 0;
        public int contracttotal = 0;
        public List<Task>[] TaskList;
        public List<Task> strucTaskList;
        public ContractExchange(int region_id)
        {
            Contracts = new List<Contract>[69];
            TaskList = new List<Task>[69];
            strucTaskList = new List<Task>();
            for (int i = 0; i < 69; i++)
            {
                Contracts[i] = new List<Contract>();
                TaskList[i] = new List<Task>();
            }
            region = region_id;
        }

        public void Pull()
        {
            NukeESI.ESIClass esi = new ESIClass();
            List<ContractCall> call = esi.GetContracts($"{region}");
            pages = esi.XPages;
            contracttotal = call.Count;
            for (int i = 0; i < call.Count; i++)
            {
                Contract hold = new Contract(call.ElementAt(i),i);
                TaskList[region - 10000000].Add(hold.buildContract(call.ElementAt(i)));
                TaskList[region - 10000000].Add(hold.resolveStructure(call.ElementAt(i)));
                //strucTaskList.Add(hold.resolveStructure(call.ElementAt(i)));
                Contracts[region - 10000000].Add(hold);
            }
            Task all = Task.WhenAll(TaskList[region - 10000000].ToArray());
            taskTester(all);
        }

        private async void taskTester(Task testMe)
        {
            await testMe;
            int shitDone = 1;
        }
    }
}
