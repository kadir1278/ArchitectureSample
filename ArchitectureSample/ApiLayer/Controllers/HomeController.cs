using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Guid _requestId;
        private readonly BusinessLayer.Abstract.IAuthenticationService _authenticationService;

        public HomeController(ILogger<HomeController> logger, BusinessLayer.Abstract.IAuthenticationService authenticationService)
        {
            _logger = logger;
            _requestId = Guid.NewGuid();
            _logger.LogInformation("Home Controller Called Request : {0}", _requestId);
            _authenticationService = authenticationService;
        }
        [HttpGet("get")]
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("Home Controller Get Index Started Request : {0}", _requestId);
                _authenticationService.Login("kadir", "ari");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " Request : {0}", _requestId);
                return BadRequest();
            }
            finally
            {
                _logger.LogInformation("Home Controller Get Index Finished Request : {0}", _requestId);
            }
        }

    }
}