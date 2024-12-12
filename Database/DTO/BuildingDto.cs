using System.ComponentModel.DataAnnotations;
using Database.Enums;

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
    public required BuildingType Type { get; set; }

    [Range(0, 100)]
    public int GarageSpaces { get; set; }
}