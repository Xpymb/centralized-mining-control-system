using CMCS.Manager.Contract.Models.Commands.MinerTask;
using CMCS.Manager.Contract.Models.MinerTask;

namespace CMCS.Manager.Contract;

public interface IMinerTaskService
{
    Task<MinerTask> Get(GetMinerTaskCommand command, CancellationToken token);
    Task<IEnumerable<MinerTask>> GetAll(CancellationToken token);
    Task<MinerTask> GetCurrent(CancellationToken token);
    Task<MinerTask> Create(CreateMinerTaskCommand command, CancellationToken token);
}