using EntitiesLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverVehicleController : ControllerBase
    {
        private IServiceManager _serviceManager;
        private ILogger<DriverVehicleController> _logger;

        public DriverVehicleController(IServiceManager serviceManager, ILogger<DriverVehicleController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("get-drivervehicle")]
        public async Task<IActionResult> GetAllDriverVehicle()
        {
            try
            {
                var driver = await _serviceManager.driverVehicleService.GetAllDriverVehicle();
                return Ok(driver);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetByIdDriverVehicle(int id)
        {
            try
            {
                var vehicle = _serviceManager.driverVehicleService.GetByIdDriverVehicle(id);
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPut("update-drivervehicle")]
        public IActionResult UpdateDriverVehicle(DriverVehicleDTO driverVehicleDTO)
        { 
             try
            {
                _serviceManager.driverVehicleService.UpdateDriverVehicle(driverVehicleDTO);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPost("create-drivervehicle")]
        public async Task<IActionResult> CreateDriverVehicle(DriverVehicleDTO driverVehicle)
        {//Seçilen aracın sürücü kısmını true olarak güncelle

            try
            {
                await _serviceManager.driverVehicleService.CreateDriverVehicle(driverVehicle);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpDelete("delete-drivervehicle/{id}")]
        public IActionResult DeleteDriverVehicle(int id)
        {
            //seçilen id de bulunan Vehicles içerisinde bağlı durumunu false çek ardından bu gelen iddeki veriyi TerminationDate kısmına now bas ve bunu da update yap 

            try
            {
                _serviceManager.driverVehicleService.DeleteDiverVehicle(id);
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
