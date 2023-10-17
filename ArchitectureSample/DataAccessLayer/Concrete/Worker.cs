using CoreLayer.Business.Abstract;
using CoreLayer.Business.Concrete;
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

        public void CommitAndSaveChanges()
        {
            _transaction.Commit();
            _context.SaveChanges();
            if (_transaction != null) _transaction.Dispose();
            _transaction = null;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
            if (_transaction != null) _transaction.Dispose();
            _transaction = null;
        }
        private IUserDal _userDal;
        private ITCMBExchangeService _exchangeService;
        private INetherlandRdwService _netherlandRdwService;
        private IProjectOwnerDal _projectOwnerDal;
        private ICompanyDal _companyDal;

        public IUserDal UserDal
        {
            get
            {
                if (_userDal != null)
                    return _userDal;

                _userDal = new EfUserDal(_context);
                return _userDal;
            }
        }

        public ITCMBExchangeService TcmbExchangeService
        {
            get
            {
                if (_exchangeService != null)
                    return _exchangeService;

                _exchangeService = new TCMBExchangeService();
                return _exchangeService;
            }
        }
        public INetherlandRdwService NetherlandRdwService
        {
            get
            {
                if (_netherlandRdwService != null)
                    return _netherlandRdwService;

                _netherlandRdwService = new NetherlandRdwService();
                return _netherlandRdwService;
            }
        }
        public IProjectOwnerDal ProjectOwnerDal
        {
            get
            {
                if (_projectOwnerDal != null)
                    return _projectOwnerDal;

                _projectOwnerDal = new EfProjectOwnerDal(_context);
                return _projectOwnerDal;
            }
        }
        public ICompanyDal CompanyDal
        {
            get
            {
                if (_companyDal != null)
                    return _companyDal;

                _companyDal = new EfCompanyDal(_context);
                return _companyDal;
            }
        }
    }
}
