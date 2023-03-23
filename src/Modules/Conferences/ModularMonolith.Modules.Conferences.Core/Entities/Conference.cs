namespace ModularMonolith.Modules.Conferences.Core.Entities;

public class Conference
{
    public Guid Id { get; set; }
    public Guid HostId { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string Location { get; set; } = String.Empty;
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}