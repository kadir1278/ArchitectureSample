using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfProjectDal : EfEntityRepository<Project, SystemContext>, IProjectDal
    {
        public EfProjectDal(SystemContext context) : base(context)
        {

        }
    }
}
