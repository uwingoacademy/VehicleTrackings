using EntitiesLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacketContentController : ControllerBase
    {
        private IServiceManager _serviceManager;
        private ILogger<PacketContentController> _logger;

        public PacketContentController(IServiceManager serviceManager, ILogger<PacketContentController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("get-packetcontent")]
        public async Task<IActionResult> GetAllPacketContent()
        {
            try
            {
                var packet = await _serviceManager.packetContentService.GetAllPacketContect();
                return Ok(packet);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetByIdPacketContent(int id)
        {
            try
            {
                var packet = _serviceManager.packetContentService.GetByIdPacketContent(id);
                return Ok(packet);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPut("update-packetcontent")]
        public IActionResult UpdatePacketContent(PacketContentDTO packetContent)
        {
            try
            {
                _serviceManager.packetContentService.UpdatePacketContent(packetContent);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPost("create-packetcontent")]
        public async Task<IActionResult> CreatePacketContent(PacketContentDTO packetContent)
        {
            try
            {
                await _serviceManager.packetContentService.CreatePacketContent(packetContent);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpDelete("delete-packetcontent/{id}")]
        public IActionResult DeletePacketContent(int id)
        {

            try
            {
                _serviceManager.packetContentService.DeletePacketContent(id);
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
