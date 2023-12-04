using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
