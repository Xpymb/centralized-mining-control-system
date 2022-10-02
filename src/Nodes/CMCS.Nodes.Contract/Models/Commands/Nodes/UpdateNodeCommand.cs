using CMCS.Shared.Core.Models;

namespace CMCS.Nodes.Contract.Models.Commands.Nodes;

public record UpdateNodeCommand(
    Guid Id,
    MiningStatusType MiningStatus,
    MinerType? CurrentMiner = null,
    decimal CurrentHashrate = 0,
    decimal CurrentTemperature = 0);