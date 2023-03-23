using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Modules.Conferences.Core.DTO;
using ModularMonolith.Modules.Conferences.Core.Services;

namespace ModularMonolith.Modules.Conferences.Api.Controllers;

public class ConferencesController : BaseController
{
    private readonly IConferenceService _conferenceService;

    public ConferencesController(IConferenceService conferenceService)
    {
        _conferenceService = conferenceService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IReadOnlyList<ConferenceDetailsDto>>> GetAsync(Guid id)
    {
        var conference = await _conferenceService.GetAsync(id);

        if (conference is null)
        {
            return NotFound();
        }

        return Ok(conference);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ConferenceDto>>> BrowseAsync()
        => Ok(await _conferenceService.BrowseAsync());

    [HttpPost]
    public async Task<ActionResult> AddAsync(ConferenceDetailsDto dto)
    {
        await _conferenceService.AddAsync(dto);

        return CreatedAtAction("Get", new { Id = dto.Id }, null);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, ConferenceDetailsDto dto)
    {
        dto.Id = id;
        await _conferenceService.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await _conferenceService.DeleteAsync(id);
        return NoContent();
    }
}