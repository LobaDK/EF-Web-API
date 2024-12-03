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
            TopSpeed = vehicle.TopSpeed,
            MaxOccupants = vehicle.MaxOccupants,
            CharacterLevelRequirement = vehicle.CharacterLevelRequirement,
            Price = vehicle.Price
        };
    }

    public static AircraftDto ToDto(this Aircraft aircraft)
    {
        return new AircraftDto
        {
            Id = aircraft.Id,
            Name = aircraft.Name,
            TopSpeed = aircraft.TopSpeed,
            MaxOccupants = aircraft.MaxOccupants,
            CharacterLevelRequirement = aircraft.CharacterLevelRequirement,
            Price = aircraft.Price,
            MaxAltitude = aircraft.MaxAltitude,
            Size = aircraft.Size,
            ExtraAbilities = aircraft.ExtraAbilities
        };
    }

    public static LandcraftDto ToDto(this Landcraft landcraft)
    {
        return new LandcraftDto
        {
            Id = landcraft.Id,
            Name = landcraft.Name,
            TopSpeed = landcraft.TopSpeed,
            MaxOccupants = landcraft.MaxOccupants,
            CharacterLevelRequirement = landcraft.CharacterLevelRequirement,
            Price = landcraft.Price,
            Model = landcraft.Model,
            Class = landcraft.Class,
            Acceleration0To60 = landcraft.Acceleration0To60,
            IsElectric = landcraft.IsElectric,
            WheelCount = landcraft.WheelCount
        };
    }

    public static SeacraftDto ToDto(this Seacraft seacraft)
    {
        return new SeacraftDto
        {
            Id = seacraft.Id,
            Name = seacraft.Name,
            TopSpeed = seacraft.TopSpeed,
            MaxOccupants = seacraft.MaxOccupants,
            CharacterLevelRequirement = seacraft.CharacterLevelRequirement,
            Price = seacraft.Price,
            Size = seacraft.Size,
            RudderTurnCircle = seacraft.RudderTurnCircle
        };
    }
}
