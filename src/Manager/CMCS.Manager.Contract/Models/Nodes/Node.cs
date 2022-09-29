using CMCS.Shared.Models;

namespace CMCS.Manager.Contract.Models.Nodes;

public record Node(
    Guid Id,
    string Name,
    MiningStatus Status,
    MinerType CurrentMiner,
    decimal CurrentHashrate,
    decimal CurrentTemperature,
    DateTimeOffset CreatedDate,
    DateTimeOffset LastUpdateDate);