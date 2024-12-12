using API.Mappings;
using Database.Models;

namespace API.Extensions;

public static class PlayerCharacterExtensions
{
    public static PlayerCharacter ToModel(this PlayerCharacterCreateRequest playerCharacter)
    {
        return new PlayerCharacter
        {
            Name = playerCharacter.Name,
            Experience = playerCharacter.Experience,
            Money = playerCharacter.Money,
            UserId = playerCharacter.UserId
        };
    }

    public static PlayerCharacter ToModel(this PlayerCharacterUpdateRequest playerCharacter)
    {
        return new PlayerCharacter
        {
            Name = playerCharacter.Name,
            Experience = playerCharacter.Experience,
            Money = playerCharacter.Money
        };
    }
}
