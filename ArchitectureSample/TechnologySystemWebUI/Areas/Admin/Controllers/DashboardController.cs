using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TechnologySystemWebUI.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
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
