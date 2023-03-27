namespace ModularMonolith.Shared.Infrastructure.Modules;

public interface IModuleRegistry
{
    void AddBroadCastRegistration(ModuleBroadcastRegistration registration);
    IEnumerable<ModuleBroadcastRegistration> GetBroadCastRegistration(string key);
}