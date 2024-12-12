using System.ComponentModel.DataAnnotations;

namespace Database.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Username { get; set; }

    [Required]
    public required string PasswordHash { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Email { get; set; }

    public DateOnly BirthDate { get; set; }

    public DateOnly RegistrationDate { get; set; }

    // Navigation properties. A list of characters that belong to this user.
    public List<PlayerCharacter> ?PlayerCharacters { get; set; }
}
