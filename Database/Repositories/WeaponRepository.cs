using System;
using Database.Exceptions;
using Database.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public interface IWeaponRepository
{
    /// <summary>
    /// Asynchronously retrieves all weapon items asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of weapon items.</returns>
    Task<List<Weapon>> GetWeaponsAsync();

    /// <summary>
    /// Asynchronously retrieves a weapon item by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the weapon item.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the weapon item.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the weapon is not found.</exception>
    Task<Weapon> GetWeaponByIdAsync(int id);

    /// <summary>
    /// Asynchronously retrieves a weapon item by its name asynchronously.
    /// </summary>
    /// <param name="name">The name of the weapon item.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the weapon item.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the weapon is not found.</exception>
    Task<Weapon> GetWeaponByNameAsync(string name);

    /// <summary>
    /// Asynchronously retrieves a list of weapon items by their type.
    /// </summary>
    /// <param name="type">The type of the weapon items.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of weapon items. Can be empty.</returns>
    Task<List<Weapon>> GetWeaponsByTypeAsync(string type);

    /// <summary>
    /// Asynchronously creates a new weapon item asynchronously.
    /// </summary>
    /// <param name="weapon">The weapon item to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created weapon item.</returns>
    /// <exception cref="EntryAlreadyExistsException">Thrown when a weapon with the same name already exists.</exception>
    Task<Weapon> CreateWeaponAsync(Weapon weapon);

    /// <summary>
    /// Asynchronously updates an existing weapon item asynchronously.
    /// </summary>
    /// <param name="id">The ID of the weapon item to update.</param>
    /// <param name="weapon">The updated weapon item.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated weapon item.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the weapon is not found.</exception>
    Task<Weapon> UpdateWeaponAsync(int id, Weapon weapon);

    /// <summary>
    /// Asynchronously deletes a weapon item by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the weapon item to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted weapon item.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the weapon is not found.</exception>
    Task<Weapon> DeleteWeaponAsync(int id);

    /// <summary>
    /// Asynchronously purchases a weapon item for a character asynchronously.
    /// </summary>
    /// <param name="weaponId">The ID of the weapon item to purchase.</param>
    /// <param name="characterId">The ID of the character purchasing the weapon.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the purchased weapon item and the <see cref="PlayerCharacter"/> object.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the weapon or character is not found.</exception>
    /// <exception cref="InsufficientFundsException">Thrown when the character does not have enough money to purchase the weapon.</exception>
    Task<(Weapon, PlayerCharacter)> PurchaseWeaponAsync(int weaponId, int characterId);
}

public class SQLWeaponRepository(Context context) : IWeaponRepository
{
    private readonly Context _context = context;

    public async Task<List<Weapon>> GetWeaponsAsync()
    {
        return await _context.Weapons.ToListAsync();
    }

    public async Task<Weapon> GetWeaponByIdAsync(int id)
    {
        return await _context.Weapons.FindAsync(id) ?? throw new EntryNotFoundException("Weapon not found.");
    }

    public async Task<Weapon> GetWeaponByNameAsync(string name)
    {
        return await _context.Weapons.FirstOrDefaultAsync(w => w.Name == name) ?? throw new EntryNotFoundException("Weapon not found.");
    }

    public async Task<List<Weapon>> GetWeaponsByTypeAsync(string type)
    {
        return await _context.Weapons.Where(w => w.Type.ToString() == type).ToListAsync();
    }

    public async Task<Weapon> CreateWeaponAsync(Weapon weapon)
    {
        try
        {
            _context.Weapons.Add(weapon);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            // Handle unique constraint violation exceptions
            if (e.InnerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
            {
                throw new EntryAlreadyExistsException("A weapon with the same name already exists.");
            }
            throw;
        }
        return weapon;
    }

    public async Task<Weapon> UpdateWeaponAsync(int id, Weapon weapon)
    {
        weapon.Id = id;
        _context.Weapons.Update(weapon);
        await _context.SaveChangesAsync();
        
        return weapon;
    }

    public async Task<Weapon> DeleteWeaponAsync(int id)
    {
        Weapon weapon = await GetWeaponByIdAsync(id);
        _context.Weapons.Remove(weapon);
        await _context.SaveChangesAsync();
        return weapon;
    }

    public async Task<(Weapon, PlayerCharacter)> PurchaseWeaponAsync(int weaponId, int characterId)
    {
        Weapon weapon = await GetWeaponByIdAsync(weaponId);
        PlayerCharacter character = await new SQLPlayerCharacterRepository(_context).GetPlayerCharacterByIdAsync(characterId);

        if (character.Money < weapon.Price)
        {
            throw new InsufficientFundsException("Character does not have enough money to purchase the weapon.");
        }

        character.Money -= weapon.Price;
        character.OwnedWeapons.Add(weapon);
        await _context.SaveChangesAsync();

        return (weapon, character);
    }
}
