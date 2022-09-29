using CMCS.Manager.Contract;
using CMCS.Manager.Contract.Models.Commands.MinerTask;
using CMCS.Manager.Contract.Models.MinerTask;

namespace CMCS.Manager.Client;

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