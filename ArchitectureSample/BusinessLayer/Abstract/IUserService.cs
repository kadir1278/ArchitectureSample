using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.User;
using EntityLayer.Dto.User.Request;
using EntityLayer.Dto.User.Response;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        public IDataResult<UserAddResponseDto> AddUser(UserAddRequestDto userAddDto);
        public IDataResult<ICollection<UserListResponseDto>> GetUserCollection();
    }
}
