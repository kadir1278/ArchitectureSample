using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfPermissionDal : EfEntityRepository<Permission, SystemContext>, IPermissionDal
    {
        public EfPermissionDal(SystemContext context) : base(context)
        {

        }
    }
}
