using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.User;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        public IDataResult<User> AddUser(UserAddDto userAddDto);
        public IDataResult<ICollection<User>> GetUserCollection();
    }
}
