using AutoMapper;
using NukeContracts.Business.Models.Contracts;
using ESIContract = ESI.NET.Models.Contracts.Contract;
using ESIContractItem = ESI.NET.Models.Contracts.ContractItem;

namespace NukeContracts.Business
{
    internal class EsiProfile : Profile
    {
        public EsiProfile()
        {
            CreateMap<ESIContract, Contract>();
            CreateMap<ESIContractItem, ContractItem>();
        }
    }
}
