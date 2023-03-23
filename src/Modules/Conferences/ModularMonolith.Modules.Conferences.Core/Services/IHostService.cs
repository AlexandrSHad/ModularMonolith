using ModularMonolith.Modules.Conferences.Core.DTO;

namespace ModularMonolith.Modules.Conferences.Core.Services;

public interface IHostService
{
    Task AddAsync(HostDetailsDto dto);
    Task<HostDetailsDto?> GetAsync(Guid id);
    Task<IReadOnlyList<HostDto>> BrowseAsync();
    Task UpdateAsync(HostDetailsDto dto);
    Task DeleteAsync(Guid id);
}
