using CoreLayer.DataAccess.Abstract;
using EntityLayer.Dto.User;
using EntityLayer.Entity;

namespace DataAccessLayer.Absctract
{
    public interface IUserDal : IEntityRepository<User, UserAddDto, UserUpdateDto, UserGetDto>
    {
    }
}
