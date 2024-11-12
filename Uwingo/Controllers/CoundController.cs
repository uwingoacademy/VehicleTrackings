using EntitiesLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoundController : ControllerBase
    {
        private IServiceManager _serviceManager;
        private ILogger<CoundController> _logger;

        public CoundController(IServiceManager serviceManager, ILogger<CoundController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [Authorize(Policy = "GetCount")]
        [HttpGet("get-cound")]
        public async Task<CoundDTO> GetCound() 
        {
            var counds=  await  _serviceManager.coundService.GetCoundAsycn();
            return counds;
        }
    }
}
