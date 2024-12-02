using System.ComponentModel.DataAnnotations;

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
    public required string Type { get; set; }

    [Required]
    [MaxLength(20)]
    public required string Gender { get; set; }
}
