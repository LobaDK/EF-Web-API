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
    public class PlayerCharacterController(IPlayerCharacterRepository playerCharacterRepository) : ControllerBase
    {
        private readonly IPlayerCharacterRepository playerCharacterRepository = playerCharacterRepository;

        // GET: api/PlayerCharacter
        [MapToApiVersion(1)]
        [HttpGet(Name = "GetPlayerCharacters")]
        [ProducesResponseType(typeof(IEnumerable<PlayerCharacterDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPlayerCharacters()
        {
            List<PlayerCharacter> playerCharacters = await playerCharacterRepository.GetPlayerCharactersAsync();

            return Ok(playerCharacters.Select(pc => pc.ToDto()));
        }

        // GET: api/PlayerCharacter/getById
        [MapToApiVersion(1)]
        [HttpGet("getById/{Id}", Name = "GetPlayerCharacterById")]
        [ProducesResponseType(typeof(PlayerCharacterDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPlayerCharacterById(int Id)
        {
            try
            {
                PlayerCharacter playerCharacter = await playerCharacterRepository.GetPlayerCharacterByIdAsync(Id);
                return Ok(playerCharacter.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/PlayerCharacter/getByUserId
        [MapToApiVersion(1)]
        [HttpGet("getByUserId/{UserId}", Name = "GetPlayerCharactersByUserId")]
        [ProducesResponseType(typeof(List<PlayerCharacterDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPlayerCharactersByUserId(int UserId)
        {
            List<PlayerCharacter> playerCharacters = await playerCharacterRepository.GetPlayerCharactersByUserIdAsync(UserId);
            return Ok(playerCharacters.Select(pc => pc.ToDto()));
        }

        // POST: api/PlayerCharacter
        [MapToApiVersion(1)]
        [HttpPost(Name = "CreatePlayerCharacter")]
        [ProducesResponseType(typeof(PlayerCharacterDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePlayerCharacter(PlayerCharacterCreateRequest playerCharacter)
        {
            try
            {
                PlayerCharacter newPlayerCharacter = await playerCharacterRepository.CreatePlayerCharacterAsync(playerCharacter.Name, playerCharacter.UserId);
                return CreatedAtRoute("GetPlayerCharacterById", new { Id = newPlayerCharacter.Id }, newPlayerCharacter.ToDto());
            }
            catch (EntryAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CharacterCreationLimitReachedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PATCH: api/PlayerCharacter/update
        [MapToApiVersion(1)]
        [HttpPatch("update/{Id}", Name = "UpdatePlayerCharacter")]
        [ProducesResponseType(typeof(PlayerCharacterDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePlayerCharacter(int Id, PlayerCharacterUpdateRequest playerCharacter)
        {
            try
            {
                PlayerCharacter updatedPlayerCharacter = await playerCharacterRepository.UpdatePlayerCharacterAsync(Id, playerCharacter.Name);
                return Ok(updatedPlayerCharacter.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/PlayerCharacter/delete
        [MapToApiVersion(1)]
        [HttpDelete("delete/{Id}", Name = "DeletePlayerCharacter")]
        [ProducesResponseType(typeof(PlayerCharacterDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletePlayerCharacter(int Id)
        {
            try
            {
                PlayerCharacter deletedPlayerCharacter = await playerCharacterRepository.DeletePlayerCharacterAsync(Id);
                return Ok(deletedPlayerCharacter.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
