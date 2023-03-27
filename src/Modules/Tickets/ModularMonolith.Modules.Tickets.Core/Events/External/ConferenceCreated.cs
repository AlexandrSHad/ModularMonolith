using ModularMonolith.Shared.Abstractions.Events;

namespace ModularMonolith.Modules.Tickets.Core.Events.External;

public record ConferenceCreated(
    Guid Id,
    string Name,
    int? ParticipantsLimit) : IEvent;