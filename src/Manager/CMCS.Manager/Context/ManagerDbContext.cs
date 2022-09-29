using CMCS.Manager.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMCS.Manager.Context;

public class ManagerDbContext : DbContext
{
    public ManagerDbContext(DbContextOptions<ManagerDbContext> options) : base(options)
    {
    }
    
    public DbSet<NodeRow> Nodes { get; set; }
    public DbSet<MinerTaskRow> MinerTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildNodesRow(modelBuilder);
        BuildMinerTaskRow(modelBuilder);
    }

    private void BuildNodesRow(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<NodeRow>()
            .HasIndex(n => n.Id);
        modelBuilder
            .Entity<NodeRow>()
            .Property(n => n.Name);
        modelBuilder
            .Entity<NodeRow>()
            .Property(n => n.CurrentMiner);
        modelBuilder
            .Entity<NodeRow>()
            .Property(n => n.CurrentHashrate);
        modelBuilder
            .Entity<NodeRow>()
            .Property(n => n.CurrentTemperature);
        modelBuilder
            .Entity<NodeRow>()
            .Property(n => n.CreatedDate);
        modelBuilder
            .Entity<NodeRow>()
            .Property(n => n.LastUpdateDate);
    }
    
    private void BuildMinerTaskRow(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<MinerTaskRow>()
            .HasIndex(m => m.Id);
        modelBuilder
            .Entity<MinerTaskRow>()
            .Property(m => m.Miner);
        modelBuilder
            .Entity<MinerTaskRow>()
            .Property(m => m.Config);
        modelBuilder
            .Entity<MinerTaskRow>()
            .Property(m => m.CryptoCoin);
        modelBuilder
            .Entity<MinerTaskRow>()
            .Property(m => m.Algorithm);
        modelBuilder
            .Entity<MinerTaskRow>()
            .Property(m => m.CreatedDate);
    }
}