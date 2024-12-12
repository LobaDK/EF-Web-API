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

    public List<int> OwnedBuildingIds { get; set; } = [];

    public List<int> OwnedClothingIds { get; set; } = [];

    public List<int> OwnedVehicleIds { get; set; } = [];

    public List<int> OwnedWeaponIds { get; set; } = [];
}
