using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Dto.User;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfUserDal : EfEntityRepository<User, SystemContext>, IUserDal
    {
        public EfUserDal(SystemContext context) : base(context)
        {

        }
    }
}
