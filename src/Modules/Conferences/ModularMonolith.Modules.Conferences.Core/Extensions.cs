using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Conferences.Core.DAL;
using ModularMonolith.Modules.Conferences.Core.DAL.Repositories;
using ModularMonolith.Modules.Conferences.Core.Repositories;
using ModularMonolith.Modules.Conferences.Core.Services;
using ModularMonolith.Shared.Infrastructure.Sqlite;

namespace ModularMonolith.Modules.Conferences.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IConferenceService, ConferenceService>();
        services.AddScoped<IHostService, HostService>();
        // services.AddSingleton<IConferenceRepository, InMemoryConferenceRepository>();
        // services.AddSingleton<IHostRepository, InMemoryHostRepository>();

        services.AddDatabase();
        
        return services;
    } 
}