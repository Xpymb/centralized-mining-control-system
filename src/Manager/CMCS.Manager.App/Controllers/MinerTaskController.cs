using CMCS.Manager.Contract;
using CMCS.Manager.Contract.Models.Commands.Manager;
using CMCS.Manager.Contract.Models.Manager;
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

    [HttpGet("[action]")]
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
    
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MinerTask>> Update(
        [FromQuery] UpdateMinerTaskCommand command,
        CancellationToken token = default)
    {
        var result = await _minerTaskService
            .Update(command, token)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }
}