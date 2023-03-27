using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo("ModularMonolith.Modules.Tickets.Api")]
namespace ModularMonolith.Modules.Tickets.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
        => services;
}