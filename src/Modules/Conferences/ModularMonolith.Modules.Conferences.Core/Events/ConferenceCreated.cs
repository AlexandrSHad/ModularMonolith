using ModularMonolith.Shared.Abstractions.Events;

namespace ModularMonolith.Modules.Conferences.Core.Events;

public record ConferenceCreated(
    Guid Id,
    string Name,
    int? ParticipantsLimit) : IEvent;