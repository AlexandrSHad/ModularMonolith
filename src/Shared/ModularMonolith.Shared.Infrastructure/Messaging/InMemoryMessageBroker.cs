using ModularMonolith.Shared.Abstractions.Messaging;
using ModularMonolith.Shared.Abstractions.Modules;

namespace ModularMonolith.Shared.Infrastructure.Messaging;

internal sealed class InMemoryMessageBroker : IMessageBroker
{
    private readonly IModuleClient _moduleClient;

    public InMemoryMessageBroker(IModuleClient moduleClient)
    {
        _moduleClient = moduleClient;
    }

    public async Task PublishAsync(params IMessage[] messages)
    {
        messages = messages.Where(x => x is not null).ToArray();

        if (!messages.Any())
        {
            return;
        }
        
        var tasks = messages.Select(x => _moduleClient.PublishAsync(x));
        await Task.WhenAll(tasks);
    }
}