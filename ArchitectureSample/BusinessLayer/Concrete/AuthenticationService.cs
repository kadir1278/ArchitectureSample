using BusinessLayer.Abstract;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Absctract;

namespace BusinessLayer.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ISystemContextWorker _systemContextWorker;
        public AuthenticationService(ISystemContextWorker systemContextWorker)
        {
            _systemContextWorker = systemContextWorker;
        }

        public IDataResult<bool> Login(string username, string password)
        {
            try
            {
                _systemContextWorker.StartTransaction();

                return new SuccessDataResult<bool>(true);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<bool>(exception);
            }
            finally
            {
                _systemContextWorker.Dispose();
            }
        }

        public IDataResult<bool> Logout(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
