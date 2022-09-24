namespace CMCS.Manager.Contract.Models.Commands.Manager;

public record UpdateMinerTaskCommand(
    Guid Id,
    MinerConfig MinerConfig);