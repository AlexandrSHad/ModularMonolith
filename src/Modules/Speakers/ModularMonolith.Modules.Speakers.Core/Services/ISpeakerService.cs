using ModularMonolith.Modules.Speakers.Core.DTO;

namespace ModularMonolith.Modules.Speakers.Core.Services;

public interface ISpeakerService
{
    Task CreateAsync(SpeakerDto dto);
    Task<SpeakerDto?> GetAsync(Guid id);
    Task<IReadOnlyList<SpeakerDto>> BrowseAsync();
    Task UpdateAsync(SpeakerDto dto);
}