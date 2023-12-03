using CoreLayer.DataAccess.Abstract;
using EntityLayer.Entity;

namespace DataAccessLayer.Absctract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
