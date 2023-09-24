using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Guid _requestId;
        private readonly IAuthenticationService _authenticationService;

        public HomeController(ILogger<HomeController> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _requestId = Guid.NewGuid();
            _logger.LogInformation("Home Controller Called Request : {0}", _requestId);
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            try
            {
                _logger.LogInformation("Home Controller Get Index Started Request : {0}", _requestId);
                _authenticationService.Login("kadir", "ari");
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " Request : {0}", _requestId);
                return BadRequest();
            }
            _logger.LogInformation("Home Controller Get Index Finished Request : {0}", _requestId);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}