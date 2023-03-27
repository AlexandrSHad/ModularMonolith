using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Shared.Abstractions.Events;
using ModularMonolith.Shared.Abstractions.Modules;
using ModularMonolith.Shared.Infrastructure.Events;

namespace ModularMonolith.Shared.Infrastructure.Modules;

internal static class Extensions
{
    public static IServiceCollection AddModuleRequests(this IServiceCollection services)
    {
        services.AddModuleRegistry();
        services.AddSingleton<IModuleClient, ModuleClient>();
        
        return services;
    }

    private static IServiceCollection AddModuleRegistry(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain
            .GetAssemblies()
            .Where(x => x.FullName!.StartsWith("ModularMonolith.Modules"));

        var eventTypes = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass && x.IsAssignableTo(typeof(IEvent)))
            .ToArray();

        services.AddSingleton<IModuleRegistry>(sp =>
        {
            var registry = new ModuleRegistry();
            var eventDispatcher = sp.GetRequiredService<IEventDispatcher>();

            foreach (var eventType in eventTypes)
            {   
                var targetType = eventType;

                var registration = new ModuleBroadcastRegistration(eventType, Handle);
                registry.AddBroadCastRegistration(registration);

                Task Handle(object @event) =>
                    (Task)eventDispatcher.GetType()
                        .GetMethod(nameof(EventDispatcher.PublishAsync))
                        ?.MakeGenericMethod(targetType)
                        .Invoke(eventDispatcher, new[] { @event })!;
            }

            return registry;
        });
        
        return services;
    }
}