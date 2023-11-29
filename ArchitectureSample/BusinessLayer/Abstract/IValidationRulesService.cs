using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.User;
using EntityLayer.Dto.ValidationRule;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface IValidationRulesService
    {
        public IDataResult<ValidationRule> AddValidationRules(ValidationRuleAddDto validationRuleAddDto);
        public IDataResult<ICollection<ValidationRule>> GetValidationRuleCollection();
        public IDataResult<ICollection<ValidationRule>> GetValidationRuleByValidatorName(Type validatorType);
    }
}
