using AutoMapper;
using CMCS.MinerTasks.Contract;
using CMCS.MinerTasks.Contract.Models.Commands.MinerTasks;
using CMCS.MinerTasks.Contract.Models.MinerTasks;
using CMCS.MinerTasks.DbContext;
using CMCS.MinerTasks.DbContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMCS.MinerTasks.Services;

public class MinerTaskService : IMinerTaskService
{
    private readonly MinerTaskDbContext _dbContext;
    private readonly IMapper _mapper;

    public MinerTaskService(
        MinerTaskDbContext dbContext,
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