using AutoMapper;
using CMCS.Manager.Context.Entities;
using CMCS.Manager.Contract.Models;
using CMCS.Manager.Contract.Models.Nodes;
using CMCS.Shared.Extensions.EnumExtensions;
using CMCS.Shared.Models;

namespace CMCS.Manager.Configuration.AutoMapper;

public class NodesProfile : Profile
{
    public NodesProfile()
    {
        CreateMap<NodeRow, Node>()
            .ForMember(dest => dest.CurrentMiner,
                opt => opt.MapFrom(src => src.CurrentMiner.ToEnum<MinerType>()));
    }
}