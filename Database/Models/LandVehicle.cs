using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

public class LandVehicle
{
    public int Id { get; set; }

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


    // Navigation Properties
    // The vehicle that this land vehicle is based on
    [Required]
    public required Vehicle Vehicle { get; set; }

    [ForeignKey(nameof(Vehicle))]
    public int VehicleId { get; set; }
}
