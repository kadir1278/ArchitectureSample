using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
