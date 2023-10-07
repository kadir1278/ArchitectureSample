using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;

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

        public IDataResult<bool> Login(string username, string password)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();

                //var tcmb = _worker.TcmbExchangeService.GetAllTcmbExchanges();
                //var nlrdw = _worker.NetherlandRdwService.GetInfoByPlate("PV130F");
                //var model = _worker.UserDal.Queryable().ToList();
                //
                //var addedModel = _worker.UserDal.Add(new UserAddDto
                //{
                //    Name = "Kadir",
                //    Surname = "Ari",
                //    Password = password,
                //    Username = username,
                //}, _ct);
                //
                //TileMethots.SquareMeters(0.1m, 0m, 0m, 0m, 5);

                _worker.CommitAndSaveChanges();
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
