using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
