using AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.User;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.User;
using EntityLayer.Entity;
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
        public IDataResult<User> AddUser(UserAddDto userAddDto)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();

                var addedUser = _userDal.Add(userAddDto, _ct);
                if (!addedUser.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<User>("Kullanıcı eklenemedi");
                }
                _worker.CommitAndSaveChanges();
                return addedUser;
            }
            catch (Exception ex)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<User>(ex);
            }
        }

        [IpCheckOperationAspect]
        public IDataResult<ICollection<User>> GetUserCollection()
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getUser = _userDal.QueryableGlobalFilter().ToList();

                if (getUser is null) return new ErrorDataResult<ICollection<User>>(String.Join("-", "Kullanıcı bulunamadı"));
                return new SuccessDataResult<ICollection<User>>(getUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
