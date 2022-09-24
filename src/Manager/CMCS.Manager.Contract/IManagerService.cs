using CMCS.Manager.Contract.Models.Commands.Manager;
using CMCS.Manager.Contract.Models.Manager;

namespace CMCS.Manager.Contract;

public interface IManagerService
{
    Task<MinerTask> GetMinerTask(GetMinerTaskCommand command, CancellationToken token);
    Task<MinerTask> UpdateMinerTask(UpdateMinerTaskCommand command, CancellationToken token);
}