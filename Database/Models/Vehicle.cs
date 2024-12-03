using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

public abstract class Vehicle
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    public float TopSpeed { get; set; }

    public int MaxOccupants { get; set; }

    [Range(0, 8000)]
    public int CharacterLevelRequirement { get; set; }

    public int Price { get; set; }

    // Navigation Properties
    // The player characters that own this vehicle
    public List<PlayerCharacter> ?Owners { get; set; }

    [ForeignKey(nameof(Owners))]
    public int OwnerId { get; set; }
}