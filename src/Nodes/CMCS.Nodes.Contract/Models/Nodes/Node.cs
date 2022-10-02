using CMCS.Shared.Core.Models;

namespace CMCS.Nodes.Contract.Models.Nodes;

public record Node(
    Guid Id,
    string Name,
    MiningStatusType StatusType,
    MinerType CurrentMiner,
    decimal CurrentHashrate,
    decimal CurrentTemperature,
    DateTimeOffset CreatedDate,
    DateTimeOffset LastUpdateDate);