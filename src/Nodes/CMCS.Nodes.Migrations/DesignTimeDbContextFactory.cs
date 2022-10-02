using CMCS.Nodes.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CMCS.Nodes.Migrations;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NodeDbContext>
{
    public NodeDbContext CreateDbContext(params string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<NodeDbContext>();
        optionsBuilder.UseNpgsql(
            config.GetConnectionString("NodesDb"),
            builder => builder.MigrationsAssembly(typeof(DesignTimeDbContextFactory).Assembly.GetName().Name));

        return new NodeDbContext(optionsBuilder.Options);
    }
}