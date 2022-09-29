using CMCS.Shared.Core.Contracts.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CMCS.Shared.Core.Database;

public class DatabaseMigrationService<TContext> : IDatabaseMigrationService<TContext>
    where TContext : DbContext
{
    public async Task Migrate(
        string[] args,
        IDesignTimeDbContextFactory<TContext> factory,
        CancellationToken cancellationToken = default)
    {
        var dbContext = factory.CreateDbContext(args);

        var pending = await dbContext.Database
            .GetPendingMigrationsAsync(cancellationToken)
            .ConfigureAwait(false);

        Console.WriteLine($"Pending migrations on {dbContext.GetType().Name} ({dbContext.Database.ProviderName}):");

        foreach (var m in pending)
        {
            Console.WriteLine($"{m}");
        }

        Console.WriteLine("Migrate...");

        await dbContext.Database
            .MigrateAsync(cancellationToken)
            .ConfigureAwait(false);

        Console.WriteLine("Migration done.");
    }
}