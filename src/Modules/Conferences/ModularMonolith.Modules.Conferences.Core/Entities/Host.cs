namespace ModularMonolith.Modules.Conferences.Core.Entities;

public class Host
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}