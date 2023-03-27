namespace ModularMonolith.Shared.Infrastructure.Modules;

internal sealed class ModuleRegistry : IModuleRegistry
{
    private readonly List<ModuleBroadcastRegistration> _broadcastRegistrations = new();

    public void AddBroadCastRegistration(ModuleBroadcastRegistration registration)
    {
        ArgumentNullException.ThrowIfNull(registration);

        if (string.IsNullOrWhiteSpace(registration.TargetType.Namespace))
        {
            throw new InvalidOperationException("Missing target type namespace.");
        }
        
        _broadcastRegistrations.Add(registration);
    }

    public IEnumerable<ModuleBroadcastRegistration> GetBroadCastRegistration(string key)
        => _broadcastRegistrations.Where(x => x.Key == key);
}