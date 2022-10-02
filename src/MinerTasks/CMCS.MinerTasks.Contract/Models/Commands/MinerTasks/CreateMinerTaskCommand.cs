using CMCS.MinerTasks.Contract.Models.MinerTasks;

namespace CMCS.MinerTasks.Contract.Models.Commands.MinerTasks;

public record CreateMinerTaskCommand(
    MinerConfig MinerConfig);