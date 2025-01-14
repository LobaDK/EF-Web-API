using Database.Exceptions;
using Database.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Asynchronously retrieves all users.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of users. Can be empty.</returns>
    public Task<List<User>> GetUsersAsync();

    /// <summary>
    /// Asynchronously retrieves a user by their ID.
    /// </summary>
    /// <param name="id">The ID of the user</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the user is not found.</exception>
    public Task<User> GetUserByIdAsync(int id);

    /// <summary>
    /// Asynchronously retrieves users matching the specified username.
    /// </summary>
    /// <param name="username">The full or partial username</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of users. Can be empty.</returns>
    public Task<List<User>> GetUserByUsernameAsync(string username);
    
    /// <summary>
    /// Asynchronously retrieves users matching the specified email.
    /// </summary>
    /// <param name="email">The full or partial email</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of users. Can be empty.</returns>
    public Task<List<User>> GetUserByEmailAsync(string email);
    
    /// <summary>
    /// Asynchronously creates a new user.
    /// </summary>
    /// <param name="user">The user to create</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created user.</returns>
    /// <exception cref="EntryAlreadyExistsException">Thrown when a user with the same username or email already exists.</exception>
    public Task<User> CreateUserAsync(User user);

    /// <summary>
    /// Asynchronously updates an existing user.
    /// </summary>
    /// <param name="id">The ID of the user to update</param>
    /// <param name="user">The updated user</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated user.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the user is not found.</exception>
    public Task<User> UpdateUserAsync(int id, User user);

    /// <summary>
    /// Asynchronously deletes a user by their ID.
    /// </summary>
    /// <param name="id">The ID of the user to delete</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted user.</returns>
    /// <exception cref="EntryNotFoundException">Thrown when the user is not found.</exception>
    public Task<User> DeleteUserAsync(int id);
}

public class SQLUserRepository(Context context) : IUserRepository
{
    private readonly Context _context = context;

    public async Task<List<User>> GetUsersAsync()
    {
        return await _context.Users
        .Include(u => u.PlayerCharacters)
        .ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users
        .Include(u => u.PlayerCharacters)
        .FirstOrDefaultAsync(u => u.Id == id) ?? throw new EntryNotFoundException($"User with ID {id} not found.");
    }

    public async Task<List<User>> GetUserByUsernameAsync(string username)
    {
        return await _context.Users.Where(u => u.Username.Contains(username))
        .Include(u => u.PlayerCharacters)
        .ToListAsync();
    }

    public async Task<List<User>> GetUserByEmailAsync(string email)
    {
        return await _context.Users.Where(u => u.Email.Contains(email))
        .Include(u => u.PlayerCharacters)
        .ToListAsync();
    }

    public async Task<User> CreateUserAsync(User user)
    {
        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            // Handle unique constraint violation exceptions
            if (e.InnerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
            {
                throw new EntryAlreadyExistsException("A user with the same username or email already exists.");
            }
            throw;
        }
        return user;
    }

    public async Task<User> UpdateUserAsync(int id, User user)
    {
        user.Id = id;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> DeleteUserAsync(int id)
    {
        User user = await GetUserByIdAsync(id);

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return user;
    }   
}