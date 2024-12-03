
using Database.Exceptions;
using Database.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public interface IBuildingRepository
{
    /// <summary>
    /// Asynchronously retrieves a list of buildings from the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Building"/> objects. Can be empty.</returns>
    public Task<List<Building>> GetBuildingsAsync();

    /// <summary>
    /// Asynchronously retrieves a building by its ID.
    /// </summary>
    /// <param name="id">The ID of the building to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="Building"/> object.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the building is not found.</exception>
    public Task<Building> GetBuildingByIdAsync(int id);

    /// <summary>
    /// Asynchronously retrieves a building by its name.
    /// </summary>
    /// <param name="name">The name of the building to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="Building"/> object.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the building is not found.</exception>
    public Task<Building> GetBuildingByNameAsync(string name);

    /// <summary>
    /// Asynchronously creates a new building in the database.
    /// </summary>
    /// <param name="building">The building to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="Building"/> object.</returns>
    /// <exception cref="EntryAlreadyExistsException">Thrown when a building with the same name already exists.</exception>
    public Task<Building> CreateBuildingAsync(Building building);

    /// <summary>
    /// Asynchronously updates an existing building in the database.
    /// </summary>
    /// <param name="id">The ID of the building to update.</param>
    /// <param name="building">The updated building object.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated <see cref="Building"/> object.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the building is not found.</exception>
    public Task<Building> UpdateBuildingAsync(int id, Building building);

    /// <summary>
    /// Asynchronously deletes a building from the database.
    /// </summary>
    /// <param name="id">The ID of the building to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted <see cref="Building"/> object.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the building is not found.</exception>
    public Task<Building> DeleteBuildingAsync(int id);

    /// <summary>
    /// Asynchronously purchases a building for a character.
    /// </summary>
    /// <param name="buildingId">The ID of the building to purchase.</param>
    /// <param name="characterId">The ID of the character purchasing the building.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the purchased <see cref="Building"/> object and the <see cref="PlayerCharacter"/> object.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the building or character is not found.</exception>
    /// <exception cref="InsufficientFundsException">Thrown when the character does not have enough money to purchase the building.</exception>
    public Task<(Building, PlayerCharacter)> PurchaseBuildingAsync(int buildingId, int characterId);
}

public class SQLBuildingRepository(Context context) : IBuildingRepository
{
    private readonly Context _context = context;
    
    public async Task<List<Building>> GetBuildingsAsync()
    {
        return await _context.Buildings.ToListAsync();
    }

    public async Task<Building> GetBuildingByIdAsync(int id)
    {
        return await _context.Buildings.FindAsync(id) ?? throw new EntryNotFoundException("Building not found.");
    }

    public async Task<Building> GetBuildingByNameAsync(string name)
    {
        return await _context.Buildings.Where(b => b.Name == name).FirstOrDefaultAsync() ?? throw new EntryNotFoundException("Building not found.");
    }

    public async Task<Building> CreateBuildingAsync(Building building)
    {
        try
        {
            await _context.Buildings.AddAsync(building);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            // Catch unique constraint violation exceptions
            if (e.InnerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
            {
                throw new EntryAlreadyExistsException("Building with the same name already exists.");
            }
            throw;
        }

        return building;
    }
    
    public async Task<Building> UpdateBuildingAsync(int id, Building building)
    {
        Building existingBuilding = await GetBuildingByIdAsync(id);
        
        existingBuilding = building;
        _context.Entry(existingBuilding).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return existingBuilding;
    }

    public async Task<Building> DeleteBuildingAsync(int id)
    {
        Building building = await GetBuildingByIdAsync(id);

        _context.Buildings.Remove(building);
        await _context.SaveChangesAsync();

        return building;
    }
    
    public async Task<(Building, PlayerCharacter)> PurchaseBuildingAsync(int buildingId, int characterId)
    {
        Building building = await GetBuildingByIdAsync(buildingId);
        PlayerCharacter character = await new SQLPlayerCharacterRepository(_context).GetPlayerCharacterByIdAsync(characterId);

        if (character.Money < building.Price)
        {
            throw new InsufficientFundsException("Character does not have enough money to purchase the building.");
        }

        character.OwnedBuildings.Add(building);
        character.Money -= building.Price;
        await _context.SaveChangesAsync();

        return (building, character);
    }
}