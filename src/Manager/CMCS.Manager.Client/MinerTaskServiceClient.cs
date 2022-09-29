using CMCS.Manager.Contract;

namespace CMCS.Manager.Client;

public partial class MinerTaskServiceClient : IMinerTaskService
{
    public async Task<MinerTask> Get(GetMinerTaskCommand command, CancellationToken token)
    {
        return await GetAsync(command.Id, token)
            .ConfigureAwait(false);
    }
    
    public async Task<MinerTask> Update(UpdateMinerTaskCommand command, CancellationToken token)
    {
        return await UpdateAsync(command, token)
            .ConfigureAwait(false);
    }
}