using CMCS.Manager.Context;
using CMCS.Shared.Core.Database;

namespace CMCS.Manager.Migrations;

public class Program
{
    public static async Task Main(string[] args)
    {
        var cancellationToken = new CancellationToken();
        var service = new DatabaseMigrationService<ManagerDbContext>();

        await service.Migrate(
                args,
                new DesignTimeDbContextFactory(),
                cancellationToken)
            .ConfigureAwait(false);
    }
}