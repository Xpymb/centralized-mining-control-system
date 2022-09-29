using CMCS.Manager.Contract;
using CMCS.Manager.Contract.Models.Commands.MinerTask;
using CMCS.Manager.Contract.Models.MinerTask;
using CMCS.Shared.Extensions.Api;
using Microsoft.AspNetCore.Mvc;

namespace CMCS.Manager.App.Controllers;

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