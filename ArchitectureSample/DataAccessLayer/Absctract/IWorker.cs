using CoreLayer.Business.Abstract;
using CoreLayer.DataAccess.Abstract;
using DataAccessLayer.Context;

namespace DataAccessLayer.Absctract
{
    public interface IWorker : IDisposable
    {
        IUserDal UserDal { get; }
        ITCMBExchangeService TcmbExchangeService { get; }
        INetherlandRdwService NetherlandRdwService { get; }

        public void StartTransaction();
        public void SaveChanges();
        public void RollbackTransaction();
        public void DisposeTransaction();
    }
}
