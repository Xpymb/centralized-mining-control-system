using CMCS.Nodes.DbContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMCS.Nodes.DbContext;

public class NodeDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public NodeDbContext(DbContextOptions<NodeDbContext> options) : base(options)
    {
    }
    
    public DbSet<NodeRow> Nodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildNodeRow(modelBuilder);
    }
    
    private void BuildNodeRow(ModelBuilder modelBuilder)
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
}