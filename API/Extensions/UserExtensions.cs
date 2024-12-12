using API.Mappings;
using Database.Models;

namespace API.Extensions;

public static class UserExtensions
{
    public static User ToModel(this UserCreateRequest user)
    {
        return new User
        {
            Username = user.Username,
            PasswordHash = user.PasswordHash,
            Email = user.Email,
            BirthDate = user.BirthDate,
        };
    } 
}
