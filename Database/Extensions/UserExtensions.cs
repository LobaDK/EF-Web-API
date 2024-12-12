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
            Email = user.Email,
            BirthDate = user.BirthDate,
            RegistrationDate = user.RegistrationDate
        };
    }
}
