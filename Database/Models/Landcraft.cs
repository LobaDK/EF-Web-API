using System.ComponentModel.DataAnnotations;

namespace Database.Models;

public class Landcraft : Vehicle
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
