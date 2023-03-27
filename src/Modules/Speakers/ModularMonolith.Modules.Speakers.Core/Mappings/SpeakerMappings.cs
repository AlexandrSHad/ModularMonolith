using ModularMonolith.Modules.Speakers.Core.DTO;
using ModularMonolith.Modules.Speakers.Core.Entities;

namespace ModularMonolith.Modules.Speakers.Core.Mappings;

internal static class SpeakerMappings
{
    public static SpeakerDto AsDto(this Speaker speaker)
    {
        var dto = new SpeakerDto
        {
            Id = speaker.Id,
            Email = speaker.Email,
            FullName = speaker.FullName,
            Bio = speaker.Bio,
            AvatarUrl = speaker.AvatarUrl
        };
        return dto;
    }

    public static Speaker AsEntity(this SpeakerDto speakerDto)
    {
        var entity = new Speaker
        {
            Id = speakerDto.Id,
            Email = speakerDto.Email,
            FullName = speakerDto.FullName,
            Bio = speakerDto.Bio,
            AvatarUrl = speakerDto.AvatarUrl
        };
        return entity;
    }
}