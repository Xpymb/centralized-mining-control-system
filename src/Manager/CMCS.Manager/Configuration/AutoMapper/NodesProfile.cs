using AutoMapper;
using AutoMapper.Features;
using CMCS.Manager.Context.Entities;
using CMCS.Manager.Contract.Models;
using CMCS.Manager.Contract.Models.Nodes;
using CMCS.Shared.Core.Models;
using CMCS.Shared.Extensions.EnumExtensions;

namespace CMCS.Manager.Configuration.AutoMapper;

public class NodesProfile : Profile
{
    public NodesProfile()
    {
        CreateMap<NodeRow, Node>()
            .ConstructUsing(
                src =>
                    new Node(
                        src.Id, 
                        src.Name, 
                        src.MiningStatus.ToEnum<MiningStatus>(),
                        src.CurrentMiner.ToEnum<MinerType>(), 
                        src.CurrentHashrate, 
                        src.CurrentTemperature, 
                        src.CreatedDate, 
                        src.LastUpdateDate));
    }
}