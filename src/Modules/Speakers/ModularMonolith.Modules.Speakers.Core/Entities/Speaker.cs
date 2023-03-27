namespace ModularMonolith.Modules.Speakers.Core.Entities;

public class Speaker
{
    public Guid Id { get; set; }
    public string Email { get; set; } = String.Empty;
    public string FullName { get; set; } = String.Empty;
    public string Bio { get; set; } = String.Empty;
    public string AvatarUrl { get; set; } = String.Empty;
}