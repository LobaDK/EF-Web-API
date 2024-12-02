using System;
using System.ComponentModel.DataAnnotations;

namespace API.Mappings;

public class UserCreateRequest
{
    [Required(ErrorMessage = "A username is required.")]
    [MaxLength(50)]
    public required string Username { get; set; }

    [Required(ErrorMessage = "An email address is required.")]
    [MaxLength(100)]
    [EmailAddress(ErrorMessage = "The email address is not valid.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "A password is required.")]
    [MaxLength(50)]
    public required string PasswordHash { get; set; }

    [Required(ErrorMessage = "A birth date is required.")]
    public DateOnly BirthDate { get; set; }
}

public class UserUpdateRequest : UserCreateRequest
{
}

/// <summary>
/// Represents a user request response.
/// </summary>
public class UserRequestResponse
{
    public int Id { get; set; }

    [MaxLength(50)]
    public required string Username { get; set; }

    [MaxLength(100)]
    public required string Email { get; set; }

    public DateOnly BirthDate { get; set; }

    public DateOnly RegistrationDate { get; set; }
}
