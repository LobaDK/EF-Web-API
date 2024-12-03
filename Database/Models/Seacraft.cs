using System.ComponentModel.DataAnnotations;

namespace Database.Models;

public class Seacraft : Vehicle
{
    [Required]
    public required string Size { get; set; }  // The size class of the seacraft

    [Required]
    public float RudderTurnCircle { get; set; }  // The radius of the smallest circle the seacraft can turn in
}
