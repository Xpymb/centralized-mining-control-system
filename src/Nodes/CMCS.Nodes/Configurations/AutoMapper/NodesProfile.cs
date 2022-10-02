using AutoMapper;
using CMCS.Nodes.Contract.Models;
using CMCS.Nodes.Contract.Models.Nodes;
using CMCS.Nodes.DbContext.Entities;
using CMCS.Shared.Core.Models;
using CMCS.Shared.Extensions.EnumExtensions;

namespace CMCS.Nodes.Configurations.AutoMapper;

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
                        src.MiningStatus.ToEnum<MiningStatusType>(),
                        src.CurrentMiner.ToEnum<MinerType>(), 
                        src.CurrentHashrate, 
                        src.CurrentTemperature, 
                        src.CreatedDate, 
                        src.LastUpdateDate));
    }
}