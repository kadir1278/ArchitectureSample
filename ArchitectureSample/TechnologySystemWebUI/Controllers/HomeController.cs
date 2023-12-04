using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace TechnologySystemWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var dll = Assembly.Load("Path/to/file.dll"); 
            
            var result = _userService.GetUserCollection();
            return View(result);
        }


    }
}
