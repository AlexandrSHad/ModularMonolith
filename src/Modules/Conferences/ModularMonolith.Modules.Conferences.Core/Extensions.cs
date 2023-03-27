using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Conferences.Core.DAL;
using ModularMonolith.Modules.Conferences.Core.Services;

[assembly:InternalsVisibleTo("ModularMonolith.Modules.Conferences.Api")]
namespace ModularMonolith.Modules.Conferences.Core;

internal static class Extensions
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