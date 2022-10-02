using AutoMapper;
using CMCS.Coins.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMCS.Coins;

public static class Registration
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<CoinsDbContext>(
            (s, b) =>
                b.UseNpgsql(configuration.GetConnectionString("ManagerDb")));
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            // mc.AddProfile(new MinerTaskProfile());
        });
        
        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}