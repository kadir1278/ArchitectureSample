using CoreLayer.Business.Abstract;
using CoreLayer.Business.Concrete;
using CoreLayer.DataAccess.Abstract;
using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Dto;
using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Worker : IWorker
    {
        public IDbContextTransaction _transaction;
        public SystemContext _context;

        public Worker()
        {
            _context = new SystemContext();
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

        private IUserDal _userDal;
        private ITCMBExchangeService _exchangeService;

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

    }
}
