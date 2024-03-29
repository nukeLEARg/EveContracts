﻿using AutoMapper;
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
        private Dictionary<Region, (List<Contract> contracts, Func<Contract, bool> filter)> _contracts = new Dictionary<Region, (List<Contract> contracts, Func<Contract, bool> filter)>();

        /// <summary>
        /// 
        /// </summary>
        public event ContractEventHandler ContractLoaded;
        
        /// <summary>
        /// 
        /// </summary>
        public event ContractEventHandler ContractsLoadingStarting;

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
        public List<Contract> Contracts(Region region, Func<Contract, bool> filter = null)
        {
            if (!Enum.IsDefined(typeof(Region), (int)region)) throw new ArgumentException($"Invalid region value. ({(int)region}).", "region");
            if (!_contracts.ContainsKey(region) || _contracts[region].filter != filter) //while we dont handle etags, lets use this as cache
            {
                #region Contracts

                EsiResponse<List<EsiContract>> response;
                var contracts = _contracts.ContainsKey(region) ? _contracts[region].contracts : new List<Contract>();
                var page = 1;
                do
                {
                    response =  AsyncHelper.RunSync(() => Esi.Contracts.Contracts((int)region, page));
                    if (response.StatusCode != HttpStatusCode.OK) return null;
                    
                    contracts.AddRange(response.Data.Where(c => _includedTypes.Contains(c.Type) && !contracts.Any(x => x.ContractId == c.ContractId)).AsQueryable().ProjectTo<Contract>().ToList());
                } while (++page < response.Pages);

                #endregion

                #region Filter

                if (filter == null) filter = (Contract c) => true;
                contracts = contracts.Where(c => filter(c)).ToList();

                #endregion

                #region Contract Details
                
                ContractsLoadingStarting(this, new ContractEventArgs { LoadingContractsAmmount = contracts.Count(c => !c.IsLoaded) });
                contracts.ForEach(c =>
                {

                    #region Contract Items
                    Task.Factory.StartNew(() =>
                    {
                        var items = ContractItems(c.ContractId) ?? Enumerable.Empty<ContractItem>();
                        items.ToList().ForEach(i =>
                        {
                            if (Enum.IsDefined(typeof(Dynamics),i.TypeId)) //todo: replace true with a is dynamic item check
                            {
                                i.Dogma = DynamicDogma(i.ItemId, i.TypeId);
                            }
                            i.Type = Type(i.TypeId);
                            int x = 0;
                        });

                        c.ItemsOffered.AddRange(items);
                        //c.ItemsAsked.AddRange(items.Where(i => i.ItemId != 0)); #FIX THIS LATER

                        Debug.WriteLine($"Contract[{c.ContractId}] details finished loading.");
                        c.IsLoaded = true;
                        ContractLoaded(this, new ContractEventArgs() { ContractId = c.ContractId });
                    });
                    #endregion

                    #region Contract Location
                    Task.Factory.StartNew(() =>
                    {
                        //c.Structure = Structure(c.StartLocationId); //PRIVATE ENDPOINT!
                        if (c.StartLocationId <= int.MaxValue) c.Station = Station((int)c.StartLocationId); // "<= int.MaxValue" good enough or validate stationId value range?
                    });
                    #endregion
                });

                #endregion

                _contracts[region] = (contracts, filter);
            }
            return _contracts[region].contracts;
        }

        public Contract Contract(int contractId)
        {
            throw new NotImplementedException();
        }
        
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

        #endregion

        #region Private Methods

        private IEnumerable<ContractItem> ContractItems(int contractId) => AsyncHelper.RunSync(() => Esi.Contracts.ContractItems(contractId)).Data?.AsQueryable().ProjectTo<ContractItem>();

        private Dogma DynamicDogma(long item_id, int type_id) => Mapper.Map<Dogma>(AsyncHelper.RunSync(() => Esi.Dogma.DynamicItem(type_id, item_id)).Data);

        private Type Type(int type_id) => Mapper.Map<Type>(AsyncHelper.RunSync(() => Esi.Universe.Type(type_id)).Data);
        
        #endregion
    }
}
