using Microsoft.EntityFrameworkCore;

namespace CoreLayer.DataAccess.Abstract
{
    public interface IWorker<TContext> : IDisposable where TContext : DbContext, new()
    {

        public void StartTransaction();
        public void RollbackTransaction();
        public void DisposeTransaction();
       

    }
}
