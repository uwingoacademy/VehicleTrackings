using EntitiesLayer.Abstract;
using EntitiesLayer.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private IServiceManager _serviceManager;
        private ILogger<DriversController> _logger;

        public DriversController(IServiceManager serviceManager, ILogger<DriversController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("get-driver")]
        public async Task<IActionResult> GetAllDrivers()
        {
            try
            {
                var drivers = await _serviceManager.driversService.GetAllDrivers();
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetByIdDriver(int id)
        {
            try
            {
                var driver = _serviceManager.driversService.GetByIdDriver(id);
                return Ok(driver);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
        [HttpPut("update-driver")]
        public IActionResult UpdateDriver(DriversDTO drivers)
        {
            try
            {
                _serviceManager.driversService.UpdateDrivers(drivers);
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPost("create-driver")]
        public async Task<IActionResult> CreateDriver(DriversDTO drivers)
        {
            try
            {
                await _serviceManager.driversService.CreateDrivers(drivers);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpDelete("delete-driver/{id}")]
        public IActionResult DeleteDriver(int id)
        {
            try
            {
                _serviceManager.driversService.DeleteDrivers(id);
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
