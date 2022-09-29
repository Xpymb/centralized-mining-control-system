namespace CMCS.Manager.Contract.Models.Manager;

public record MinerTask(
    Guid Id,
    MinerConfig MinerConfig,
    DateTimeOffset CreatedDate,
    DateTimeOffset LastUpdateDate);