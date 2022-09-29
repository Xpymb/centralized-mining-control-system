using CMCS.Manager.Contract;

namespace CMCS.Manager.Client;

public partial class NodeServiceClient : INodeService
{
    public async Task<Node> Get(GetNodeCommand command, CancellationToken token)
    {
        return await GetAsync(command.Id, token)
            .ConfigureAwait(false);
    }
    
    public async Task<Node> Create(CreateNodeCommand command, CancellationToken token)
    {
        return await CreateAsync(command, token)
            .ConfigureAwait(false);
    }
    
    public async Task<Node> Update(UpdateNodeCommand command, CancellationToken token)
    {
        return await UpdateAsync(command, token)
            .ConfigureAwait(false);
    }
    
    public async Task Delete(DeleteNodeCommand command, CancellationToken token)
    {
        await DeleteAsync(command.Id, token)
            .ConfigureAwait(false);
    }
}