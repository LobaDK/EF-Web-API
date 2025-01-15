using Database.Exceptions;
using Database.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public interface IClothingRepository
{
    /// <summary>
    /// Asynchronously retrieves all clothing items asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of clothing items.</returns>
    public Task<List<Clothing>> GetClothingAsync();

    /// <summary>
    /// Asynchronously retrieves a clothing item by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the clothing item.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the clothing item.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the clothing item is not found.</exception>
    public Task<Clothing> GetClothingByIdAsync(int id);

    /// <summary>
    /// Asynchronously retrieves a clothing item by its name asynchronously.
    /// </summary>
    /// <param name="name">The name of the clothing item.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the clothing item.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the clothing item is not found.</exception>
    public Task<Clothing> GetClothingByNameAsync(string name);

    /// <summary>
    /// Asynchronously retrieves a list of clothing items by their color.
    /// </summary>
    /// <param name="color">The color of the clothing items.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of clothing items. Can be empty.</returns>
    public Task<List<Clothing>> GetClothingsByColorAsync(string color);

    /// <summary>
    /// Asynchronously creates a new clothing item asynchronously.
    /// </summary>
    /// <param name="clothing">The clothing item to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created clothing item.</returns>
    /// <exception cref="EntryAlreadyExistsException">Thrown when a clothing item with the same name already exists.</exception>
    public Task<Clothing> CreateClothingAsync(Clothing clothing);

    /// <summary>
    /// Asynchronously updates an existing clothing item asynchronously.
    /// </summary>
    /// <param name="id">The ID of the clothing item to update.</param>
    /// <param name="clothing">The updated clothing item.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated clothing item.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the clothing item is not found.</exception>
    public Task<Clothing> UpdateClothingAsync(int id, Clothing clothing);

    /// <summary>
    /// Asynchronously deletes a clothing item by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the clothing item to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted clothing item.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the clothing item is not found.</exception>
    public Task<Clothing> DeleteClothingAsync(int id);

    /// <summary>
    /// Asynchronously purchases a clothing item for a character asynchronously.
    /// </summary>
    /// <param name="id">The ID of the clothing item to purchase.</param>
    /// <param name="characterId">The ID of the character purchasing the clothing item.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the purchased <see cref="Clothing"/>  object.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the clothing item or character is not found.</exception>
    /// <exception cref="InsufficientFundsException">Thrown when the character does not have enough money to purchase the clothing item.</exception>
    public Task<(Clothing, PlayerCharacter)> PurchaseClothingAsync(int id, int characterId);
}

public class SQLClothingRepository(Context context) : IClothingRepository
{
    private readonly Context _context = context;

    public async Task<List<Clothing>> GetClothingAsync()
    {
        return await _context.Clothing
        .Include(c => c.Owners)
        .ToListAsync();
    }

    public async Task<Clothing> GetClothingByIdAsync(int id)
    {
        return await _context.Clothing
        .Include(c => c.Owners)
        .FirstOrDefaultAsync(c => c.Id == id) ?? throw new EntryNotFoundException("Clothing item not found.");
    }

    public async Task<Clothing> GetClothingByNameAsync(string name)
    {
        return await _context.Clothing.Where(c => c.Name == name)
        .Include(c => c.Owners)
        .FirstOrDefaultAsync() ?? throw new EntryNotFoundException("Clothing item not found.");
    }

    public async Task<List<Clothing>> GetClothingsByColorAsync(string color)
    {
        return await _context.Clothing.Where(c => c.Color == color)
        .Include(c => c.Owners)
        .ToListAsync();
    }

    public async Task<Clothing> CreateClothingAsync(Clothing clothing)
    {
        try
        {
            _context.Clothing.Add(clothing);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            // Handle unique constraint violation exceptions
            if (e.InnerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
            {
                throw new EntryAlreadyExistsException("Clothing item with the same name already exists.");
            }
            throw;
        }

        return clothing;
    }

    public async Task<Clothing> UpdateClothingAsync(int id, Clothing clothing)
    {
        clothing.Id = id;
        _context.Clothing.Update(clothing);
        await _context.SaveChangesAsync();

        return clothing;
    }

    public async Task<Clothing> DeleteClothingAsync(int id)
    {
        Clothing clothing = await GetClothingByIdAsync(id);
        _context.Clothing.Remove(clothing);
        await _context.SaveChangesAsync();
        return clothing;
    }

    public async Task<(Clothing, PlayerCharacter)> PurchaseClothingAsync(int id, int characterId)
    {
        Clothing clothing = await GetClothingByIdAsync(id);
        PlayerCharacter character = await new SQLPlayerCharacterRepository(_context).GetPlayerCharacterByIdAsync(characterId);
        
        
        if (character.Money < clothing.Price)
        {
            throw new InsufficientFundsException("Character does not have enough money to purchase this item.");
        }

        character.OwnedClothing ??= [];
        character.OwnedClothing.Add(clothing);
        character.Money -= clothing.Price;
        await _context.SaveChangesAsync();

        return (clothing, character);
    }
}