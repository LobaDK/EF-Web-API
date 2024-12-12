
using API.Mappings;
using Database.Models;

namespace API.Extensions;

public static class BuildingExtensions
{
    public static Building ToModel(this BuildingCreateRequest building)
    {
        return new Building
        {
            Name = building.Name,
            Address = building.Address,
            Type = building.Type,
            GarageSpaces = building.GarageSpaces,
            CharacterLevelRequirement = building.CharacterLevelRequirement,
            Price = building.Price
        };
    }
}