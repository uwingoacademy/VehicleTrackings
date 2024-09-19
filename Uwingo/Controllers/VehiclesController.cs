using EntitiesLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private IServiceManager _serviceManager;
        private ILogger<VehiclesController> _logger;

        public VehiclesController(IServiceManager serviceManager, ILogger<VehiclesController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("get-vehicles")]
        public async Task<IActionResult> GetAllVehicles()
        {
            try
            {
                var data = await _serviceManager.vehiclesService.GetAllVehicles();
                return Ok(data);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetByIdVehicle(int id)
        {
            try
            {
                var data = _serviceManager.vehiclesService.GetByIdVehicle(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPut("update-vehicle")]
        public IActionResult UpdateVehicle(VehiclesDTO vehicles)
        {
            try
            {
                _serviceManager.vehiclesService.UpdateVehicles(vehicles);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPost("create-vehicle")]
        public async Task<IActionResult> CreateVehicle(VehiclesDTO vehicles)
        {
            try
            {
                await _serviceManager.vehiclesService.CreateVehicles(vehicles);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpDelete("delete-vehicle/{id}")]
        public IActionResult DeleteVehicle(int id)
        {

            try
            {
                _serviceManager.vehiclesService.DeleteVehicles(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
    }
}
