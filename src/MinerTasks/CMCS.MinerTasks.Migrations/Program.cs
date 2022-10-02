using CMCS.MinerTasks.DbContext;
using CMCS.Shared.Core.Database;

namespace CMCS.MinerTasks.Migrations;

public class Program
{
    public static async Task Main(string[] args)
    {
        var cancellationToken = new CancellationToken();
        var service = new DatabaseMigrationService<MinerTaskDbContext>();

        await service.Migrate(
                args,
                new DesignTimeDbContextFactory(),
                cancellationToken)
            .ConfigureAwait(false);
    }
}