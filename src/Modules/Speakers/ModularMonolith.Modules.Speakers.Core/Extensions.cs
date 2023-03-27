using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Speakers.Core.DAL;
using ModularMonolith.Modules.Speakers.Core.Services;

[assembly:InternalsVisibleTo("ModularMonolith.Modules.Speakers.Api")]
namespace ModularMonolith.Modules.Speakers.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<ISpeakerService, SpeakerService>();
        services.AddDatabase();

        return services;
    }
}