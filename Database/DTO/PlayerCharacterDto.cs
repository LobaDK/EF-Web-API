using System.ComponentModel.DataAnnotations;

namespace Database.DTO;

public class PlayerCharacterDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    public long Experience { get; set; }

    public int Money { get; set; }

    public List<BuildingDto> OwnedBuildings { get; set; } = [];

    public List<ClothingDto> OwnedClothing { get; set; } = [];

    public List<VehicleDto> OwnedVehicles { get; set; } = [];

    public List<WeaponDto> OwnedWeapons { get; set; } = [];
}
