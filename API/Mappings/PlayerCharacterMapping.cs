using System.ComponentModel.DataAnnotations;
using Database.DTO;
using Database.Models;

namespace API.Mappings;

public class PlayerCharacterCreateRequest
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
    public required int UserId { get; set; }
}

public class PlayerCharacterUpdateRequest : PlayerCharacterCreateRequest
{
}