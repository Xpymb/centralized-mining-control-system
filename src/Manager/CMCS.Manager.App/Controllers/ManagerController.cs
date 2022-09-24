using CMCS.Manager.Contract;
using CMCS.Manager.Contract.Models.Commands.Manager;
using CMCS.Manager.Contract.Models.Manager;
using CMCS.Shared.Extensions.Api;
using Microsoft.AspNetCore.Mvc;

namespace CMCS.Manager.App.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagerController : ControllerBase
{
    private readonly IManagerService _managerService;

    public ManagerController(IManagerService managerService)
    {
        _managerService = managerService;
    }

    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MinerTask>> GetMinerTask(
        [FromQuery] GetMinerTaskCommand command,
        CancellationToken token = default)
    {
        var result = await _managerService
            .GetMinerTask(command, token)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }
    
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MinerTask>> UpdateMinerTask(
        [FromQuery] UpdateMinerTaskCommand command,
        CancellationToken token = default)
    {
        var result = await _managerService
            .UpdateMinerTask(command, token)
            .WithActionResult()
            .ConfigureAwait(false);

        return result;
    }
}