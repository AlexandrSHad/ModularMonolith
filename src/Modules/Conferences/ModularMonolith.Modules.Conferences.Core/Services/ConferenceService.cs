using Microsoft.Extensions.Logging;
using ModularMonolith.Modules.Conferences.Core.DTO;
using ModularMonolith.Modules.Conferences.Core.Entities;
using ModularMonolith.Modules.Conferences.Core.Exceptions;
using ModularMonolith.Modules.Conferences.Core.Repositories;

namespace ModularMonolith.Modules.Conferences.Core.Services;

internal class ConferenceService : IConferenceService
{
    private readonly IConferenceRepository _conferenceRepository;
    private readonly IHostRepository _hostRepository;
    private readonly ILogger<ConferenceService> _logger;

    public ConferenceService(
        IConferenceRepository conferenceRepository,
        IHostRepository hostRepository,
        ILogger<ConferenceService> logger)
    {
        _conferenceRepository = conferenceRepository;
        _hostRepository = hostRepository;
        _logger = logger;
    }

    public async Task AddAsync(ConferenceDetailsDto dto)
    {
        var host = await _hostRepository.GetAsync(dto.HostId);
        if (host is null)
        {
            throw new HostNotFoundException(dto.HostId);
        }

        dto.Id = Guid.NewGuid();

        var conference = Map(dto);
        await _conferenceRepository.AddAsync(conference);

        _logger.LogInformation(
            "Created a conference {Name} with ID '{Id}': {dto}",
            dto.Name, dto.Id, dto); // check this out
    }

    public async Task<ConferenceDetailsDto?> GetAsync(Guid id)
    {
        var conference = await _conferenceRepository.GetAsync(id);

        return conference is not null ? MapDetails(conference) : default;
    }

    public async Task<IReadOnlyList<ConferenceDto>> BrowseAsync()
    {
        var conferences = await _conferenceRepository.BrowseAsync();

        return conferences.Select(Map<ConferenceDto>).ToList();
    }

    public async Task UpdateAsync(ConferenceDetailsDto dto)
    {
        // use dedicated UpdateConferenceDto because of hostId that should not change after creation 
        var conference = await GetConferenceAsync(dto.Id);

        conference = Map(dto);
        await _conferenceRepository.UpdateAsync(conference);
        
        _logger.LogInformation(
            "Updated a conference {Name} with ID '{Id}': {dto}",
            dto.Name, dto.Id, dto); // check this out
    }

    public async Task DeleteAsync(Guid id)
    {
        var conference = await GetConferenceAsync(id);

        await _conferenceRepository.DeleteAsync(conference);
        
        _logger.LogInformation(
            "Deleted a conference {Name} with ID '{Id}': {dto}",
            conference.Name, conference.Id, conference); // check this out
    }

    private async Task<Conference> GetConferenceAsync(Guid id)
    {
        var conference = await _conferenceRepository.GetAsync(id);

        if (conference is null)
        {
            throw new ConferenceNotFoundException(id);
        }

        return conference;
    }

    private static Conference Map(ConferenceDetailsDto dto)
        => new Conference
        {
            Id = dto.Id,
            HostId = dto.HostId,
            Name = dto.Name,
            Description = dto.Description,
            Location = dto.Location,
            From = dto.From,
            To = dto.To
        };

    private static T Map<T>(Conference conference) where T : ConferenceDto, new()
        => new T()
        {
            Id = conference.Id,
            HostId = conference.HostId,
            Name = conference.Name,
            Location = conference.Location,
            From = conference.From,
            To = conference.To
        };

    private static ConferenceDetailsDto MapDetails(Conference conference)
    {
        var dto = Map<ConferenceDetailsDto>(conference);
        dto.Description = conference.Description;

        return dto;
    }
}