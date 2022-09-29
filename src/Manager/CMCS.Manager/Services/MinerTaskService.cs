using AutoMapper;
using CMCS.Manager.Context;
using CMCS.Manager.Contract;
using CMCS.Manager.Contract.Models.Commands.Manager;
using CMCS.Manager.Contract.Models.Manager;
using Microsoft.EntityFrameworkCore;

namespace CMCS.Manager.Services;

public class MinerTaskService : IMinerTaskService
{
    private readonly ManagerDbContext _dbContext;
    private readonly IMapper _mapper;

    public MinerTaskService(
        ManagerDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<MinerTask> Get(GetMinerTaskCommand command, CancellationToken token)
    {
        var row = await _dbContext.MinerTasks
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The Miner Task with id = {command.Id} not found");
        }

        return _mapper.Map<MinerTask>(row);
    }

    public async Task<MinerTask> Update(UpdateMinerTaskCommand command, CancellationToken token)
    {
        var row = await _dbContext.MinerTasks
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The Miner Task with id = {command.Id} not found");
        }

        row.Config = command.MinerConfig.Config;
        row.Miner = command.MinerConfig.Miner.ToString();
        row.CryptoCoin = command.MinerConfig.CryptoCoin.ToString();
        row.Algorithm = command.MinerConfig.Algorithm.ToString();
        row.LastUpdateDate = DateTimeOffset.UtcNow;

        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<MinerTask>(row);
    }
}