using System;
using Database.DTO;
using Database.Models;

namespace Database.Extensions;

public static class ClothingExtensions
{
    public static ClothingDto ToDto(this Clothing clothing)
    {
        return new ClothingDto
        {
            Id = clothing.Id,
            Name = clothing.Name,
            Color = clothing.Color,
            Type = clothing.Type,
            Gender = clothing.Gender
        };
    }
}
