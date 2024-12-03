using System.ComponentModel.DataAnnotations;

namespace Database.DTO;

public class VehicleDto : BaseDto
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    public float TopSpeed { get; set; }

    public int MaxOccupants { get; set; }
}

public class AircraftDto : VehicleDto
{
    [Range(0, 100000)]
    public int MaxAltitude { get; set; }

    [Required]
    [MaxLength(20)]
    public required string Size { get; set; }

    public int ?ExtraAbilities { get; set; }
}

public class LandcraftDto : VehicleDto
{
    [Required]
    [MaxLength(30)]
    public required string Model { get; set; }

    [Required]
    [MaxLength(20)]
    public required string Class { get; set; }
    
    [Required]
    [Range(0, 100)]
    public required string Acceleration0To60 { get; set; }

    public bool IsElectric { get; set; }

    public int WheelCount { get; set; }
}

public class SeacraftDto : VehicleDto
{
    [Required]
    public required string Size { get; set; }  // The size class of the seacraft

    [Required]
    public float RudderTurnCircle { get; set; }  // The radius of the smallest circle the seacraft can turn in
}