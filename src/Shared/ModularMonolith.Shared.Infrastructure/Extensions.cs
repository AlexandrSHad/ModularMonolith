using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Shared.Infrastructure.Events;
using ModularMonolith.Shared.Infrastructure.Exceptions;
using ModularMonolith.Shared.Infrastructure.Messaging;
using ModularMonolith.Shared.Infrastructure.Modules;
using ModularMonolith.Shared.Infrastructure.Sqlite;

namespace ModularMonolith.Shared.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ErrorHandlerMiddleware>();
        services.AddSqlite();
        services.AddEvents();
        services.AddMessaging();
        services.AddModuleRequests();
            
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
        
        return app;
    }

    public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var section = configuration.GetSection(sectionName);
        var options = new T();
        section.Bind(options);

        return options;

        // I would use this approach:
        //
        // public sealed class SqliteOptions
        // {
        //     private IConfiguration _configuration;
        //
        //     public SqliteOptions(IConfiguration configuration)
        //     {
        //         _configuration = configuration;
        //     }
        //
        //     ...
        // }
    }
}