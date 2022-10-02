using CMCS.Nodes.Contract.Models.Commands.Nodes;
using CMCS.Nodes.Contract.Models.Nodes;

namespace CMCS.Nodes.Contract;

public interface INodeService
{
    Task<Node> Get(GetNodeCommand command, CancellationToken token);
    Task<IEnumerable<Node>> GetAll(CancellationToken token);
    Task<Node> Create(CreateNodeCommand command, CancellationToken token);
    Task<Node> Update(UpdateNodeCommand command, CancellationToken token);
    Task Delete(DeleteNodeCommand command, CancellationToken token);
}