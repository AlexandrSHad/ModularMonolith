using Microsoft.EntityFrameworkCore;
using ModularMonolith.Modules.Speakers.Core.DAL.Configurations;
using ModularMonolith.Modules.Speakers.Core.Entities;

namespace ModularMonolith.Modules.Speakers.Core.DAL.EF;

public class SpeakersDbContext : DbContext
{
    public DbSet<Speaker> Speakers { get; set; }

    public SpeakersDbContext(DbContextOptions<SpeakersDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("speakers");
        
        // modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.ApplyConfiguration(new SpeakerConfiguration());
    }
}