using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.User.Request;
using EntityLayer.Dto.User.Response;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        public Task<IDataResult<UserAddResponseDto>> AddUser(UserAddRequestDto userAddDto);
        public IDataResult<ICollection<UserListResponseDto>> GetUserCollection();
    }
}
