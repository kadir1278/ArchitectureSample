using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfRolePermissionDal : EfEntityRepository<RolePermission, SystemContext>, IRolePermissionDal
    {
        public EfRolePermissionDal(SystemContext context) : base(context)
        {
        }
    }
}
