using AutoMapper;
using CMCS.Nodes.Configurations.AutoMapper;
using CMCS.Nodes.Contract;
using CMCS.Nodes.DbContext;
using CMCS.Nodes.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMCS.Nodes;

public static class Registration
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<NodeDbContext>(
            (s, b) =>
                b.UseNpgsql(configuration.GetConnectionString("NodesDb")));
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<INodeService, NodeService>();
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new NodesProfile());
        });
        
        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}