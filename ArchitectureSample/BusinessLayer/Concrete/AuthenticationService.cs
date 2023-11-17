using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using EntityLayer.ViewModel.Authentication;

namespace BusinessLayer.Concrete
{
    public class AuthenticationService : Abstract.IAuthenticationService
    {
        private readonly IWorker _worker;
        private readonly CancellationToken _ct;

        public AuthenticationService(IWorker worker)
        {
            _worker = worker;
        }

        public IDataResult<LoginResponseViewModel> Login(string username, string password)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();

                var user = _worker.UserDal.Queryable().Where(x => x.Username == username && x.Password == password).FirstOrDefault();
                if (user is null)
                    return new ErrorDataResult<LoginResponseViewModel>("Kullanıcı giriş işlemi başarısız");

                if (!user.IsActive)
                    return new ErrorDataResult<LoginResponseViewModel>("Kullanıcı aktif değil yöneticinizle görüşünüz");

                return new SuccessDataResult<LoginResponseViewModel>(new LoginResponseViewModel()
                {
                    Token = "token buraya gelecek",
                    TokenEndTime = DateTime.UtcNow, // token bitiş süresi buraya gelecek
                });
            }
            catch (Exception exception)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<LoginResponseViewModel>(exception);
            }

        }

        public IDataResult<bool> Logout(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
