using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfDomainDal : EfEntityRepository<Domain, SystemContext>, IDomainDal
    {
        public EfDomainDal(SystemContext context) : base(context)
        {

        }
    }
}
