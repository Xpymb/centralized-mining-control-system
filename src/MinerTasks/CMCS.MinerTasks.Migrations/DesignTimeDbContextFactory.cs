using CMCS.MinerTasks.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CMCS.MinerTasks.Migrations;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MinerTaskDbContext>
{
    public MinerTaskDbContext CreateDbContext(params string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<MinerTaskDbContext>();
        optionsBuilder.UseNpgsql(
            config.GetConnectionString("MinerTasksDb"),
            builder => builder.MigrationsAssembly(typeof(DesignTimeDbContextFactory).Assembly.GetName().Name));

        return new MinerTaskDbContext(optionsBuilder.Options);
    }
}