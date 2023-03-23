using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Conferences.Core.DAL.EF;
using ModularMonolith.Modules.Conferences.Core.Repositories;
using ModularMonolith.Shared.Infrastructure.Sqlite;

namespace ModularMonolith.Modules.Conferences.Core.DAL;

internal static class Extensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddSqlite<ConferencesDbContext>();
        services.AddScoped<IConferenceRepository, ConferenceDatabaseRepository>();
        services.AddScoped<IHostRepository, HostDatabaseRepository>();
        
        return services;
    }
}