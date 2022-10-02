namespace CMCS.MinerTasks.Contract.Models.MinerTasks;

public record MinerTask(
    Guid Id,
    MinerConfig MinerConfig,
    DateTimeOffset CreatedDate);