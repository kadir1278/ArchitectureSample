using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
