using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly CancellationTokenSource _disposeCts = new CancellationTokenSource();


        public UnitOfWork(DbContext context, bool autoCommit = true)
        {
            Context = context;
            AutoCommit = autoCommit;
            _repositories = new Dictionary<Type, object>();
        }

        public Task<IRepository<T>> GetRepository<T>()
            where T : Entity
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                _repositories[typeof(T)] = new Repository<T>(Context);
            }
            return Task.FromResult((IRepository<T>) _repositories[typeof(T)]);
        }

        public Task Commit()
        {
            if (_transactions.Count > 0)
            {
                _transactions.Pop().Commit();
            }

            return Task.CompletedTask;
        }

        public Task Rollback()
        {
            if (_transactions.Count > 0)
            {
                _transactions.Pop().Rollback();
            }

            return Task.CompletedTask;
        }

        public Task CommitAll()
        {
            while (_transactions.Count > 0)
            {
                Commit();
            }

            return Task.CompletedTask;
        }

        public Task RollbackAll()
        {
            while (_transactions.Count > 0)
            {
                Rollback();
            }

            return Task.CompletedTask;
        }

        public async Task<int> Save()
        {
            return await Context.SaveChangesAsync(_disposeCts.Token);
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

            _disposeCts.Cancel();
            Context.Dispose();
        }
    }
}
