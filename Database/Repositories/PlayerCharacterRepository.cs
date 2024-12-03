using Database.Exceptions;
using Database.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public interface IPlayerCharacterRepository
{
    /// <summary>
    /// Asynchronously retrieves all player characters.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="PlayerCharacter"/>s. Can be empty.</returns>
    public Task<List<PlayerCharacter>> GetPlayerCharactersAsync();

    /// <summary>
    /// Asynchronously retrieves all player characters associated with a user.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="PlayerCharacter"/>s. Can be empty.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the user is not found.</exception>
    public Task<List<PlayerCharacter>> GetPlayerCharactersByUserIdAsync(int userId);

    /// <summary>
    /// Asynchronously retrieves a player character by their ID.
    /// </summary>
    /// <param name="id">The ID of the player character</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the player character.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the player character is not found.</exception>
    public Task<PlayerCharacter> GetPlayerCharacterByIdAsync(int id);

    /// <summary>
    /// Asynchronously creates a new player character.
    /// </summary>
    /// <param name="playerCharacter">The player character to create</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created player character.</returns>
    /// <exception cref="EntryAlreadyExistsException">Thrown when a player character with the same name already exists.</exception>
    /// <exception cref="CharacterCreationLimitReachedException">Thrown when the user has reached the character creation limit.</exception>
    public Task<PlayerCharacter> CreatePlayerCharacterAsync(PlayerCharacter playerCharacter);

    /// <summary>
    /// Asynchronously updates an existing player character.
    /// </summary>
    /// <param name="id">The ID of the player character to update</param>
    /// <param name="playerCharacter">The updated player character</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated player character.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the player character is not found.</exception>
    public Task<PlayerCharacter> UpdatePlayerCharacterAsync(int id, PlayerCharacter playerCharacter);

    /// <summary>
    /// Asynchronously deletes a player character by their ID.
    /// </summary>
    /// <param name="id">The ID of the player character to delete</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted player character.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the player character is not found.</exception>
    public Task<PlayerCharacter> DeletePlayerCharacterAsync(int id);

    /// <summary>
    /// Asynchronously checks if a user has reached the character creation limit.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating if the user has reached the limit.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the user is not found.</exception>
    public Task<bool> HasReachedCharacterCreationLimitAsync(int userId);
}

public class SQLPlayerCharacterRepository(Context context) : IPlayerCharacterRepository
{
    private readonly Context _context = context;

    public async Task<List<PlayerCharacter>> GetPlayerCharactersAsync()
    {
        return await _context.PlayerCharacters.ToListAsync();
    }

    public async Task<List<PlayerCharacter>> GetPlayerCharactersByUserIdAsync(int userId)
    {
        return await _context.PlayerCharacters.Where(pc => pc.UserId == userId).ToListAsync();
    }

    public async Task<PlayerCharacter> GetPlayerCharacterByIdAsync(int id)
    {
        return await _context.PlayerCharacters.FindAsync(id) ?? throw new EntryNotFoundException("The player character was not found.");
    }

    public async Task<PlayerCharacter> CreatePlayerCharacterAsync(PlayerCharacter playerCharacter)
    {
        if (await HasReachedCharacterCreationLimitAsync(playerCharacter.UserId))
        {
            throw new CharacterCreationLimitReachedException("The user has reached the character creation limit.");
        }
        try
        {
            _context.PlayerCharacters.Add(playerCharacter);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            // Handle unique constraint violation exceptions
            if (e.InnerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
            {
                throw new EntryAlreadyExistsException("A player character with the same name already exists.");
            }
            throw;
        }

        return playerCharacter;
    }

    public async Task<PlayerCharacter> UpdatePlayerCharacterAsync(int id, PlayerCharacter playerCharacter)
    {
        PlayerCharacter existingPlayerCharacter = await GetPlayerCharacterByIdAsync(id);

        existingPlayerCharacter = playerCharacter;
        _context.Entry(existingPlayerCharacter).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return existingPlayerCharacter;
    }

    public async Task<PlayerCharacter> DeletePlayerCharacterAsync(int id)
    {
        var playerCharacter = await GetPlayerCharacterByIdAsync(id);

        _context.PlayerCharacters.Remove(playerCharacter);
        await _context.SaveChangesAsync();

        return playerCharacter;
    }

    public async Task<bool> HasReachedCharacterCreationLimitAsync(int userId)
    {
        List<PlayerCharacter> playerCharacters = await GetPlayerCharactersByUserIdAsync(userId);

        return playerCharacters.Count >= 2;
    }

}