using EntitiesLayer.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Abstract;
using ServicesLayer.ServiceManager;

namespace Uwingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ServicesLayer.Abstract.IAuthenticationService _serviceManager;
        private ILogger<AuthenticationController> _logger;

        public AuthenticationController(ServicesLayer.Abstract.IAuthenticationService serviceManagers, ILogger<AuthenticationController> logger)
        {
            _serviceManager = serviceManagers;
            _logger = logger;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDTO user)
        {
            if (!await _serviceManager.ValidateUser(user))
                return Unauthorized();
            var tokenDto = await _serviceManager.CreateToken(populateExp: true);

            return Ok(tokenDto);
        }
        [HttpPost("refrash")]
        public async Task<IActionResult> Refresh(TokenDTO tokenDto)
        {
            var tokenDtoToReturn = await _serviceManager.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }
        [HttpGet("get-cliams")]
        public async Task<IActionResult> GetCliams(string userName)
        {
         var user=  await _serviceManager.GetUserByUserName(userName);
         var claims=  await  _serviceManager.GetClaimsByUser(user);
         return Ok(claims);
        }

    }
}
