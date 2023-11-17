using BusinessLayer.Abstract;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.User;
using EntityLayer.Entity;

namespace BusinessLayer.Concrete
{
    public class UserService : IUserService
    {
        private readonly IWorker _worker;
        private readonly IProjectOwnerService _projectOwnerService;
        private readonly CancellationToken _ct;

        public UserService(IWorker worker, IProjectOwnerService projectOwnerService)
        {
            _worker = worker;
            _projectOwnerService = projectOwnerService;
        }
        public IDataResult<bool> ActiveStatusToUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> AddUser(UserAddDto userAddDto)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();

                var projectOwner = _projectOwnerService.GetProjectOwnerByRequestDomain();
                if (!projectOwner.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<User>("Domain kaydı bulunamadı");
                }
                userAddDto.ProjectOwnerId = projectOwner.Data.Id;
                var addedUser = _worker.UserDal.Add(userAddDto, _ct);
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

        public IDataResult<bool> DeactiveStatusToUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<bool> DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetUser(Guid userId)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getUser = _worker.UserDal.Queryable().Where(x => x.Id == userId).FirstOrDefault();

                if (getUser is null)
                    return new ErrorDataResult<User>(String.Join("-", "Kullanıcı bulunamadı"));

                return new SuccessDataResult<User>(getUser);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<User>(ex);
            }
        }

        public IDataResult<ICollection<User>> GetUserCollection()
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getUser = _worker.UserDal.Queryable().ToList();

                if (getUser is null)
                    return new ErrorDataResult<ICollection<User>>(String.Join("-", "Kullanıcı bulunamadı"));

                return new SuccessDataResult<ICollection<User>>(getUser);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ICollection<User>>(ex);
            }
        }
    }
}
