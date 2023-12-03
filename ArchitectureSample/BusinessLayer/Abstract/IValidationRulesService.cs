using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.ValidationRule.Request;
using EntityLayer.Dto.ValidationRule.Response;

namespace BusinessLayer.Abstract
{
    public interface IValidationRulesService
    {
        public IDataResult<ValidationRuleAddResponseDto> AddValidationRules(ValidationRuleAddRequestDto validationRuleAddDto);
        public IDataResult<ICollection<ValidationRuleListResponseDto>> GetValidationRuleCollection();
        public IDataResult<ICollection<ValidationRuleListResponseDto>> GetValidationRuleByValidatorName(Type validatorType);
    }
}
