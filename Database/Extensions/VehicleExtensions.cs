using Database.DTO;
using Database.Models;

namespace Database.Extensions;

public static class VehicleExtensions
{
    public static VehicleDto ToDto(this Vehicle vehicle)
    {
        return new VehicleDto
        {
            Id = vehicle.Id,
            Name = vehicle.Name,
            TypeOrClass = vehicle.TypeOrClass,
            TopSpeed = vehicle.TopSpeed,
            MaxOccupants = vehicle.MaxOccupants,
            CharacterLevelRequirement = vehicle.CharacterLevelRequirement,
            Price = vehicle.Price
        };
    }
}
