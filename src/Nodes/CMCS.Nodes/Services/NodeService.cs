using AutoMapper;
using CMCS.Nodes.Contract;
using CMCS.Nodes.Contract.Models;
using CMCS.Nodes.Contract.Models.Commands.Nodes;
using CMCS.Nodes.Contract.Models.Nodes;
using CMCS.Nodes.DbContext;
using CMCS.Nodes.DbContext.Entities;
using CMCS.Shared.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CMCS.Nodes.Services;

public class NodeService : INodeService
{
    private readonly NodeDbContext _dbContext;
    private readonly IMapper _mapper;

    public NodeService(
        NodeDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<Node> Get(GetNodeCommand command, CancellationToken token)
    {
        var row = await _dbContext.Nodes
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);
        
        if (row is null)
        {
            throw new InvalidOperationException($"The Node with id = {command.Id} not found");
        }

        return _mapper.Map<Node>(row);
    }

    public async Task<IEnumerable<Node>> GetAll(CancellationToken token)
    {
        var rows = await _dbContext.Nodes
            .AsNoTracking()
            .ToListAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<List<Node>>(rows);
    }

    public async Task<Node> Create(CreateNodeCommand command, CancellationToken token)
    {
        var row = new NodeRow(
            command.Name,
            MiningStatusType.Stopped.ToString(),
            MinerType.None.ToString(),
            decimal.Zero, 
            decimal.Zero);

        await _dbContext.Nodes
            .AddAsync(row, token)
            .ConfigureAwait(false);

        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<Node>(row);
    }

    public async Task<Node> Update(UpdateNodeCommand command, CancellationToken token)
    {
        var row = await _dbContext.Nodes
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);
        
        if (row is null)
        {
            throw new InvalidOperationException($"The Node with id = {command.Id} not found");
        }

        row.MiningStatus = command.MiningStatus.ToString();
        row.CurrentMiner = command.CurrentMiner.ToString() ?? row.CurrentMiner;
        row.CurrentHashrate = command.CurrentHashrate;
        row.CurrentTemperature = command.CurrentTemperature;
        row.LastUpdateDate = DateTimeOffset.UtcNow;

        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<Node>(row);
    }

    public async Task Delete(DeleteNodeCommand command, CancellationToken token)
    {
        var row = await _dbContext.Nodes
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            return;
        }
        
        _dbContext.Nodes.Remove(row);

        await _dbContext.SaveChangesAsync(token)
            .ConfigureAwait(false);
    }
}