using AutoMapper;
using CMCS.Manager.Context.Entities;
using CMCS.Manager.Contract.Models;
using CMCS.Manager.Contract.Models.Manager;
using CMCS.Shared.Extensions.EnumExtensions;

namespace CMCS.Manager.Configuration.AutoMapper;

public class MinerTaskProfile : Profile
{
    public MinerTaskProfile()
    {
        CreateMap<MinerTaskRow, MinerTask>()
            .ForMember(
                dest => dest.MinerConfig,
                opt => opt.MapFrom(src => 
                        new MinerConfig(
                            src.Config, 
                            src.Miner.ToEnum<MinerType>(), 
                            src.CryptoCoin.ToEnum<CryptoCoinType>(), 
                            src.Algorithm.ToEnum<AlgorithmType>())));
    }
}