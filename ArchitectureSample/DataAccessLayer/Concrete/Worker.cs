using CoreLayer.IoC;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Concrete
{
    public class Worker : IWorker
    {
        public IDbContextTransaction _transaction;
        public SystemContext _context;

        public Worker()
        {
            _context = ServiceTool.ServiceProvider.GetRequiredService<SystemContext>();
        }

        public void StartTransaction() => _transaction = _context.Database.BeginTransaction();

        public void RollbackTransaction()
        {

            if (_transaction is null) { return; }
            _transaction.Rollback();
            _transaction.DisposeAsync();
            _transaction.Dispose();
        }

        public void DisposeTransaction()
        {
            if (_transaction is not null) _transaction.Dispose();
            _transaction = null;
            _context.Dispose();
        }

        public void Dispose() => _context.Dispose();

        public void CommitAndSaveChanges()
        {
            _transaction.Commit();
            _context.SaveChanges();
            if (_transaction is not null) _transaction.Dispose();
            _transaction = null;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
            if (_transaction is not null) _transaction.Dispose();
            _transaction = null;
        }
       

    }
}
