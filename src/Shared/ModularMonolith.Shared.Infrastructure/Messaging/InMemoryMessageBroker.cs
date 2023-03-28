using ModularMonolith.Shared.Abstractions.Messaging;
using ModularMonolith.Shared.Abstractions.Modules;

namespace ModularMonolith.Shared.Infrastructure.Messaging;

internal sealed class InMemoryMessageBroker : IMessageBroker
{
    private readonly IModuleClient _moduleClient;
    private readonly IAsynchronousDispatcher _asynchronousDispatcher;
    private readonly MessagingOptions _messagingOptions;

    public InMemoryMessageBroker(
        IModuleClient moduleClient,
        IAsynchronousDispatcher asynchronousDispatcher,
        MessagingOptions messagingOptions)
    {
        _moduleClient = moduleClient;
        _asynchronousDispatcher = asynchronousDispatcher;
        _messagingOptions = messagingOptions;
    }

    public async Task PublishAsync(params IMessage[] messages)
    {
        messages = messages.Where(x => x is not null).ToArray();

        if (!messages.Any())
        {
            return;
        }
        
        var tasks = messages.Select(x => _messagingOptions.UseBackgroundDispatcher
            ? _asynchronousDispatcher.PublishAsync(x)
            : _moduleClient.PublishAsync(x));
        await Task.WhenAll(tasks);
    }
}