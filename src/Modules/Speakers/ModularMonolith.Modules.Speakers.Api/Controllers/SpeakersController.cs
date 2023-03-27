using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Modules.Speakers.Core.DTO;
using ModularMonolith.Modules.Speakers.Core.Services;

namespace ModularMonolith.Modules.Speakers.Api.Controllers;

public class SpeakersController : BaseController
{
    private readonly ISpeakerService _speakerService;

    public SpeakersController(ISpeakerService speakerService)
    {
        _speakerService = speakerService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IReadOnlyList<SpeakerDto>>> GetAsync(Guid id)
    {
        var speaker = await _speakerService.GetAsync(id);

        if (speaker is null)
        {
            return NotFound();
        }

        return Ok(speaker);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<SpeakerDto>>> BrowseAsync()
        => Ok(await _speakerService.BrowseAsync());

    [HttpPost]
    public async Task<ActionResult> AddAsync(SpeakerDto dto)
    {
        await _speakerService.CreateAsync(dto);

        return CreatedAtAction("Get", new { Id = dto.Id }, null);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, SpeakerDto dto)
    {
        dto.Id = id;
        await _speakerService.UpdateAsync(dto);
        return NoContent();
    }
}