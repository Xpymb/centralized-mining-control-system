using AutoMapper;
using CMCS.MinerTasks.Configurations.AutoMapper;
using CMCS.MinerTasks.Contract;
using CMCS.MinerTasks.DbContext;
using CMCS.MinerTasks.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMCS.MinerTasks;

public static class Registration
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<MinerTaskDbContext>(
            (s, b) =>
                b.UseNpgsql(configuration.GetConnectionString("MinerTasksDb")));
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMinerTaskService, MinerTaskService>();
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MinerTaskProfile());
        });
        
        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}