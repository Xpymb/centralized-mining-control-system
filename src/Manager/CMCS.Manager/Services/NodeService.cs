using AutoMapper;
using CMCS.Manager.Context;
using CMCS.Manager.Context.Entities;
using CMCS.Manager.Contract;
using CMCS.Manager.Contract.Models;
using CMCS.Manager.Contract.Models.Commands.Nodes;
using CMCS.Manager.Contract.Models.Nodes;
using Microsoft.EntityFrameworkCore;

namespace CMCS.Manager.Services;

public class NodeService : INodeService
{
    private readonly ManagerDbContext _dbContext;
    private readonly IMapper _mapper;

    public NodeService(
        ManagerDbContext dbContext,
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

    public async Task<Node> Create(CreateNodeCommand command, CancellationToken token)
    {
        var row = new NodeRow(
            Guid.NewGuid(),
            command.Name,
            MiningStatus.Stopped.ToString(),
            MinerType.None.ToString(),
            decimal.Zero, 
            decimal.Zero,
            DateTimeOffset.Now);

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
        row.LastUpdateDate = DateTimeOffset.Now;

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
    }
}