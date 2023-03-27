using ModularMonolith.Shared.Abstractions.Exceptions;

namespace ModularMonolith.Modules.Speakers.Core.Exceptions;

internal class SpeakerNotFoundException : CustomException
{
    public Guid SpeakerId { get; }

    public SpeakerNotFoundException(Guid speakerId) : base($"Speaker with ID: {speakerId} was not found.")
    {
        SpeakerId = speakerId;
    }
}