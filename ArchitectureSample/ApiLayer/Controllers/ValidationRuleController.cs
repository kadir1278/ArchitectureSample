using BusinessLayer.Abstract;
using EntityLayer.Dto.ValidationRule.Request;
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
        public object AddUser(ValidationRuleAddRequestDto model) => _validationRulesService.AddValidationRules(model);
    }
}
