using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Speakers.Core.DAL.EF;
using ModularMonolith.Modules.Speakers.Core.DAL.Repositories;
using ModularMonolith.Shared.Infrastructure.Sqlite;

namespace ModularMonolith.Modules.Speakers.Core.DAL;

internal static class Extensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddSqlite<SpeakersDbContext>();
        services.AddScoped<ISpeakerRepository, SpeakerDatabaseRepository>();

        return services;
    }
}