using Database.DTO;
using Database.Enums;

namespace API.Mappings;

public class VehicleCreateRequest : Base
{
    public required string Name { get; set; }
    public required VehicleTypeOrClass TypeOrClass { get; set; }
    public float TopSpeed { get; set; }
    public int MaxOccupants { get; set; }
}

public class VehicleUpdateRequest : VehicleCreateRequest
{
}

public class VehiclePurchaseResponse
{
    /// <summary>
    /// The vehicle that was purchased.
    /// </summary>
    public required VehicleDto Vehicle { get; set; }

    /// <summary>
    /// The character that purchased the vehicle.
    /// </summary>
    public required PlayerCharacterDto Character { get; set; }
}