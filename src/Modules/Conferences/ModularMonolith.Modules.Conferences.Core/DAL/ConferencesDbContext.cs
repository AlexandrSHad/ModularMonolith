using Microsoft.EntityFrameworkCore;
using ModularMonolith.Modules.Conferences.Core.DAL.Configurations;
using ModularMonolith.Modules.Conferences.Core.Entities;

namespace ModularMonolith.Modules.Conferences.Core.DAL;

public class ConferencesDbContext : DbContext
{
    public DbSet<Conference> Conferences { get; set; }
    public DbSet<Host> Hosts { get; set; }

    public ConferencesDbContext(DbContextOptions<ConferencesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("conferences");
        // modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.ApplyConfiguration(new ConferenceConfiguration());
        modelBuilder.ApplyConfiguration(new HostConfiguration());
    }
}