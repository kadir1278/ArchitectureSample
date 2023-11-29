using CoreLayer.DataAccess.Abstract;
using EntityLayer.Dto.ValidationRule;
using EntityLayer.Entity;

namespace DataAccessLayer.Absctract
{
    public interface IValidationRuleDal : IEntityRepository<ValidationRule, ValidationRuleAddDto, ValidationRuleUpdateDto, ValidationRuleGetDto>
    {

    }
}
