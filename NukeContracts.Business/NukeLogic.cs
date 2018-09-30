using AutoMapper;
using ESI.NET;
using ESI.NET.Enumerations;
using Microsoft.Extensions.Options;
using NukeContracts.Business.Enumerations;
using NukeContracts.Business.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using ESIContract = ESI.NET.Models.Contracts.Contract;

namespace NukeContracts.Business
{
    public class NukeLogic
    {
        private IOptions<EsiConfig> Config { get; set; }
        private EsiClient Esi { get; set; }

        private Dictionary<Region, IEnumerable<Contract>> _contracts = new Dictionary<Region, IEnumerable<Contract>>();
        private static IMapper mapper = EsiMapper.Mapper;

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
        }

        public IEnumerable<Contract> Contracts(Region region)
        {
            if (!Enum.IsDefined(typeof(Region), (int)region)) throw new ArgumentException($"Invalid region value. ({(int)region}).", "region");
            if (!_contracts.ContainsKey(region)) //while we dont handle etags, lets use this as cache
            {
                var x = Esi.Contracts.Contracts((int)region);
                //possibly do stuff here with the task for progress event and shit. status / validation etc?
                var contracts = x.Result.Data.Select(mapper.Map<ESIContract, Contract>);
                //todo : get individual contract details and items etc etc
                //todo : add fields to Contract class for other sub-dto fields and then map them in automapper
                //todo : eventually filter mutaplasmid only contracts here. (if desired)
                _contracts.Add(region, contracts);
            }
            return _contracts[region];
        }
    }
}
