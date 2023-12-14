using AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.User;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using CoreLayer.Utilities.Security.Hashing;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.User.Request;
using EntityLayer.Dto.User.Response;
using EntityLayer.Entity;
using Mapster;

namespace BusinessLayer.Concrete
{
    public class UserService : IUserService
    {
        private readonly IWorker _worker;
        private readonly IUserDal _userDal;
        private readonly CancellationToken _ct;

        public UserService(IWorker worker, IUserDal userDal)
        {
            _worker = worker;
            _userDal = userDal;
        }


        [ValidateOperationAspect(typeof(UserAddDtoValidator))]
        public async Task<IDataResult<UserAddResponseDto>> AddUser(UserAddRequestDto userAddDto)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();

                User user = userAddDto.Adapt<User>();

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userAddDto.Password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                user.CompanyId = Guid.Parse("2a5b5a23-7534-4c01-bd22-fc6f436adfbe");
                var addedUser = await _userDal.Add(user, _ct);
                if (!addedUser.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<UserAddResponseDto>("Kullanıcı eklenemedi");
                }
                _worker.CommitAndSaveChangesAsync();
                return new SuccessDataResult<UserAddResponseDto>(addedUser.Data.Adapt<UserAddResponseDto>());
            }
            catch (Exception ex)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<UserAddResponseDto>(ex);
            }
        }

        public IDataResult<ICollection<UserListResponseDto>> GetUserCollection()
        {
            try
            {

                _ct.ThrowIfCancellationRequested();
                var getUser = _userDal.Queryable().ToList();

                if (getUser is null) return new ErrorDataResult<ICollection<UserListResponseDto>>(String.Join("-", "Kullanıcı bulunamadı"));
                return new SuccessDataResult<ICollection<UserListResponseDto>>(getUser.Adapt<ICollection<UserListResponseDto>>());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
