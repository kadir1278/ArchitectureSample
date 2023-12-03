using BusinessLayer.Abstract;
using CoreLayer.Entity.Dtos;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using CoreLayer.Utilities.Security.Hashing;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.User.Request;
using EntityLayer.Dto.User.Response;

namespace BusinessLayer.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserDal _userDal;
        private readonly ITokenHelper _tokenHelper;

        public AuthenticationService(IUserDal userDal, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
        }


        public IDataResult<UserLoginResponseDto> Login(UserLoginRequestDto userLoginRequestDto)
        {
            var userToCheck = _userDal.Queryable().Where(x => x.Username == userLoginRequestDto.Username).FirstOrDefault();
            if (userToCheck is null)
                return new ErrorDataResult<UserLoginResponseDto>("Kullanıcı Bulunamadı");

            if (!HashingHelper.VerifyPasswordHash(userLoginRequestDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                return new ErrorDataResult<UserLoginResponseDto>("Şifre hatalı");

            List<OperationClaimDto> operationClaimDtos = new List<OperationClaimDto>();
            operationClaimDtos.Add(new OperationClaimDto()
            {
                Id = 0,
                Name = "Admin"
            });

            var accessToken = _tokenHelper.CreateToken(userToCheck, operationClaimDtos);


            return new SuccessDataResult<UserLoginResponseDto>(new UserLoginResponseDto()
            {
                Expiration = accessToken.Expiration,
                Token = accessToken.Token,
                Username = userToCheck.Username,
            });
        }
    }
}
