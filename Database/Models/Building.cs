using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Database.Models;

public class Building
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Address { get; set; }

    [Required]
    [MaxLength(30)]
    public required string Type { get; set; }

    [Range(0, 100)]
    public int GarageSpaces { get; set; } = 0;

    [Range(0, 8000)]
    public int CharacterLevelRequirement { get; set; } = 0;

    public int Price { get; set; }

    // Navigation Properties
    // The player characters that own this building
    public List<PlayerCharacter> ?Owners { get; set; }

    [ForeignKey(nameof(Owners))]
    public int OwnerId { get; set; }
}
