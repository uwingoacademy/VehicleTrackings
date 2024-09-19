using EntitiesLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingDataForAccController : ControllerBase
    {
        private IServiceManager _serviceManager;
        private ILogger<TrackingDataForAccController> _logger;

        public TrackingDataForAccController(IServiceManager serviceManager, ILogger<TrackingDataForAccController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTrackingDataForAcc()
        {
            try
            {
                var data = await _serviceManager.trackingDataForACCService.GetAllTarckingDataAcc();
                return Ok(data);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetByIdTrackingDataForAcc(int id)
        {
            try
            {
                var data = _serviceManager.trackingDataForACCService.GetByIdTrackingDataForAcc(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPut]
        public IActionResult UpdateTrackingDataForAcc(TrackingDataForACCDTO trackingDataFor)
        {
            try
            {
                _serviceManager.trackingDataForACCService.UpdateTrackingDataForAcc(trackingDataFor);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateTrackingDataForAcc(TrackingDataForACCDTO trackingDataFor)
        {
            try
            {
                await _serviceManager.trackingDataForACCService.CreateTrackingDataForAcc(trackingDataFor);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpDelete]
        public IActionResult DeleteTrackingDataForAcc(int id)
        {

            try
            {
                _serviceManager.trackingDataForACCService.DeleteTrackingDataForAcc(id);
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
