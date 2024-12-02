using API.Mappings;
using Database.Models;

namespace API.Extensions;

public static class WeaponExtensions
{
    public static Weapon ToModel(this WeaponCreateRequest weapon)
    {
        return new Weapon
        {
            Name = weapon.Name,
            Type = weapon.Type,
            Damage = weapon.Damage,
            RangeInMeters = weapon.RangeInMeters,
            MagazineSize = weapon.MagazineSize,
            FireRate = weapon.FireRate,
            ReloadTime = weapon.ReloadTime,
            SupportedAmmoTypes = weapon.SupportedAmmoTypes,
            SupportedAttachments = weapon.SupportedAttachments,
            CharacterLevelRequirement = weapon.CharacterLevelRequirement,
            Price = weapon.Price
        };
    }
}
