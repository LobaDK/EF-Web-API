using System.ComponentModel.DataAnnotations;

namespace Database.DTO;

public class BaseDto
{
    public int Id { get; set; }

    [Range(0, 8000)]
    public int CharacterLevelRequirement { get; set; }

    public int Price { get; set; }
}
