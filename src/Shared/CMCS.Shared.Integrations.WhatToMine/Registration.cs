using CMCS.Shared.Integrations.WhatToMine.Client;
using Microsoft.Extensions.DependencyInjection;

namespace CMCS.Shared.Integrations.WhatToMine;

public static class Registration
{
    public static void AddWhatToMine(this IServiceCollection services)
    {
        services.AddHttpClient<IWhatToMineClient, WhatToMineClient>(
                c => c.BaseAddress = new Uri("https://whattomine.com/"));
    }
}