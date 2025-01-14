using System.ComponentModel.DataAnnotations;
using Database.DTO;
using Database.Enums;
using Database.Models;

namespace API.Mappings;

public class ClothingCreateRequest : Base
{
    [Required(ErrorMessage = "A name for the clothing is required.")]
    [MaxLength(50, ErrorMessage = "The clothing name cannot be longer than 50 characters.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "A color for the clothing is required.")]
    [MaxLength(20, ErrorMessage = "The clothing color cannot be longer than 20 characters.")]
    public required string Color { get; set; }

    [Required(ErrorMessage = "A type for the clothing is required.")]
    [MaxLength(20, ErrorMessage = "The clothing type cannot be longer than 20 characters.")]
    public required ClothingType Type { get; set; }

    [Required(ErrorMessage = "A gender is required to be specified for the clothing.")]
    public required string Gender { get; set; }
}

public class ClothingUpdateRequest : ClothingCreateRequest
{
}

public class ClothingPurchaseResponse
{
    /// <summary>
    /// The clothing that was purchased.
    /// </summary>
    public required ClothingDto Clothing { get; set; }

    /// <summary>
    /// The character that purchased the clothing.
    /// </summary>
    public required PlayerCharacterDto Character { get; set; }
}
