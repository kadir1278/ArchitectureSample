using BusinessLayer.Abstract;
using CoreLayer.Helper;
using CoreLayer.IoC;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Dto.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Security.Claims;

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
                string name = EncryptionHelper.DecryptPassword("wLvAweZ/SsiXRncEcKmk4A==");
                _worker.StartTransaction();
                var tcmb = _worker.TcmbExchangeService.GetAllTcmbExchanges();
                var nlrdw = _worker.NetherlandRdwService.GetInfoByPlate("PV130F");
                var model = _worker.UserDal.Queryable().ToList();

                var addedModel = _worker.UserDal.Add(new UserAddDto
                {
                    Name = "Kadir",
                    Surname = "Ari",
                    Password = password,
                    Username = username,
                }, _ct);

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
