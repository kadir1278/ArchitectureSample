using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Dto.ValidationRule;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfValidationRuleDal : EfEntityRepository<ValidationRule, ValidationRuleAddDto, ValidationRuleUpdateDto, ValidationRuleGetDto, SystemContext>, IValidationRuleDal
    {
        public EfValidationRuleDal(SystemContext context) : base(context)
        {
        }
    }
}
