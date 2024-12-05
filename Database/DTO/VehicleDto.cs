using System.ComponentModel.DataAnnotations;
using Database.Enums;

namespace Database.DTO;

public class VehicleDto : BaseDto
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    public required VehicleTypeOrClass TypeOrClass { get; set; }

    public float TopSpeed { get; set; }

    public int MaxOccupants { get; set; }
}