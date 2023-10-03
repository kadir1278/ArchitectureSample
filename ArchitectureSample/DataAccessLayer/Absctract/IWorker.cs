using CoreLayer.Business.Abstract;
using CoreLayer.DataAccess.Abstract;
using DataAccessLayer.Context;

namespace DataAccessLayer.Absctract
{
    public interface IWorker : IDisposable
    {
        IUserDal UserDal { get; }
        ITCMBExchangeService TcmbExchangeService { get; }

        public void StartTransaction();
        public void RollbackTransaction();
        public void DisposeTransaction();
    }
}
