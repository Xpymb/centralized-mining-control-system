using AutoMapper;
using CMCS.Manager.Context;
using CMCS.Manager.Context.Entities;
using CMCS.Manager.Contract;
using CMCS.Manager.Contract.Models.Commands.MinerTask;
using CMCS.Manager.Contract.Models.MinerTask;
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

    public async Task<IEnumerable<MinerTask>> GetAll(CancellationToken token)
    {
        var rows = await _dbContext.MinerTasks
            .AsNoTracking()
            .ToListAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<List<MinerTask>>(rows);
    }

    public async Task<MinerTask> GetCurrent(CancellationToken token)
    {
        var row = await _dbContext.MinerTasks
            .AsNoTracking()
            .OrderByDescending(r => r.CreatedDate)
            .FirstOrDefaultAsync(token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException("No one Miner Task setted");
        }

        return _mapper.Map<MinerTask>(row);
    }

    public async Task<MinerTask> Create(CreateMinerTaskCommand command, CancellationToken token)
    {
        var row = new MinerTaskRow(
            command.MinerConfig.Config,
            command.MinerConfig.Miner.ToString(),
            command.MinerConfig.CryptoCoin.ToString(),
            command.MinerConfig.Algorithm.ToString());

        await _dbContext.MinerTasks
            .AddAsync(row, token)
            .ConfigureAwait(false);

        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<MinerTask>(row);
    }
}