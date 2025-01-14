using API.Mappings;
using API.Extensions;
using Database.Extensions;
using Database.DTO;
using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Database.Exceptions;

namespace API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class WeaponController(IWeaponRepository weaponRepository) : ControllerBase
    {
        private readonly IWeaponRepository weaponRepository = weaponRepository;

        // GET: api/Weapon
        [MapToApiVersion(1)]
        [HttpGet(Name = "GetWeapons")]
        [ProducesResponseType(typeof(IEnumerable<WeaponDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWeapons()
        {
            List<Weapon> weapons = await weaponRepository.GetWeaponsAsync();

            return Ok(weapons.Select(w => w.ToDto()));
        }

        // GET: api/Weapon/getById
        [MapToApiVersion(1)]
        [HttpGet("getById/{Id}", Name = "GetWeaponById")]
        [ProducesResponseType(typeof(WeaponDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWeaponById(int Id)
        {
            try
            {
                Weapon weapon = await weaponRepository.GetWeaponByIdAsync(Id);
                return Ok(weapon.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Weapon/getByName
        [MapToApiVersion(1)]
        [HttpGet("getByName/{Name}", Name = "GetWeaponByName")]
        [ProducesResponseType(typeof(WeaponDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWeaponByName(string Name)
        {
            try
            {
                Weapon weapon = await weaponRepository.GetWeaponByNameAsync(Name);
                return Ok(weapon.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Weapon/create
        [MapToApiVersion(1)]
        [HttpPost("create", Name = "CreateWeapon")]
        [ProducesResponseType(typeof(WeaponDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateWeapon([FromForm] WeaponCreateRequest weapon)
        {
            try
            {
                Weapon newWeapon = await weaponRepository.CreateWeaponAsync(weapon.ToModel());
                return CreatedAtRoute("GetWeaponById", new { Id = newWeapon.Id }, newWeapon.ToDto());
            }
            catch (EntryAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }

        }

        // PATCH: api/Weapon/update/5
        [MapToApiVersion(1)]
        [HttpPatch("update/{id}", Name = "UpdateWeapon")]
        [ProducesResponseType(typeof(WeaponDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchWeapon(int id, [FromForm] WeaponUpdateRequest Weapon)
        {
            try
            {
                Weapon weapon = await weaponRepository.UpdateWeaponAsync(id, Weapon.ToModel());
                return Ok(weapon.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Weapon/delete/5
        [MapToApiVersion(1)]
        [HttpDelete("delete/{id}", Name = "DeleteWeapon")]
        [ProducesResponseType(typeof(WeaponDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWeapon(int id)
        {
            try 
            {
                Weapon weapon = await weaponRepository.DeleteWeaponAsync(id);
                return Ok(weapon.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Weapon/buy/5
        [MapToApiVersion(1)]
        [HttpPost("buy/{id}", Name = "BuyWeapon")]
        [ProducesResponseType(typeof(WeaponPurchaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuyWeapon(int id, [FromForm] int characterId)
        {
            try
            {
                (Weapon weapon, PlayerCharacter character) = await weaponRepository.PurchaseWeaponAsync(id, characterId);
                return Ok(new WeaponPurchaseResponse { Weapon = weapon.ToDto(), Character = character.ToDto() });
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InsufficientFundsException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
