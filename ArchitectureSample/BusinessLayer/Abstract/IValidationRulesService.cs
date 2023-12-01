using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.User;
using EntityLayer.Dto.ValidationRule;
using EntityLayer.Dto.ValidationRule.Request;
using EntityLayer.Dto.ValidationRule.Response;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface IValidationRulesService
    {
        public IDataResult<ValidationRuleAddResponseDto> AddValidationRules(ValidationRuleAddRequestDto validationRuleAddDto);
        public IDataResult<ICollection<ValidationRuleListResponseDto>> GetValidationRuleCollection();
        public IDataResult<ICollection<ValidationRuleListResponseDto>> GetValidationRuleByValidatorName(Type validatorType);
    }
}
