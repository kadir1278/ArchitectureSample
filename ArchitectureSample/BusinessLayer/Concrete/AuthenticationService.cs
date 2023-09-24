using BusinessLayer.Abstract;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Absctract;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IWorker _systemContextWorker;
        public AuthenticationService(IWorker systemContextWorker)
        {
            _systemContextWorker = systemContextWorker;
        }

        public IDataResult<bool> Login(string username, string password)
        {
            try
            {
                _systemContextWorker.StartTransaction();
                var model = _systemContextWorker.UserDal.Queryable().ToList();
                _systemContextWorker.Dispose();
                return new SuccessDataResult<bool>(true);
            }
            catch (Exception exception)
            {
                _systemContextWorker.RollbackTransaction();
                return new ErrorDataResult<bool>(exception);
            }
            
        }

        public IDataResult<bool> Logout(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
