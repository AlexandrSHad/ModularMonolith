using ModularMonolith.Modules.Speakers.Core.Entities;

namespace ModularMonolith.Modules.Speakers.Core.DAL.Repositories;

public interface ISpeakerRepository
{
    Task<bool> ExistsAsync(Guid id);
    Task<Speaker?> GetAsync(Guid id);
    Task<IReadOnlyList<Speaker>> BrowseAsync();
    Task CreateAsync(Speaker speaker);
    Task UpdateAsync(Speaker speaker);
}