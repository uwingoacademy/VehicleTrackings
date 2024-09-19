using EntitiesLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacketsController : ControllerBase
    {
        private IServiceManager _serviceManager;
        private ILogger<PacketsController> _logger;

        public PacketsController(IServiceManager serviceManager, ILogger<PacketsController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("get-packet")]
        public async Task<IActionResult> GetAllPacket()
        {
          
            try
            {
                var packet = await _serviceManager.packetsService.GetAllPackets();
                return Ok(packet);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetByIdPacket(int id)
        {
            try
            {
                var packet = _serviceManager.packetsService.GetByIdPacket(id);
                return Ok(packet);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPut("update-packet")]
        public IActionResult UpdatePacket(PacketsDTO packets)
        {
            try
            {
                _serviceManager.packetsService.UpdatePackets(packets);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPost("create-packet")]
        public async Task<IActionResult> CreatePacket(PacketsDTO packets)
        {
            try
            {
                await _serviceManager.packetsService.CreatePackets(packets);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpDelete("delete-driver/{id}")]
        public IActionResult DeletePacket(int id)
        {

            try
            {
                _serviceManager.packetsService.DeletePackets(id);
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
