namespace CMCS.Manager.Contract.Models.Commands.Nodes;

public record UpdateNodeCommand(
    Guid Id,
    MiningStatus MiningStatus,
    MinerType? CurrentMiner = null,
    decimal CurrentHashrate = 0,
    decimal CurrentTemperature = 0);