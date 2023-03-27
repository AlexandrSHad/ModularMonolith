using System.ComponentModel.DataAnnotations;

namespace ModularMonolith.Modules.Conferences.Core.DTO;

public class ConferenceDto
{
    public Guid Id { get; set; }
    public Guid HostId { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = String.Empty;
    public string Location { get; set; } = String.Empty;
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public int? ParticipantsLimit { get; set; }
}