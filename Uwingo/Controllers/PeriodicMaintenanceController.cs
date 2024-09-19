using EntitiesLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodicMaintenanceController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILogger<PeriodicMaintenanceController> _logger;

        public PeriodicMaintenanceController(IServiceManager serviceManager, ILogger<PeriodicMaintenanceController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("get-periodicmaintenance")]
        public async Task<List<PeriodicMaintenanceDTO>> GetAllPeriodicMaintenance()
        {
            try
            {
                var periodic = await _serviceManager.periodicMaintenance.GetAllPeriodicMaintenance();
                return periodic.ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new List<PeriodicMaintenanceDTO>();
            }

        }
        [HttpGet("{id}")]
        public async Task<PeriodicMaintenanceDTO> GetByIdPeriodicMaintenance(int id)
        {
            try
            {
                var periodic = await _serviceManager.periodicMaintenance.GetByIdPeriodicMaintenance(id);
                //bakıma kalan gün sayısı
                TimeSpan difference = periodic.NextMaintenanceDate.Value - periodic.LastMaintenanceDate;
                var day = difference.Days;
                return periodic;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new PeriodicMaintenanceDTO();
            }

        }
        [HttpPut("update-periodicmaintenance")]
        public IActionResult UpdatePeriodicMaintenance(PeriodicMaintenanceDTO periodicDTO)
        {
            try
            {
                _serviceManager.periodicMaintenance.UpdatePeriodicMaintenance(periodicDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpDelete("delete-periodicmaintenance/{id}")]
        public IActionResult DeletePeriodicMaintenance(int id)
        {
            try
            {
                _serviceManager.periodicMaintenance.DeletePeriodicMaintenance(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }

        }
        [HttpPost("create-periodicmaintenance")]
        public async Task<IActionResult> CreatePeriodicMaintenance(PeriodicMaintenanceDTO periodicDTO)
        {
            try
            {
                await _serviceManager.periodicMaintenance.CreatePeriodicMaintenance(periodicDTO);
                return Ok(periodicDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }

        }
    }
}
