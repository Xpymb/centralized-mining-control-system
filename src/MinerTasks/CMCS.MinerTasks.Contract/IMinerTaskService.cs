using CMCS.MinerTasks.Contract.Models.Commands.MinerTasks;
using CMCS.MinerTasks.Contract.Models.MinerTasks;

namespace CMCS.MinerTasks.Contract;

public interface IMinerTaskService
{
    Task<MinerTask> Get(GetMinerTaskCommand command, CancellationToken token);
    Task<IEnumerable<MinerTask>> GetAll(CancellationToken token);
    Task<MinerTask> GetCurrent(CancellationToken token);
    Task<MinerTask> Create(CreateMinerTaskCommand command, CancellationToken token);
}