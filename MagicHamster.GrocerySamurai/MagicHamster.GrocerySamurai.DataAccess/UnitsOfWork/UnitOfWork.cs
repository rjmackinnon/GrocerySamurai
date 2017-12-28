using System;
using System.Collections.Generic;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.DataAccess.Repositories;
using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MagicHamster.GrocerySamurai.DataAccess.UnitsOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public DbContext Context { get; }

        public bool AutoCommit { get; set; }

        private readonly Dictionary<Type, object> _repositories;
        private readonly Stack<IDbContextTransaction> _transactions = new Stack<IDbContextTransaction>();

        public UnitOfWork(DbContext context, bool autoCommit = true)
        {
            Context = context;
            AutoCommit = autoCommit;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>()
            where T : Entity
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                _repositories[typeof(T)] = new Repository<T>(Context);
            }
            return (IRepository<T>) _repositories[typeof(T)];
        }

        public void Commit()
        {
            if (_transactions.Count > 0)
            {
                _transactions.Pop().Commit();
            }
        }

        public void Rollback()
        {
            if (_transactions.Count > 0)
            {
                _transactions.Pop().Rollback();
            }
        }

        public void CommitAll()
        {
            while (_transactions.Count > 0)
            {
                Commit();
            }
        }

        public void RollbackAll()
        {
            while (_transactions.Count > 0)
            {
                Rollback();
            }
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context == null)
            {
                return;
            }

            if (AutoCommit)
            {
                CommitAll();
            }
            else
            {
                if (_transactions.Count > 0)
                {
                    throw new Exception("UnitOfWork ended with open transactions");
                }
            }

            Context.Dispose();
        }
    }
}
