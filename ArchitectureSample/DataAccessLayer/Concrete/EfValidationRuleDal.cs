using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfValidationRuleDal : EfEntityRepository<ValidationRule,  SystemContext>, IValidationRuleDal
    {
        public EfValidationRuleDal(SystemContext context) : base(context)
        {
        }
    }
}
