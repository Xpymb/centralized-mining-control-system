using CMCS.MinerTasks.DbContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMCS.MinerTasks.DbContext;

public class MinerTaskDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public MinerTaskDbContext(DbContextOptions<MinerTaskDbContext> options) : base(options)
    {
    }
    
    public DbSet<MinerTaskRow> MinerTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildMinerTaskRow(modelBuilder);
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