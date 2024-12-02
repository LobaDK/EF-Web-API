using System.ComponentModel.DataAnnotations;
using Database.Enums;

namespace Database.DTO;

public class WeaponDto : BaseDto
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(20)]
    public required WeaponType Type { get; set; }

    [Required]
    public required float Damage { get; set; }

    [Required]
    public required float RangeInMeters { get; set; }

    [Required]
    public required int MagazineSize { get; set; }

    [Required]
    public required float FireRate { get; set; }

    [Required]
    public required float ReloadTime { get; set; }

    public AmmoTypes SupportedAmmoTypes { get; set; }

    public WeaponAttachments SupportedAttachments { get; set; }

}
