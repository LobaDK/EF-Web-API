using Database.DTO;
using Database.Models;

namespace Database.Extensions;

public static class BuildingExtensions
{
    public static BuildingDto ToDto(this Building building)
    {
        return new BuildingDto
        {
            Id = building.Id,
            Name = building.Name,
            Address = building.Address,
            Type = building.Type,
            GarageSpaces = building.GarageSpaces,
            CharacterLevelRequirement = building.CharacterLevelRequirement,
            Price = building.Price
        };
    }
}