using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CMCS.Shared.Core.Contracts.Collections;

public interface IDatabaseMigrationService<in TContext>
    where TContext : DbContext
{
    Task Migrate(
        string[] args,
        IDesignTimeDbContextFactory<TContext> factory,
        CancellationToken cancellationToken = default);
}