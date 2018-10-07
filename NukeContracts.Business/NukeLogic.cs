using AutoMapper;
using AutoMapper.QueryableExtensions;
using ESI.NET;
using ESI.NET.Enumerations;
using Microsoft.Extensions.Options;
using NukeContracts.Business.Enumerations;
using NukeContracts.Business.Events;
using NukeContracts.Business.Helpers;
using NukeContracts.Business.Models.Contracts;
using NukeContracts.Business.Models.Items;
using NukeContracts.Business.Models.Universe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EsiContract = ESI.NET.Models.Contracts.Contract;
using Type = NukeContracts.Business.Models.Items.Type;

namespace NukeContracts.Business
{
    public class NukeLogic
    {
        #region Properties

        private IOptions<EsiConfig> Config { get; set; }
        private EsiClient Esi { get; set; }

        private List<ContractType> _includedTypes = new List<ContractType>(){ ContractType.ItemExchange, ContractType.Auction };
        private Dictionary<Region, List<Contract>> _contracts = new Dictionary<Region, List<Contract>>();

        /// <summary>
        /// 
        /// </summary>
        public event ContractDetailsLoadedEventHandler ContractLoaded;

        #endregion

        #region Contructors

        /// <summary>
        /// 
        /// </summary>
        public NukeLogic() : this("", "") { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="secret"></param>
        public NukeLogic(string client, string secret)
        {
            Config = Options.Create(new EsiConfig()
            {
                EsiUrl = "https://esi.evetech.net/",
                DataSource = DataSource.Tranquility,
                ClientId = client,
                SecretKey = secret,
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

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public List<Contract> Contracts(Region region)
        {
            if (!Enum.IsDefined(typeof(Region), (int)region)) throw new ArgumentException($"Invalid region value. ({(int)region}).", "region");
            if (!_contracts.ContainsKey(region)) //while we dont handle etags, lets use this as cache
            {
                #region Contracts

                EsiResponse<List<EsiContract>> response;
                var contracts = new List<Contract>();
                var page = 1;
                do
                {
                    response =  AsyncHelper.RunSync(() => Esi.Contracts.Contracts((int)region, page));
                    if (response.StatusCode != HttpStatusCode.OK) return null;
                    
                    contracts.AddRange(response.Data.Where(c => _includedTypes.Contains(c.Type)).AsQueryable().ProjectTo<Contract>().ToList());
                } while (++page < response.Pages);

                #endregion

                #region Contract Details

                var tasks = new List<Task>();
                contracts.ForEach(c =>
                {
                    Task.Factory.StartNew(() =>
                    {
                        #region Contract Location

                        //c.Structure = Structure(c.StartLocationId); //PRIVATE ENDPOINT!
                        if (c.StartLocationId <= int.MaxValue) c.Station = Station((int)c.StartLocationId); // "<= int.MaxValue" good enough or validate stationId value range?

                        #endregion

                        #region Contract Items

                        var items = ContractItems(c.ContractId) ?? Enumerable.Empty<ContractItem>();
                        items.ToList().ForEach(i =>
                        {
                            if (true) //todo: replace true with a is dynamic item check
                            {
                                //i.Dogma = DynamicDogma(i.ItemId, i.TypeId);
                            }
                            i.Type = Type(i.TypeId);
                        });
                        
                        c.ItemsOffered.AddRange(items.Where(i => i.ItemId != 0));
                        c.ItemsAsked.AddRange(items.Where(i => i.ItemId != 0));

                        #endregion
                        
                        Debug.WriteLine($"Contract[{c.ContractId}] details finished loading.");
                        c.isLoaded = true;
                        ContractLoaded(this, new ContractLoadedEventArgs() { ContractId = c.ContractId });
                    });
                });

                #endregion

                _contracts.Add(region, contracts);
            }
            return _contracts[region];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        public IEnumerable<ContractItem> ContractItems(int contractId) => AsyncHelper.RunSync(() => Esi.Contracts.ContractItems(contractId)).Data?.AsQueryable().ProjectTo<ContractItem>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public Station Station(int stationId) => Mapper.Map<Station>(AsyncHelper.RunSync(() => Esi.Universe.Station(stationId)).Data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="structureId"></param>
        /// <returns></returns>
        public Structure Structure(long structureId) => Mapper.Map<Structure>(AsyncHelper.RunSync(() => Esi.Universe.Structure(structureId)).Data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item_id"></param>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public Dogma DynamicDogma(long item_id, int type_id) => Mapper.Map<Dogma>(AsyncHelper.RunSync(() => Esi.Dogma.DynamicItem(type_id, item_id)).Data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public Type Type(int type_id) => Mapper.Map<Type>(AsyncHelper.RunSync(() => Esi.Universe.Type(type_id)).Data);

        #endregion
    }
}
