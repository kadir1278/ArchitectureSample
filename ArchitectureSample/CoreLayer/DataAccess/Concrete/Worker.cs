using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using CoreLayer.DataAccess.Abstract;

namespace CoreLayer.DataAccess.Concrete
{
    public class Worker<TContext> : IWorker<TContext> where TContext : DbContext, new()
    {
        public TContext _context { get; }
        public IDbContextTransaction _transaction;

        public void StartTransaction() => _transaction = _context.Database.BeginTransaction();

        public void RollbackTransaction()
        {

            if (_transaction == null) { return; }
            _transaction.Rollback();
            _transaction.DisposeAsync();
            _transaction.Dispose();


        }

        public void DisposeTransaction()
        {
            if (_transaction != null) _transaction.Dispose();
            _transaction = null;
            _context.Dispose();
        }

        public void Dispose() => _context.Dispose();
    }
}
