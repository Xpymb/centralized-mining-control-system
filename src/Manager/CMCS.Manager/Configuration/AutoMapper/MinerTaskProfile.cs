using AutoMapper;
using CMCS.Manager.Context.Entities;
using CMCS.Manager.Contract.Models;
using CMCS.Manager.Contract.Models.MinerTask;
using CMCS.Shared.Core.Models;
using CMCS.Shared.Extensions.EnumExtensions;

namespace CMCS.Manager.Configuration.AutoMapper;

public class MinerTaskProfile : Profile
{
    public MinerTaskProfile()
    {
        CreateMap<MinerTaskRow, MinerTask>()
            .ConstructUsing(
                src =>
                    new MinerTask(
                        src.Id, 
                        new MinerConfig(
                            src.Config, 
                            src.Miner.ToEnum<MinerType>(), 
                            src.CryptoCoin.ToEnum<CryptoCoinType>(), 
                            src.Algorithm.ToEnum<AlgorithmType>()),
                        src.CreatedDate));
    }
}