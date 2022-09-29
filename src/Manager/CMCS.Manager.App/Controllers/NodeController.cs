using CMCS.Manager.Contract;
using CMCS.Manager.Contract.Models.Commands.Nodes;
using CMCS.Manager.Contract.Models.Nodes;
using CMCS.Shared.Extensions.Api;
using Microsoft.AspNetCore.Mvc;

namespace CMCS.Manager.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NodeController : ControllerBase
{
    private readonly INodeService _nodeService;

    public NodeController(INodeService nodeService)
    {
        _nodeService = nodeService;
    }
    
    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Node>> Get(
        [FromQuery] GetNodeCommand command,
        CancellationToken token = default)
    {
        var result = await _nodeService
            .Get(command, token)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Node>> Create(
        [FromBody] CreateNodeCommand command,
        CancellationToken token = default)
    {
        var result = await _nodeService
            .Create(command, token)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Node>> Update(
        [FromBody] UpdateNodeCommand command,
        CancellationToken token = default)
    {
        var result = await _nodeService
            .Update(command, token)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(
        [FromQuery] DeleteNodeCommand command,
        CancellationToken token = default)
    {
        await _nodeService
            .Delete(command, token)
            .ConfigureAwait(false);

        return NoContent();
    }
}