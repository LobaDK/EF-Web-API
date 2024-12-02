using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

public class Plane
{
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public required string PropulsionTypes { get; set; }

    [Range(0, 8)]
    public int PropellerCount { get; set; }

    [Range(0, 8)]
    public int JetEngineCount { get; set; }

    [MaxLength(40)]
    public string ?ExtraAbilities { get; set; }

    [Required]
    [MaxLength(20)]
    public required string Size { get; set; }

    // Navigation Properties
    // The vehicle that this plane is based on
    [Required]
    public required Vehicle Vehicle { get; set; }

    [ForeignKey(nameof(Vehicle))]
    public int VehicleId { get; set; }
}
