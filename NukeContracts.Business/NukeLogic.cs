using AutoMapper;
using AutoMapper.QueryableExtensions;
using ESI.NET;
using ESI.NET.Enumerations;
using Microsoft.Extensions.Options;
using NukeContracts.Business.Enumerations;
using NukeContracts.Business.Models;
using NukeContracts.Business.Models.Contracts;
using NukeContracts.Business.Models.Universe;
using EsiContract = ESI.NET.Models.Contracts.Contract;
using EsiContractItem = ESI.NET.Models.Contracts.ContractItem;
using EsiPosition = ESI.NET.Models.Position;
using EsiStation = ESI.NET.Models.Universe.Station;
using EsiStructure = ESI.NET.Models.Universe.Structure;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using NukeContracts.Business.Helpers;

namespace NukeContracts.Business
{
    public class NukeLogic
    {
        private IOptions<EsiConfig> Config { get; set; }
        private EsiClient Esi { get; set; }

        private Dictionary<Region, List<Contract>> _contracts = new Dictionary<Region, List<Contract>>();

        public NukeLogic()
        {
            Config = Options.Create(new EsiConfig()
            {
                EsiUrl = "https://esi.evetech.net/", //"https://esi.tech.ccp.is/",
                DataSource = DataSource.Tranquility,
                //ClientId = "**********",
                //SecretKey = "**********",
                CallbackUrl = "",
                UserAgent = "EveContractTool-Nuke Michael"
            });

            Esi = new EsiClient(Config);
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<EsiProfile>();
                cfg.CreateMissingTypeMaps = true;
            });
            Mapper.Configuration.CompileMappings();
        }

        public List<Contract> Contracts(Region region)
        {
            if (!Enum.IsDefined(typeof(Region), (int)region)) throw new ArgumentException($"Invalid region value. ({(int)region}).", "region");
            if (!_contracts.ContainsKey(region)) //while we dont handle etags, lets use this as cache
            {
                //todo : handle request status
                //include auctions?
                var result = AsyncHelper.RunSync(() => Esi.Contracts.Contracts((int)region));
                var contracts = result.Data.Where(c => c.Type == ContractType.ItemExchange).AsQueryable().ProjectTo<Contract>().ToList();
                var tasks = new List<Task>();

                contracts.ForEach(c =>
                {
                    //todo : create a Task for sub-fetches

                    //c.Structure = Structure(c.StartLocationId); //PRIVATE ENDPOINT!
                    if (c.StartLocationId <= int.MaxValue) c.Station = Station((int)c.StartLocationId); // "<= int.MaxValue" good enough or validate stationId value range?

                    c.Items.AddRange(ContractItems(c.ContractId) ?? Enumerable.Empty<ContractItem>());
                    
                    //todo : fetch each item's additional data (Type, Dogma, Dynamic)~

                    //todo : add Task to tasks!
                });

                //todo : await all subtasks and fire an event of progress either time based or after each Task completes

                //todo : eventually filter mutaplasmid only contracts here. (if desired)

                _contracts.Add(region, contracts);
            }
            return _contracts[region];
        }

        public IEnumerable<ContractItem> ContractItems(int contractId)
        {
            var result = AsyncHelper.RunSync(() => Esi.Contracts.ContractItems(contractId));
            return result.Data?.AsQueryable().ProjectTo<ContractItem>();
        }

        public Station Station(int stationId)
        {
            var result = AsyncHelper.RunSync(() => Esi.Universe.Station(stationId));
            return Mapper.Map<Station>(result.Data);
        }

        public Structure Structure(long structureId)
        {
            var result = AsyncHelper.RunSync(() => Esi.Universe.Structure(structureId));
            return Mapper.Map<Structure>(result.Data);
        }

        /*
        public TypeCall pullTypeInfo(int type_id)
        {
            string request = $"/v3/universe/types/{type_id}/?datasource=tranquility";
            TypeCall typeInfo = new TypeCall();
            typeInfo = ExecuteESI<TypeCall>(request, 1);

            return typeInfo;
        }
        /**/
    }
}
