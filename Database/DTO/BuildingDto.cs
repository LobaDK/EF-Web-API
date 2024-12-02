using System.ComponentModel.DataAnnotations;

namespace Database.DTO;

public class BuildingDto : BaseDto
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Address { get; set; }
    
    [Required]
    [MaxLength(30)]
    public required string Type { get; set; }

    [Range(0, 100)]
    public int GarageSpaces { get; set; }
}