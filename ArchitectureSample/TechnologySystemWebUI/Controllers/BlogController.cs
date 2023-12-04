using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
