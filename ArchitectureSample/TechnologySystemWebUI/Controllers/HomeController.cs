using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace TechnologySystemWebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
