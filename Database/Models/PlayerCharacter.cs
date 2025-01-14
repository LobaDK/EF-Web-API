using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

public class PlayerCharacter
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    public long Experience { get; set; }

    public int Money { get; set; }

    public List<Building>? OwnedBuildings { get; set; }

    public List<Clothing>? OwnedClothing { get; set; }

    public List<Vehicle>? OwnedVehicles { get; set; }

    public List<Weapon>? OwnedWeapons { get; set; }

    // Navigation properties
    // The user that owns this character
    public User ?User { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
}
