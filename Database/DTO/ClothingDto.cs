using System.ComponentModel.DataAnnotations;
using Database.Enums;

namespace Database.DTO;

public class ClothingDto : BaseDto
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(20)]
    public required string Color { get; set; }

    [Required]
    [MaxLength(20)]
    public required ClothingType Type { get; set; }

    [Required]
    [MaxLength(20)]
    public required string Gender { get; set; }
}
