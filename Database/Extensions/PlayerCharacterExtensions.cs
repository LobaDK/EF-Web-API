using Database.DTO;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Extensions;

public static class PlayerCharacterExtensions
{
    public static PlayerCharacterDto ToDto(this PlayerCharacter playerCharacter)
    {
        return new PlayerCharacterDto
        {
            Id = playerCharacter.Id,
            Name = playerCharacter.Name,
            Experience = playerCharacter.Experience,
            Money = playerCharacter.Money,
            OwnedBuildingIds = playerCharacter.OwnedBuildings.Select(building => building.Id).ToList(),
            OwnedClothingIds = playerCharacter.OwnedClothing.Select(clothing => clothing.Id).ToList(),
            OwnedVehicleIds = playerCharacter.OwnedVehicles.Select(vehicle => vehicle.Id).ToList(),
            OwnedWeaponIds = playerCharacter.OwnedWeapons.Select(weapon => weapon.Id).ToList()
        };
    }
}
