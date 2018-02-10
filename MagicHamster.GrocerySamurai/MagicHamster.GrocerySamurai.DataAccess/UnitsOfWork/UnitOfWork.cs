namespace MagicHamster.GrocerySamurai.DataAccess.UnitsOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Model.Common;
    using Repositories;

    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories;
        private readonly Stack<IDbContextTransaction> _transactions = new Stack<IDbContextTransaction>();
        private readonly CancellationTokenSource _disposeCts = new CancellationTokenSource();

        public UnitOfWork(DbContext context, bool autoCommit = true)
        {
            Context = context;
            AutoCommit = autoCommit;
            _repositories = new Dictionary<Type, object>();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public DbContext Context { get; }

        public bool AutoCommit { get; set; }

        public Task<IRepository<T>> GetRepository<T>()
            where T : Entity
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                _repositories[typeof(T)] = new Repository<T>(Context);
            }

            return Task.FromResult((IRepository<T>)_repositories[typeof(T)]);
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

        public Task<int> Save()
        {
            return Context.SaveChangesAsync(_disposeCts.Token);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // ReSharper disable once InconsistentNaming
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

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
            _disposeCts.Dispose();
            Context.Dispose();
        }
    }
}
