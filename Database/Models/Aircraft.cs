using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

public class Aircraft : Vehicle
{
    [Range(0, 100000)]
    public int MaxAltitude { get; set; }  // The maximum altitude the aircraft can reach

    [Required]
    [MaxLength(20)]
    public required string Size { get; set; }  // The size class of the aircraft

    public int ?ExtraAbilities { get; set; }  // Bitwise flags for extra abilities
}
