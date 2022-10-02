using CMCS.MinerTasks.Contract;
using CMCS.MinerTasks.Contract.Models.Commands.MinerTasks;

namespace CMCS.MinerTasks.Client;

public partial class MinerTaskServiceClient : IMinerTaskService
{
    public async Task<MinerTask> Get(GetMinerTaskCommand command, CancellationToken token)
    {
        return await GetAsync(command.Id, token)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<MinerTask>> GetAll(CancellationToken token)
    {
        return await GetAllAsync(token)
            .ConfigureAwait(false);
    }

    public async Task<MinerTask> GetCurrent(CancellationToken token)
    {
        return await GetCurrentAsync(token)
            .ConfigureAwait(false);
    }

    public Task<MinerTask> Create(CreateMinerTaskCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}