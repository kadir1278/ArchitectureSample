using BusinessLayer.Abstract;
using EntityLayer.Dto.User;
using EntityLayer.Dto.ValidationRule;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationRuleController : ControllerBase
    {
        private readonly IValidationRulesService _validationRulesService;
        public ValidationRuleController(IValidationRulesService validationRulesService)
        {
            _validationRulesService = validationRulesService;
        }

        [HttpGet("list")]
        public object ListUser() => _validationRulesService.GetValidationRuleCollection();

        [HttpPost("add")]
        public object AddUser(ValidationRuleAddDto model) => _validationRulesService.AddValidationRules(model);
    }
}
