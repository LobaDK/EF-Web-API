using System.ComponentModel.DataAnnotations;
using Database.DTO;
using Database.Enums;
using Database.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace API.Mappings;

public class WeaponCreateRequest : Base
{
    [Required(ErrorMessage = "A name for the weapon is required.")]
    [MaxLength(50, ErrorMessage = "The weapon name cannot be longer than 50 characters.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "A type for the weapon is required.")]
    [EnumDataType(typeof(WeaponType), ErrorMessage = "The weapon type must be a valid weapon type.")]
    [JsonConverter(typeof(StringEnumConverter))]
    public required WeaponType Type { get; set; }

    [Required(ErrorMessage = "A damage value for the weapon is required.")]
    public required float Damage { get; set; }

    [Required(ErrorMessage = "A range in meters for the weapon is required.")]
    public required float RangeInMeters { get; set; }

    [Required(ErrorMessage = "A magazine size for the weapon is required.")]
    public required int MagazineSize { get; set; }

    [Required(ErrorMessage = "A fire rate for the weapon is required.")]
    public required float FireRate { get; set; }

    [Required(ErrorMessage = "A reload time for the weapon is required.")]
    public required float ReloadTime { get; set; }

    public AmmoTypes SupportedAmmoTypes { get; set; } = AmmoTypes.Normal;

    public WeaponAttachments SupportedAttachments { get; set; } = WeaponAttachments.None;
}

public class WeaponUpdateRequest : WeaponCreateRequest
{
}

public class WeaponPurchaseResponse
{
    /// <summary>
    /// The weapon that was purchased.
    /// </summary>
    public required WeaponDto Weapon { get; set; }

    /// <summary>
    /// The character that purchased the weapon.
    /// </summary>
    public required PlayerCharacterDto Character { get; set; }
}