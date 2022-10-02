using CMCS.MinerTasks.Contract;
using CMCS.MinerTasks.Contract.Models.Commands.MinerTasks;
using CMCS.MinerTasks.Contract.Models.MinerTasks;
using CMCS.Shared.Extensions.Api;
using Microsoft.AspNetCore.Mvc;

namespace CMCS.MinerTasks.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MinerTaskController : ControllerBase
{
    private readonly IMinerTaskService _minerTaskService;

    public MinerTaskController(IMinerTaskService minerTaskService)
    {
        _minerTaskService = minerTaskService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MinerTask>> Get(
        [FromQuery] GetMinerTaskCommand command,
        CancellationToken token = default)
    {
        var result = await _minerTaskService
            .Get(command, token)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }
    
    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MinerTask>>> GetAll(
        CancellationToken token = default)
    {
        var result = await _minerTaskService
            .GetAll(token)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }
    
    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MinerTask>> GetCurrent(
        CancellationToken token = default)
    {
        var result = await _minerTaskService
            .GetCurrent(token)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }
}