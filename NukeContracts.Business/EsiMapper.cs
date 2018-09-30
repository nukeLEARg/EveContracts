using AutoMapper;
using NukeContracts.Business.Models.Contracts;
using ESIContract = ESI.NET.Models.Contracts.Contract;

namespace NukeContracts.Business
{
    internal static class EsiMapper
    {
        public static IMapper Mapper
        {
            get
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ESIContract, Contract>();
                });
                return config.CreateMapper();
            }
        }
    }
}
