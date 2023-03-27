using Microsoft.Extensions.Logging;
using ModularMonolith.Shared.Abstractions.Events;

namespace ModularMonolith.Modules.Tickets.Core.Events.External.Handlers;

internal class ConferenceCreatedHandler : IEventHandler<ConferenceCreated>
{
    private readonly ILogger<ConferenceCreatedHandler> _logger;

    public ConferenceCreatedHandler(ILogger<ConferenceCreatedHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(ConferenceCreated @event)
    {
        _logger.LogInformation("Received event about conference created with Id: {Id}", @event.Id);
        return Task.CompletedTask;
    }
}