using AutoMapper;
using CMCS.MinerTasks.Contract.Models.MinerTasks;
using CMCS.MinerTasks.DbContext.Entities;
using CMCS.Shared.Core.Models;
using CMCS.Shared.Extensions.EnumExtensions;

namespace CMCS.MinerTasks.Configurations.AutoMapper;

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