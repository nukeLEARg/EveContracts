using AutoMapper;
using NukeContracts.Business.Models;
using NukeContracts.Business.Models.Contracts;
using NukeContracts.Business.Models.Universe;
using EsiContract = ESI.NET.Models.Contracts.Contract;
using EsiContractItem = ESI.NET.Models.Contracts.ContractItem;
using EsiPosition = ESI.NET.Models.Position;
using EsiStation = ESI.NET.Models.Universe.Station;
using EsiStructure = ESI.NET.Models.Universe.Structure;

namespace NukeContracts.Business
{
    internal class EsiProfile : Profile
    {
        public EsiProfile()
        {
            CreateMap<EsiContract, Contract>();
            CreateMap<EsiContractItem, ContractItem>();
            CreateMap<EsiPosition, Position>();
            CreateMap<EsiStation, Station>();
            CreateMap<EsiStructure, Structure>();
        }
    }
}
