using ModularMonolith.Shared.Abstractions.Exceptions;

namespace ModularMonolith.Modules.Speakers.Core.Exceptions;

internal class SpeakerAlreadyExistsException : CustomException
{
    public Guid SpeakerId { get; }

    public SpeakerAlreadyExistsException(Guid speakerId) : base($"Speaker with Id: {speakerId} already exists.")
    {
        SpeakerId = speakerId;
    }
}