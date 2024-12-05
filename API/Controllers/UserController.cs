using API.Extensions;
using API.Mappings;
using Asp.Versioning;
using Database.DTO;
using Database.Exceptions;
using Database.Extensions;
using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository userRepository = userRepository;

        // GET: api/User
        [MapToApiVersion(1)]
        [HttpGet(Name = "GetUsers")]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            List<User> users = await userRepository.GetUsersAsync();

            return Ok(users.Select(u => u.ToDto()));
        }

        // GET: api/User/getById
        [MapToApiVersion(1)]
        [HttpGet("getById/{Id}", Name = "GetUserById")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(int Id)
        {
            try
            {
                User user = await userRepository.GetUserByIdAsync(Id);
                return Ok(user.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/User/getByUsername
        [MapToApiVersion(1)]
        [HttpGet("getByUsername/{Username}", Name = "GetUserByUsername")]
        [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByUsername(string Username)
        {
            try
            {
                List<User> users = await userRepository.GetUserByUsernameAsync(Username);
                return Ok(users.Select(u => u.ToDto()));
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/User/getByEmail
        [MapToApiVersion(1)]
        [HttpGet("getByEmail/{Email}", Name = "GetUserByEmail")]
        [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByEmail(string Email)
        {
            try
            {
                List<User> users = await userRepository.GetUserByEmailAsync(Email);
                return Ok(users.Select(u => u.ToDto()));
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/User/register
        [MapToApiVersion(1)]
        [HttpPost("register", Name = "RegisterUser")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> RegisterUser([FromForm] UserCreateRequest user)
        {
            try
            {
                User newUser = await userRepository.CreateUserAsync(user.ToModel());
                return CreatedAtRoute("GetUserById", new { Id = newUser.Id }, newUser.ToDto());
            }
            catch (EntryAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT: api/User/update
        [MapToApiVersion(1)]
        [HttpPut("update/{Id}", Name = "UpdateUser")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser(int Id, [FromForm] UserUpdateRequest user)
        {
            try
            {
                User updatedUser = await userRepository.UpdateUserAsync(Id, user.ToModel());
                return Ok(updatedUser.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/User/delete
        [MapToApiVersion(1)]
        [HttpDelete("delete/{Id}", Name = "DeleteUser")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            try
            {
                User deletedUser = await userRepository.DeleteUserAsync(Id);
                return Ok(deletedUser.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
