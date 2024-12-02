using System;
using Database.DTO;
using Database.Models;

namespace Database.Extensions;

public static class UserExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            PasswordHash = user.PasswordHash,
            Email = user.Email,
            BirthDate = user.BirthDate,
            RegistrationDate = user.RegistrationDate
        };
    }
}
