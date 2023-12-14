using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfProjectDomainActivityStatusHistoryDal : EfEntityRepository<ProjectDomainActivityStatusHistory, SystemContext>, IProjectDomainActivityStatusHistoryDal
    {
        public EfProjectDomainActivityStatusHistoryDal(SystemContext context) : base(context)
        {

        }
    }
}
