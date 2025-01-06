using Database.Exceptions;
using Database.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public interface IVehicleRepository
{
    /// <summary>
    /// Asynchronously retrieves a list of vehicles from the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Vehicle"/> objects. Can be empty.</returns>
    public Task<List<Vehicle>> GetVehiclesAsync();

    /// <summary>
    /// Asynchronously retrieves a vehicle by its ID.
    /// </summary>
    /// <param name="id">The ID of the vehicle to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="Vehicle"/> object.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the vehicle is not found.</exception>
    public Task<Vehicle> GetVehicleByIdAsync(int id);

    /// <summary>
    /// Asynchronously retrieves a list of vehicles by their name.
    /// </summary>
    /// <param name="name">The name of the vehicles to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Vehicle"/> objects. Can be empty.</returns>
    public Task<List<Vehicle>> GetVehiclesByNameAsync(string name);

    /// <summary>
    /// Asynchronously retrieves a list of vehicles by their type or class.
    /// </summary>
    /// <param name="typeOrClass">The type or class of the vehicles to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Vehicle"/> objects. Can be empty.</returns>
    public Task<List<Vehicle>> GetVehiclesByTypeOrClassAsync(string typeOrClass);

    /// <summary>
    /// Asynchronously retrieves a list of vehicles by their owner's name.
    /// </summary>
    /// <param name="ownerName">The name of the owner to retrieve vehicles for.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Vehicle"/> objects. Can be empty.</returns>
    /// <exception cref="EntryAlreadyExistsException">Thrown when a vehicle with the same name already exists.</exception>
    public Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);

    /// <summary>
    /// Asynchronously updates an existing vehicle in the database.
    /// </summary>
    /// <param name="id">The ID of the vehicle to update.</param>
    /// <param name="vehicle">The updated vehicle object.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated <see cref="Vehicle"/> object.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the vehicle is not found.</exception>
    public Task<Vehicle> UpdateVehicleAsync(int id, Vehicle vehicle);
    
    /// <summary>
    /// Asynchronously updates an existing vehicle in the database.
    /// </summary>
    /// <param name="id">The ID of the vehicle to update.</param>
    /// <param name="vehicle">The updated vehicle object.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated <see cref="Vehicle"/> object.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the vehicle is not found.</exception>
    public Task<Vehicle> DeleteVehicleAsync(int id);

    /// <summary>
    /// Asynchronously purchases a vehicle for a character.
    /// </summary>
    /// <param name="id">The ID of the vehicle to purchase.</param>
    /// <param name="ownerId">The ID of the character purchasing the vehicle.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the purchased <see cref="Vehicle"/> object.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the vehicle is not found.</exception>
    public Task<Vehicle> PurchaseVehicleAsync(int id, int ownerId);
}

public class SQLVehicleRepository(Context context) : IVehicleRepository
{
    private readonly Context _context = context;

    public async Task<List<Vehicle>> GetVehiclesAsync()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task<Vehicle> GetVehicleByIdAsync(int id)
    {
        return await _context.Vehicles.FindAsync(id) ?? throw new EntryNotFoundException($"Vehicle with ID {id} was not found.");
    }

    public async Task<List<Vehicle>> GetVehiclesByNameAsync(string name)
    {
        return await _context.Vehicles.Where(v => v.Name.Contains(name)).ToListAsync();
    }

    public async Task<List<Vehicle>> GetVehiclesByTypeOrClassAsync(string typeOrClass)
    {
        return await _context.Vehicles.Where(v => v.TypeOrClass.ToString() == typeOrClass).ToListAsync();
    }

    public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
    {
        try
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }
        catch (DbUpdateException e)
        {
            // Handle unique constraint violation exceptions
            if (e.InnerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
            {
                throw new EntryAlreadyExistsException("A vehicle with the same name already exists.");
            }
            throw;
        }
    }

    public async Task<Vehicle> UpdateVehicleAsync(int id, Vehicle vehicle)
    {

        vehicle.Id = id;
        _context.Vehicles.Update(vehicle);
        await _context.SaveChangesAsync();

        return vehicle;
    }

    public async Task<Vehicle> DeleteVehicleAsync(int id)
    {
        Vehicle vehicle = await GetVehicleByIdAsync(id);

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return vehicle;
    }

    public async Task<Vehicle> PurchaseVehicleAsync(int id, int characterId)
    {
        Vehicle vehicle = await GetVehicleByIdAsync(id);
        PlayerCharacter character = await new SQLPlayerCharacterRepository(_context).GetPlayerCharacterByIdAsync(characterId);

        if (character.Money < vehicle.Price)
        {
            throw new InsufficientFundsException("Character does not have enough money to purchase the vehicle.");
        }

        character.OwnedVehicles.Add(vehicle);
        character.Money -= vehicle.Price;
        await _context.SaveChangesAsync();

        return vehicle;
    }
}