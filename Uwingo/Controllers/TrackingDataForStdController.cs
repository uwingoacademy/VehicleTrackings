using EntitiesLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingDataForStdController : ControllerBase
    {
        private IServiceManager _serviceManager;
        private ILogger<TrackingDataForStdController> _logger;

        public TrackingDataForStdController(IServiceManager serviceManager, ILogger<TrackingDataForStdController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTrackingDataForStd()
        {
            try
            {
                var data = await _serviceManager.trackingDataForSTDService.GetAllTrackingDataForStd();
                return Ok(data);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetByIdTrackingDataForStd(int id)
        {
            try
            {
                var data = _serviceManager.trackingDataForSTDService.GetByIdTrackingDataForStd(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPut]
        public IActionResult UpdateTrackingDataForStd(TrackingDataForSTDDTO trackingData)
        {
            try
            {
                _serviceManager.trackingDataForSTDService.UpdateTrackingDataForStd(trackingData);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateTrackingDataForStd(TrackingDataForSTDDTO trackingData)
        {
            try
            {
                await _serviceManager.trackingDataForSTDService.CreateTrackingDataForStd(trackingData);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpDelete]
        public IActionResult DeleteTrackingDataForStd(int id)
        {

            try
            {
                _serviceManager.trackingDataForSTDService.DeleteTrackingDataForStd(id);
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
