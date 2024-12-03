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
            OwnedBuildings = playerCharacter.OwnedBuildings.Select(building => building.ToDto()).ToList(),
            OwnedClothing = playerCharacter.OwnedClothing.Select(clothing => clothing.ToDto()).ToList(),
            OwnedVehicles = playerCharacter.OwnedVehicles.Select(vehicle => vehicle.ToDto()).ToList(),
            OwnedWeapons = playerCharacter.OwnedWeapons.Select(weapon => weapon.ToDto()).ToList()
        };
    }
}
