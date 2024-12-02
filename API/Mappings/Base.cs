using System;
using System.ComponentModel.DataAnnotations;

namespace API.Mappings;

/// <summary>
/// Base class for all entities that can be owned and used by a player character. Includes CharacterLevelRequirement and Price properties.
/// </summary>
public class Base
{
    [Range(0, 8000, ErrorMessage = "The character level requirement must be between 0 and 8000.")]
    public int CharacterLevelRequirement { get; set; } = 0;

    [Required]
    public required int Price { get; set; }
}
