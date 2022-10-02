using CMCS.Nodes.DbContext;
using CMCS.Shared.Core.Database;

namespace CMCS.Nodes.Migrations;

public class Program
{
    public static async Task Main(string[] args)
    {
        var cancellationToken = new CancellationToken();
        var service = new DatabaseMigrationService<NodeDbContext>();

        await service.Migrate(
                args,
                new DesignTimeDbContextFactory(),
                cancellationToken)
            .ConfigureAwait(false);
    }
}