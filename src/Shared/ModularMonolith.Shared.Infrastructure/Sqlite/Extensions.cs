using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ModularMonolith.Shared.Infrastructure.Sqlite;

public static class Extensions
{
    internal static IServiceCollection AddSqlite(this IServiceCollection services)
    {
        var options = services.GetOptions<SqliteOptions>("sqlite");
        services.AddSingleton(options);
        
        return services;
    }

    public static IServiceCollection AddSqlite<T>(this IServiceCollection services) where T : DbContext
    {
        var options = services.GetOptions<SqliteOptions>("sqlite");
        services.AddDbContext<T>(x => x.UseSqlite(options.ConnectionString));

        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<T>();
        dbContext.Database.Migrate();
        
        return services;
    }
}