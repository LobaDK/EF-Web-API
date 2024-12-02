using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

/// <summary>
/// Entity model representing a piece of clothing that can be owned and worn by a player character.
/// </summary>
public class Clothing
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(20)]
    public required string Color { get; set; }

    [Required]
    [MaxLength(20)]
    public required string Type { get; set; }

    [Required]
    [MaxLength(20)]
    public required string Gender { get; set; }

    [Range(0, 8000)]
    public int CharacterLevelRequirement { get; set; }

    public int Price { get; set; }

    // Navigation Properties
    // The player characters that own this clothing
    public List<PlayerCharacter> ?Owners { get; set; }

    [ForeignKey(nameof(Owners))]
    public int OwnerId { get; set; }
}
