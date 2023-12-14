using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfRoleDal : EfEntityRepository<Role, SystemContext>, IRoleDal
    {
        public EfRoleDal(SystemContext context) : base(context)
        {

        }
    }
}
