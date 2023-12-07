using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DashboardController : Controller
    {
        private readonly ICompanyService _companyService;

        public DashboardController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Route("admin/"), HttpGet]
        public IActionResult Index()
        {
            _companyService.GetCompanyCollection();
            return View();
        }
    }
}
