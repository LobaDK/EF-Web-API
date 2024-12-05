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
    public class VehicleController(IVehicleRepository vehicleRepository) : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository = vehicleRepository;

        // GET: api/Vehicle
        [MapToApiVersion(1)]
        [HttpGet(Name = "GetVehicles")]
        [ProducesResponseType(typeof(IEnumerable<VehicleDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehicles()
        {
            List<Vehicle> vehicles = await vehicleRepository.GetVehiclesAsync();

            return Ok(vehicles.Select(v => v.ToDto()));
        }

        // GET: api/Vehicle/getById
        [MapToApiVersion(1)]
        [HttpGet("getById/{Id}", Name = "GetVehicleById")]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehicleById(int Id)
        {
            try
            {
                Vehicle vehicle = await vehicleRepository.GetVehicleByIdAsync(Id);
                return Ok(vehicle.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Vehicle/getByName
        [MapToApiVersion(1)]
        [HttpGet("getByName/{Name}", Name = "GetVehiclesByName")]
        [ProducesResponseType(typeof(List<VehicleDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehiclesByName(string Name)
        {
            List<Vehicle> vehicles = await vehicleRepository.GetVehiclesByNameAsync(Name);
            return Ok(vehicles.Select(v => v.ToDto()));
        }

        // GET: api/Vehicle/getByTypeOrClass
        [MapToApiVersion(1)]
        [HttpGet("getByTypeOrClass/{TypeOrClass}", Name = "GetVehiclesByTypeOrClass")]
        [ProducesResponseType(typeof(List<VehicleDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehiclesByTypeOrClass(string TypeOrClass)
        {
            List<Vehicle> vehicles = await vehicleRepository.GetVehiclesByTypeOrClassAsync(TypeOrClass);
            return Ok(vehicles.Select(v => v.ToDto()));
        }

        // POST: api/Vehicle/create
        [MapToApiVersion(1)]
        [HttpPost("create", Name = "CreateVehicle")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PostVehicle([FromForm] VehicleCreateRequest vehicle)
        {
            try
            {
                Vehicle newVehicle = vehicle.ToDto();
                await vehicleRepository.CreateVehicleAsync(newVehicle);
                return CreatedAtRoute("GetVehicleById", new { Id = newVehicle.Id }, newVehicle.ToDto());
            }
            catch (EntryAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT: api/Vehicle/update
        [MapToApiVersion(1)]
        [HttpPut("update/{Id}", Name = "UpdateVehicle")]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutVehicle(int Id, [FromForm] VehicleCreateRequest vehicle)
        {
            try
            {
                Vehicle updatedVehicle = vehicle.ToDto();
                await vehicleRepository.UpdateVehicleAsync(Id, updatedVehicle);
                return Ok(updatedVehicle.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Vehicle/delete
        [MapToApiVersion(1)]
        [HttpDelete("delete/{Id}", Name = "DeleteVehicle")]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVehicle(int Id)
        {
            try
            {
                Vehicle deletedVehicle = await vehicleRepository.DeleteVehicleAsync(Id);
                return Ok(deletedVehicle.ToDto());
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
