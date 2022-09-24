using CMCS.Manager.Contract.Models.Commands.Nodes;
using CMCS.Manager.Contract.Models.Nodes;

namespace CMCS.Manager.Contract;

public interface INodeService
{
    Task<Node> Get(GetNodeCommand command, CancellationToken token);
    Task<Node> Create(CreateNodeCommand command, CancellationToken token);
    Task<Node> Update(UpdateNodeCommand command, CancellationToken token);
    Task Delete(DeleteNodeCommand command, CancellationToken token);
}