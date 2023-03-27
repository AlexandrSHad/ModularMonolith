using Microsoft.EntityFrameworkCore;
using ModularMonolith.Modules.Speakers.Core.DAL.EF;
using ModularMonolith.Modules.Speakers.Core.Entities;

namespace ModularMonolith.Modules.Speakers.Core.DAL.Repositories;

internal sealed class SpeakerDatabaseRepository : ISpeakerRepository
{
    private readonly SpeakersDbContext _context;
    private readonly DbSet<Speaker> _speakers;

    public SpeakerDatabaseRepository(SpeakersDbContext context)
    {
        _context = context;
        _speakers = context.Speakers;
    }

    public async Task<IReadOnlyList<Speaker>> BrowseAsync()
        => await _speakers.ToListAsync();

    public Task<bool> ExistsAsync(Guid id)
        => _speakers.AnyAsync(x => x.Id == id);

    public Task<Speaker?> GetAsync(Guid id)
        => _speakers.SingleOrDefaultAsync(x => x.Id == id);

    public async Task CreateAsync(Speaker speaker)
    {
        await _speakers.AddAsync(speaker);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Speaker speaker)
    {
        _speakers.Update(speaker);
        await _context.SaveChangesAsync();
    }
}