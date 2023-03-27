using Microsoft.Extensions.Logging;
using ModularMonolith.Modules.Conferences.Core.DTO;
using ModularMonolith.Modules.Conferences.Core.Entities;
using ModularMonolith.Modules.Conferences.Core.Events;
using ModularMonolith.Modules.Conferences.Core.Exceptions;
using ModularMonolith.Modules.Conferences.Core.Repositories;
using ModularMonolith.Shared.Abstractions.Messaging;

namespace ModularMonolith.Modules.Conferences.Core.Services;

internal class ConferenceService : IConferenceService
{
    private readonly IConferenceRepository _conferenceRepository;
    private readonly IHostRepository _hostRepository;
    private readonly IMessageBroker _messageBroker;
    private readonly ILogger<ConferenceService> _logger;

    public ConferenceService(
        IConferenceRepository conferenceRepository,
        IHostRepository hostRepository,
        IMessageBroker messageBroker,
        ILogger<ConferenceService> logger)
    {
        _conferenceRepository = conferenceRepository;
        _hostRepository = hostRepository;
        _messageBroker = messageBroker;
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

        var conference = new Conference();
        Map(conference, dto);
        await _conferenceRepository.AddAsync(conference);

        await _messageBroker.PublishAsync(new ConferenceCreated(dto.Id, dto.Name, dto.ParticipantsLimit));

        _logger.LogInformation(
            "Created a conference {Name} with ID '{Id}'", dto.Name, dto.Id);
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

        Map(conference, dto);
        await _conferenceRepository.UpdateAsync(conference);
        
        _logger.LogInformation(
            "Updated a conference {Name} with ID '{Id}'", dto.Id);
    }

    public async Task DeleteAsync(Guid id)
    {
        var conference = await GetConferenceAsync(id);

        await _conferenceRepository.DeleteAsync(conference);
        
        _logger.LogInformation(
            "Deleted a conference {Name} with ID '{Id}'", conference.Name, conference.Id);
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

    private static void Map(Conference conference, ConferenceDetailsDto dto)
    {
        conference.Id = dto.Id;
        conference.HostId = dto.HostId;
        conference.Name = dto.Name;
        conference.Description = dto.Description;
        conference.Location = dto.Location;
        conference.From = dto.From;
        conference.To = dto.To;
        conference.ParticipantsLimit = dto.ParticipantsLimit;
    }

    private static T Map<T>(Conference conference) where T : ConferenceDto, new()
        => new T()
        {
            Id = conference.Id,
            HostId = conference.HostId,
            Name = conference.Name,
            Location = conference.Location,
            From = conference.From,
            To = conference.To,
            ParticipantsLimit = conference.ParticipantsLimit
        };

    private static ConferenceDetailsDto MapDetails(Conference conference)
    {
        var dto = Map<ConferenceDetailsDto>(conference);
        dto.Description = conference.Description;

        return dto;
    }
}