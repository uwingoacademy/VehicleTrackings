using EntitiesLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private IServiceManager _serviceManager;
        private ILogger<DevicesController> _logger;

        public DevicesController(IServiceManager serviceManager, ILogger<DevicesController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("get-device")]
        public async Task<List<DevicesDTO>> GetAllDevices()
        {
            try
            {
                var devices = await _serviceManager.devicesService.GetAllDevices();
                return devices.ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new List<DevicesDTO>();
            }

        }
        [HttpGet("{id}")]
        public async Task<DevicesDTO> GetByIdDevice(int id)
        {
            try
            {
                var device = await _serviceManager.devicesService.GetByIdDevice(id);
                return device;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new DevicesDTO();
            }

        }
        [HttpPut("update-device")]
        public IActionResult UpdateDevice(DevicesDTO devicesDTO)
        {
            try
            {
                _serviceManager.devicesService.UpdateDevices(devicesDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpDelete("delete-device/{id}")]
        public IActionResult DeleteDevice(int id)
        {
            try
            {
                _serviceManager.devicesService.DeleteDevices(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPost("create-device")]
        public async Task<IActionResult> CreateDevices(DevicesDTO devicesDTO)
        {
            try
            {
                await _serviceManager.devicesService.CreateDevices(devicesDTO);
                return Ok(devicesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }

        }
    }
}
