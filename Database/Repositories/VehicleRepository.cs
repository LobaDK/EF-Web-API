using Database.Exceptions;
using Database.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public interface IVehicleRepository
{
    public Task<List<Vehicle>> GetVehiclesAsync();
    public Task<Vehicle> GetVehicleByIdAsync(int id);
    public Task<List<Vehicle>> GetVehiclesByNameAsync(string name);
    public Task<List<Vehicle>> GetVehiclesByOwnerIdAsync(int ownerId);
    public Task<Aircraft> CreateVehicleAsync(Aircraft aircraft);
    public Task<Landcraft> CreateVehicleAsync(Landcraft landcraft);
    public Task<Seacraft> CreateVehicleAsync(Seacraft seacraft);
    public Task<Vehicle> UpdateVehicleAsync(int id, Vehicle vehicle);
    public Task<Vehicle> DeleteVehicleAsync(int id);
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
        return await _context.Vehicles.FindAsync(id) ?? throw new EntryNotFoundException("Vehicle not found");
    }

    public async Task<List<Vehicle>> GetVehiclesByNameAsync(string name)
    {
        return await _context.Vehicles.Where(v => v.Name.Contains(name)).ToListAsync();
    }

    public async Task<List<Vehicle>> GetVehiclesByOwnerIdAsync(int ownerId)
    {
        return await _context.Vehicles.Where(v => v.OwnerId == ownerId).ToListAsync();
    }

    public async Task<Aircraft> CreateVehicleAsync(Aircraft aircraft)
    {
        try
        {
            _context.Vehicles.Add(aircraft);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            if (e.InnerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
            {
                throw new EntryAlreadyExistsException("A vehicle with the same name already exists.");
            }
            throw;
        }

        return aircraft;
    }

    public async Task<Landcraft> CreateVehicleAsync(Landcraft landcraft)
    {
        try
        {
            _context.Vehicles.Add(landcraft);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            if (e.InnerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
            {
                throw new EntryAlreadyExistsException("A vehicle with the same name already exists.");
            }
            throw;
        }

        return landcraft;
    }

    public async Task<Seacraft> CreateVehicleAsync(Seacraft seacraft)
    {
        try
        {
            _context.Vehicles.Add(seacraft);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            if (e.InnerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
            {
                throw new EntryAlreadyExistsException("A vehicle with the same name already exists.");
            }
            throw;
        }

        return seacraft;
    }

    public async Task<Vehicle> UpdateVehicleAsync(int id, Vehicle vehicle)
    {
        Vehicle existingVehicle = await GetVehicleByIdAsync(id);

        existingVehicle = vehicle;
        _context.Entry(existingVehicle).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return existingVehicle;
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
            throw new InsufficientFundsException("The character does not have enough money to purchase the vehicle.");
        }

        character.OwnedVehicles.Add(vehicle);
        character.Money -= vehicle.Price;
        await _context.SaveChangesAsync();

        return vehicle;
    }
}
