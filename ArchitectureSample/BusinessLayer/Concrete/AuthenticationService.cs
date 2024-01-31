using BusinessLayer.Abstract;
using CoreLayer.Entity.Dtos;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using CoreLayer.Utilities.Security.Hashing;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.User.Request;
using EntityLayer.Dto.User.Response;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserDal _userDal;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserRoleDal _userRoleDal;

        public AuthenticationService(IUserDal userDal, ITokenHelper tokenHelper, IUserRoleDal userRoleDal)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _userRoleDal = userRoleDal;
        }

        [EnableRateLimiting("AuthLimit")]
        public IDataResult<UserLoginResponseDto> Login(UserLoginRequestDto userLoginRequestDto)
        {
            var userToCheck = _userDal.Queryable()
                                      .Where(x => x.Username == userLoginRequestDto.Username)
                                      .FirstOrDefault();

            if (userToCheck is null)
                return new ErrorDataResult<UserLoginResponseDto>("Kullanıcı Bulunamadı");

            if (!HashingHelper.VerifyPasswordHash(userLoginRequestDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                return new ErrorDataResult<UserLoginResponseDto>("Şifre hatalı");

            var userRole = _userRoleDal.Queryable()
                                       .Where(x => x.UserId == userToCheck.Id)
                                       .Include(x => x.Role)
                                       .ThenInclude(x => x.RolePermissions)
                                       .ThenInclude(x => x.Permission)
                                       .SelectMany(x => x.Role.RolePermissions.Select(y => new OperationClaimDto()
                                       {
                                           Id = y.PermissionId,
                                           Name = y.Permission.Name
                                       }))
                                       .ToList();

            userRole.Add(new OperationClaimDto()
            {
                Id = Guid.NewGuid(),
                Name = "Admin"
            });
            var accessToken = _tokenHelper.CreateToken(userToCheck, userRole);

            return new SuccessDataResult<UserLoginResponseDto>(new UserLoginResponseDto()
            {
                Expiration = accessToken.Expiration,
                Token = accessToken.Token,
                Username = userToCheck.Username,
                OperationClaimDtos = userRole
            });
        }
    }
}
