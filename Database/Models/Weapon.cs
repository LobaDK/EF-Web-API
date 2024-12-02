using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Enums;

namespace Database.Models;

public class Weapon
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(20)]
    public required WeaponType Type { get; set; }

    public float Damage { get; set; }

    public float RangeInMeters { get; set; }

    public int MagazineSize { get; set; }

    public float FireRate { get; set; }

    public float ReloadTime { get; set; }

    public AmmoTypes SupportedAmmoTypes { get; set; } = AmmoTypes.Normal;

    public WeaponAttachments SupportedAttachments { get; set; } = WeaponAttachments.None;

    [Range(0, 8000)]
    public int CharacterLevelRequirement { get; set; }

    public int Price { get; set; }

    // Navigation Properties
    // The player characters that own this weapon
    public List<PlayerCharacter> ?Owners { get; set; }

    [ForeignKey(nameof(Owners))]
    public int OwnerId { get; set; }
}
