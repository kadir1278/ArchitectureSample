using BusinessLayer.Abstract;
using EntityLayer.Dto.Company;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("list")]
        public object List() => _companyService.GetCompanyCollection();

        [HttpGet("getbyid")]
        public object GetById(Guid id) => _companyService.GetCompanyById(id);

        [HttpPost("add")]
        public object Add(CompanyAddDto model) => _companyService.AddCompany(model);
    }
}
