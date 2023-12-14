using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfUserRoleDal : EfEntityRepository<UserRole, SystemContext>, IUserRoleDal
    {
        public EfUserRoleDal(SystemContext context) : base(context)
        {
        }
    }
}
