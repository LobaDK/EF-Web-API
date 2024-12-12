using System.ComponentModel.DataAnnotations;

namespace Database.DTO;

public class UserDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Username { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public required string Email { get; set; }

    public DateOnly BirthDate { get; set; }

    public DateOnly RegistrationDate { get; set; }
}
