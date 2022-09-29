namespace CMCS.Manager.Contract.Models.Commands.MinerTask;

public record UpdateMinerTaskCommand(
    Guid Id,
    MinerConfig MinerConfig);