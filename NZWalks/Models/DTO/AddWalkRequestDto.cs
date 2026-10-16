using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTO;

public class AddWalkRequestDto
{
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    public string Name { get; set; }
    public string Description { get; set; }

    [Required]
    [Range(0, 50)]
    public double LengthInKm { get; set; }
    public string? WalkImageUrl { get; set; }
    public Guid DifficultyId { get; set; }
    public Guid RegionId { get; set; }
}
