using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.ProjectOwner;
using EntityLayer.Dto.User;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        public IDataResult<User> AddUser(UserAddDto userAddDto);
        public IDataResult<bool> DeleteUser(Guid userId);
        public IDataResult<User> GetUser(Guid userId);
        public IDataResult<bool> ActiveStatusToUser(Guid userId);
        public IDataResult<bool> DeactiveStatusToUser(Guid userId);
        public IDataResult<ICollection<User>> GetUserCollection();
    }
}
