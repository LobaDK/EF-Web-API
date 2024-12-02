using API.Mappings;
using Database.Models;

namespace API.Extensions;

public static class ClothingExtensions
{
    public static Clothing ToModel(this ClothingCreateRequest clothing)
    {
        return new Clothing
        {
            Name = clothing.Name,
            Color = clothing.Color,
            Type = clothing.Type.ToString(),
            Gender = clothing.Gender,
            CharacterLevelRequirement = clothing.CharacterLevelRequirement,
            Price = clothing.Price
        };
    }
}
