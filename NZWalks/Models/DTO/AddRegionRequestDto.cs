using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTO;

public class AddRegionRequestDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(3)]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string? RegionImageUrl { get; set; }
}
