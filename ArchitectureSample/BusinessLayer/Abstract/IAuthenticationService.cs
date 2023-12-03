using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.User.Request;
using EntityLayer.Dto.User.Response;

namespace BusinessLayer.Abstract
{
    public interface IAuthenticationService
    {
        IDataResult<UserLoginResponseDto> Login(UserLoginRequestDto reconciliationForLoginDto);
    }
}
