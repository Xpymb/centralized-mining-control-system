using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMCS.Manager;

public static class Registration
{
    public static void AddManagerDb(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddDbContextPool<ManagerDbContext>(
        //     (s, b) =>
        //         b.UseNpgsql(configuration.GetConnectionString("ManagerDb")));
    }
    
    public static void AddServices(this IServiceCollection services)
    {
    }

    public static void AddJobs(this IServiceCollection services)
    {
        
    }
}