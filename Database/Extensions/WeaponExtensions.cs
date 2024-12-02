using Database.DTO;
using Database.Models;

namespace Database.Extensions;

public static class WeaponExtensions
{
    public static WeaponDto ToDto(this Weapon weapon)
    {
        return new WeaponDto
        {
            Id = weapon.Id,
            CharacterLevelRequirement = weapon.CharacterLevelRequirement,
            Name = weapon.Name,
            Type = weapon.Type,
            Damage = weapon.Damage,
            RangeInMeters = weapon.RangeInMeters,
            MagazineSize = weapon.MagazineSize,
            FireRate = weapon.FireRate,
            ReloadTime = weapon.ReloadTime,
            SupportedAmmoTypes = weapon.SupportedAmmoTypes,
            SupportedAttachments = weapon.SupportedAttachments,
            Price = weapon.Price
        };
    }
}
