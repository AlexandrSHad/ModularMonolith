namespace ModularMonolith.Modules.Speakers.Core.DTO;

public class SpeakerDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = String.Empty;
    public string FullName { get; set; } = String.Empty;
    public string Bio { get; set; } = String.Empty;
    public string AvatarUrl { get; set; } = String.Empty;
}