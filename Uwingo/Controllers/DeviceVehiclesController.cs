using EntitiesLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceVehiclesController : ControllerBase
    {
        private IServiceManager _serviceManager;
        private ILogger<DeviceVehiclesController> _logger;

        public DeviceVehiclesController(IServiceManager serviceManager, ILogger<DeviceVehiclesController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("get-devicevehicle")]
        public async Task<IActionResult> GetAllDeviceVehicles()
        {
            try
            {
                var devices = await _serviceManager.deviceVehiclesService.GetAllDeviceVehicles();
                return Ok(devices.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdDeviceVehicle(int id)
        {
            try
            {
                var dto = await _serviceManager.deviceVehiclesService.GetByIdDeviceVehicle(id);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
        [HttpPut("update-devicevehicle")]
        public IActionResult UpdateDevicleVehicles(DeviceVehiclesDTO deviceVehicles)
        { //update durumunda bağlı cihaz değişti ise cihazın bağlı durumunu update yap 
          //update durumunda yeni bir veri gibi bu veriyi create yap (id yi 0a çekerek) buradan gelen idli veriyi ise güncelle ve remove date now ekle 

            try
            {
                _serviceManager.deviceVehiclesService.UpdateDeviceVehicles(deviceVehicles);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPost("create-devicevehicle")]
        public async Task<IActionResult> CreateDevicleVehicles(DeviceVehiclesDTO deviceVehicles)
        {// seçilen cihazın bağlı durumunu true olarak ata
            try
            {
                await _serviceManager.deviceVehiclesService.CreateDeviceVehicles(deviceVehicles);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpDelete("delete-devicevehicle/{id}")]
        public IActionResult DeleteDeviceVehicle(int id)
        {//delete durumunda bu idye sahip veride bulunan cihazın bağlı durumunu false çek update yap ardından bu id verinin RemoveDate ine now ata ve bunu da update yap
            try
            {
                _serviceManager.deviceVehiclesService.DeleteDeviceVehicles(id);
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
