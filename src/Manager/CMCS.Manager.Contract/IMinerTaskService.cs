using CMCS.Manager.Contract.Models.Commands.Manager;
using CMCS.Manager.Contract.Models.Manager;

namespace CMCS.Manager.Contract;

public interface IMinerTaskService
{
    Task<MinerTask> Get(GetMinerTaskCommand command, CancellationToken token);
    Task<MinerTask> Update(UpdateMinerTaskCommand command, CancellationToken token);
}