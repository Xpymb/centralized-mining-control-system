using Microsoft.EntityFrameworkCore;

namespace CMCS.Coins.DbContext;

public class CoinsDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public CoinsDbContext(DbContextOptions<CoinsDbContext> options) : base(options)
    {
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildCoinRow(modelBuilder);
    }
    
    private void BuildCoinRow(ModelBuilder modelBuilder)
    {
    }
}