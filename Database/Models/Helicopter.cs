using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

public class Helicopter
{
    public int Id { get; set; }
    
    [Required]
    [Range(1, 8)]
    public int LiftRotorCount { get; set; }  // The number of lift rotors on the helicopter

    [Required]
    [Range(0, 8)]
    public int TailRotorCount { get; set; }  // The number of tail rotors on the helicopter. Some helicopters use two lift rotors and no tail rotor

    [Required]
    [MaxLength(20)]
    public required string Size { get; set; }  // The size class of the helicopter

    // Navigation Properties
    // The vehicle that this helicopter is based on
    [Required]
    public required Vehicle Vehicle { get; set; }

    [ForeignKey(nameof(Vehicle))]
    public int VehicleId { get; set; }
}
