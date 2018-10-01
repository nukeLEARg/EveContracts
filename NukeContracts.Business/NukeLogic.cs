using AutoMapper;
using AutoMapper.QueryableExtensions;
using ESI.NET;
using ESI.NET.Enumerations;
using Microsoft.Extensions.Options;
using NukeContracts.Business.Enumerations;
using NukeContracts.Business.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using ESIContract = ESI.NET.Models.Contracts.Contract;
using ESIContractItem = ESI.NET.Models.Contracts.ContractItem;

namespace NukeContracts.Business
{
    public class NukeLogic
    {
        private IOptions<EsiConfig> Config { get; set; }
        private EsiClient Esi { get; set; }

        private Dictionary<Region, IEnumerable<Contract>> _contracts = new Dictionary<Region, IEnumerable<Contract>>();

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
            Mapper.Initialize(cfg => {
                cfg.AddProfile<EsiProfile>();
                cfg.CreateMissingTypeMaps = true;
            });
            Mapper.Configuration.CompileMappings();
        }

        public IEnumerable<Contract> Contracts(Region region)
        {
            if (!Enum.IsDefined(typeof(Region), (int)region)) throw new ArgumentException($"Invalid region value. ({(int)region}).", "region");
            if (!_contracts.ContainsKey(region)) //while we dont handle etags, lets use this as cache
            {
                var task = Esi.Contracts.Contracts((int)region);
                //todo : do stuff here with the task for progress event
                //include auctions?
                var contracts = task.Result.Data.Where(c => c.Type == ContractType.ItemExchange).AsQueryable().ProjectTo<Contract>().ToList();
                contracts.ForEach(c =>
                {
                    //todo : create parallel tasks for sub-fetching

                    //todo : fetch structure

                    var items = ContractItems(c.ContractId);
                    if (items != null) c.Items.AddRange(items);

                    //todo : eventually filter mutaplasmid only contracts here. (if desired)

                    //todo : fetch each item's additional data (Type, Dogma, Dynamic)~
                });

                _contracts.Add(region, contracts);
            }
            return _contracts[region];
        }

        public IEnumerable<ContractItem> ContractItems(int contractId)
        {
            var task = Esi.Contracts.ContractItems(contractId);
            return task.Result.Data?.AsQueryable().ProjectTo<ContractItem>();
        }

        /*
        public async Task<ESIStructure> pullStructure(long station_id)
        {
            string request = $"v2/universe/stations/{station_id}/?datasource=tranquility";
            ESIStructure station = new ESIStructure();
            station = await ExecuteESIAsync<ESIStructure>(request).ConfigureAwait(false);

            return station;
        }

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
