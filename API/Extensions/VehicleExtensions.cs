using API.Mappings;
using Database.Models;

namespace API.Extensions;

public static class VehicleExtensions
{
    public static Vehicle ToDto(this VehicleCreateRequest vehicle)
    {
        return new Vehicle
        {
            Name = vehicle.Name,
            TypeOrClass = vehicle.TypeOrClass,
            TopSpeed = vehicle.TopSpeed,
            MaxOccupants = vehicle.MaxOccupants,
            CharacterLevelRequirement = vehicle.CharacterLevelRequirement,
            Price = vehicle.Price
        };
    }
}
