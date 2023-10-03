using BusinessLayer.Abstract;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Absctract;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IWorker _worker;
        public AuthenticationService(IWorker worker)
        {
            _worker = worker;
        }

        public IDataResult<bool> Login(string username, string password)
        {
            try
            {
                _worker.StartTransaction();
                var tcmb=_worker.TcmbExchangeService.GetAllTcmbExchanges();
                var model = _worker.UserDal.Queryable().ToList();
                return new SuccessDataResult<bool>(true);
            }
            catch (Exception exception)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<bool>(exception);
            }
            
        }

        public IDataResult<bool> Logout(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
