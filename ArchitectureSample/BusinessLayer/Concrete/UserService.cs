using AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.User;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.User;
using EntityLayer.Dto.User.Request;
using EntityLayer.Dto.User.Response;
using EntityLayer.Entity;
using Mapster;
using System.Security;

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
        public IDataResult<UserAddResponseDto> AddUser(UserAddRequestDto userAddDto)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();

                User user = userAddDto.Adapt<User>();
                var addedUser = _userDal.Add(user, _ct);
                if (!addedUser.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<UserAddResponseDto>("Kullanıcı eklenemedi");
                }
                _worker.CommitAndSaveChanges();
                return new SuccessDataResult<UserAddResponseDto>(addedUser.Data.Adapt<UserAddResponseDto>());
            }
            catch (Exception ex)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<UserAddResponseDto>(ex);
            }
        }

        [IpCheckOperationAspect]
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
