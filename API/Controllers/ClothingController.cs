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
    public class ClothingController(IClothingRepository clothingRepository) : ControllerBase
    {
        private readonly IClothingRepository clothingRepository = clothingRepository;

        // GET: api/Clothing
        [MapToApiVersion(1)]
        [HttpGet(Name = "GetClothing")]
        [ProducesResponseType(typeof(IEnumerable<ClothingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClothing()
        {
            List<Clothing> clothing = await clothingRepository.GetClothingAsync();

            return Ok(clothing.Select(c => c.ToDto()));
        }

        // GET: api/Clothing/getById
        [MapToApiVersion(1)]
        [HttpGet("getById/{Id}", Name = "GetClothingById")]
        [ProducesResponseType(typeof(ClothingDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClothingById(int Id)
        {
            try 
            {
                Clothing clothing = await clothingRepository.GetClothingByIdAsync(Id);
                return Ok(clothing.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Clothing/getByName
        [MapToApiVersion(1)]
        [HttpGet("getByName/{Name}", Name = "GetClothingByName")]
        [ProducesResponseType(typeof(ClothingDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClothingByName(string Name)
        {
            try
            {
                Clothing clothing = await clothingRepository.GetClothingByNameAsync(Name);
                return Ok(clothing.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Clothing/getByColor
        [MapToApiVersion(1)]
        [HttpGet("getByColor/{Color}", Name = "GetClothingByColor")]
        [ProducesResponseType(typeof(List<ClothingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClothingByColor(string Color)
        {
            List<Clothing> clothing = await clothingRepository.GetClothingsByColorAsync(Color);

            return Ok(clothing.Select(c => c.ToDto()));
        }

        // POST: api/Clothing/create
        [MapToApiVersion(1)]
        [HttpPost("create", Name = "CreateClothing")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PostClothing([FromForm] ClothingCreateRequest clothing)
        {
            try
            {
                Clothing newClothing = await clothingRepository.CreateClothingAsync(clothing.ToModel());
                return CreatedAtRoute("GetClothingById", new { Id = newClothing.Id }, newClothing.ToDto());
            }
            catch (EntryAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PATCH: api/Clothing/update/5
        [MapToApiVersion(1)]
        [HttpPatch("update/{id}", Name = "UpdateClothing")]
        [ProducesResponseType(typeof(ClothingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchClothing(int id, [FromForm] ClothingUpdateRequest clothing)
        {
            try
            {
                Clothing updatedClothing = await clothingRepository.UpdateClothingAsync(id, clothing.ToModel());
                return Ok(updatedClothing.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Clothing/delete/5
        [MapToApiVersion(1)]
        [HttpDelete("delete/{id}", Name = "DeleteClothing")]
        [ProducesResponseType(typeof(ClothingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteClothing(int id)
        {
            try
            {
                Clothing clothing = await clothingRepository.DeleteClothingAsync(id);
                return Ok(clothing.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Clothing/buy/5
        [MapToApiVersion(1)]
        [HttpPost("buy/{id}", Name = "BuyClothing")]
        [ProducesResponseType(typeof(ClothingPurchaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuyClothing(int id, [FromForm] int characterId)
        {
            try
            {
                (Clothing clothing, PlayerCharacter character) = await clothingRepository.PurchaseClothingAsync(id, characterId);
                return Ok(new ClothingPurchaseResponse { Clothing = clothing.ToDto(), Character = character });
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
