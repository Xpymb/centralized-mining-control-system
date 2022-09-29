namespace CMCS.Manager.Contract.Models.MinerTask;

public record MinerTask(
    Guid Id,
    MinerConfig MinerConfig,
    DateTimeOffset CreatedDate);