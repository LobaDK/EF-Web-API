using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Database.Enums;
using Database.Models;
using Database.DTO;

namespace API.Mappings;

/// <summary>
/// Request model for creating a new building.
/// </summary>
public class BuildingCreateRequest : Base
{
    [Required(ErrorMessage = "A name for the building is required.")]
    [MaxLength(100, ErrorMessage = "The building name cannot be longer than 100 characters.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "An address for the building is required.")]
    [MaxLength(100, ErrorMessage = "The building address cannot be longer than 100 characters.")]
    public required string Address { get; set; }

    [Required]
    [EnumDataType(typeof(BuildingType), ErrorMessage = "The building type must be one of the following: Apartment, Garage, Business, Misc.")]
    [JsonConverter(typeof(StringEnumConverter))]
    public required BuildingType Type { get; set; }

    [Range(0, 100, ErrorMessage = "The number of cars that can be parked in the garage must be between 0 and 100.")]
    public int GarageSpaces { get; set; } = 0;
}

/// <summary>
/// Request model for updating an existing building. Inherits from BuildingCreateRequest.
/// </summary>
public class BuildingUpdateRequest : BuildingCreateRequest
{
}

public class BuildingPurchaseResponse
{
    /// <summary>
    /// The building that was purchased.
    /// </summary>
    public required BuildingDto Building { get; set; }

    /// <summary>
    /// The character that purchased the building.
    /// </summary>
    public required PlayerCharacterDto Character { get; set; }
}
