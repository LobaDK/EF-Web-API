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
    public class BuildingsController(IBuildingRepository buildingRepository) : ControllerBase
    {
        private readonly IBuildingRepository buildingRepository = buildingRepository;

        // GET: api/Buildings
        [MapToApiVersion(1)]
        [HttpGet(Name = "GetBuildings")]
        [ProducesResponseType(typeof(IEnumerable<BuildingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBuildings()
        {
            List<Building> buildings = await buildingRepository.GetBuildingsAsync();

            return Ok(buildings.Select(b => b.ToDto()));
        }

        // GET: api/Buildings/getById
        [MapToApiVersion(1)]
        [HttpGet("getById/{Id}", Name = "GetBuildingById")]
        [ProducesResponseType(typeof(BuildingDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBuildingById(int Id)
        {
            try
            {
                Building building = await buildingRepository.GetBuildingByIdAsync(Id);
                return Ok(building.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Buildings/getByName
        [MapToApiVersion(1)]
        [HttpGet("getByName/{Name}", Name = "GetBuildingByName")]
        [ProducesResponseType(typeof(BuildingDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBuildingByName(string Name)
        {
            try
            {
                Building building = await buildingRepository.GetBuildingByNameAsync(Name);
                return Ok(building.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Buildings/create
        [MapToApiVersion(1)]
        [HttpPost("create", Name = "CreateBuilding")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PostBuilding([FromForm] BuildingCreateRequest building)
        {
            try
            {
                Building newBuilding = await buildingRepository.CreateBuildingAsync(building.ToModel());
                return CreatedAtRoute("GetBuildingById", new { id = newBuilding.Id }, newBuilding.ToDto());
            }
            catch (EntryAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PATCH: api/Buildings/update/5
        [MapToApiVersion(1)]
        [HttpPatch("update/{id}", Name = "UpdateBuilding")]
        [ProducesResponseType(typeof(BuildingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchBuilding(int id, [FromForm] BuildingUpdateRequest building)
        {
            try
            {
                Building updatedBuilding = await buildingRepository.UpdateBuildingAsync(id, building.ToModel());
                return Ok(updatedBuilding.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Buildings/delete/5
        [MapToApiVersion(1)]
        [HttpDelete("delete/{id}", Name = "DeleteBuilding")]
        [ProducesResponseType(typeof(BuildingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            try
            {
                Building building = await buildingRepository.DeleteBuildingAsync(id);
                return Ok(building.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Buildings/buy/5
        [MapToApiVersion(1)]
        [HttpPost("buy/{id}", Name = "BuyBuilding")]
        [ProducesResponseType(typeof(BuildingPurchaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuyBuilding(int id, [FromForm] int characterId)
        {
            try
            {
                (Building building, PlayerCharacter character) = await buildingRepository.PurchaseBuildingAsync(id, characterId);
                return Ok(new BuildingPurchaseResponse { Building = building.ToDto(), Character = character });
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
