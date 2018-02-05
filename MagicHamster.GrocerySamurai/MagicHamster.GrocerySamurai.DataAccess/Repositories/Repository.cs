namespace MagicHamster.GrocerySamurai.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
    using MagicHamster.GrocerySamurai.Model.Common;
    using Microsoft.EntityFrameworkCore;

    public class Repository<T> : IRepository<T>, IDisposable
        where T : Entity
    {
        private readonly CancellationTokenSource _disposeCts = new CancellationTokenSource();

        internal Repository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        ~Repository()
        {
            Dispose(false);
        }

        private DbContext Context { get; }

        public async Task<T> Get(int id, List<string> childProperties = null, bool noTracking = false)
        {
            var result = Context.Set<T>().AsQueryable();

            if (noTracking)
            {
                result = result.AsNoTracking();
            }

            await loadChildProperties(childProperties, result).ConfigureAwait(false);

            return await result.FirstOrDefaultAsync(r => r.Id == id, _disposeCts.Token).ConfigureAwait(false);
        }

        public async Task<IQueryable<T>> Get(Expression<Func<T, bool>> where = null, List<string> childProperties = null, bool noTracking = false)
        {
            var result = Context.Set<T>().AsQueryable();

            if (where != null)
            {
                result = result.Where(where);
            }

            if (noTracking)
            {
                result = result.AsNoTracking();
            }

            await loadChildProperties(childProperties, result).ConfigureAwait(false);

            return result;
        }

        public Task Add(T entity)
        {
            return Context.Set<T>().AddAsync(entity, _disposeCts.Token);
        }

        public Task Add(IEnumerable<T> entities)
        {
            return Context.Set<T>().AddRangeAsync(entities, _disposeCts.Token);
        }

        public Task Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task Update(int id)
        {
            await Update(await Get(id).ConfigureAwait(false)).ConfigureAwait(false);
        }

        public async Task Update(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                return;
            }

            foreach (var entity in entities)
            {
                await Update(entity).ConfigureAwait(false);
            }
        }

        public async Task Update(Expression<Func<T, bool>> where)
        {
            await Update(await Get(where).ConfigureAwait(false)).ConfigureAwait(false);
        }

        public Task Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            await Delete(await Get(id).ConfigureAwait(false)).ConfigureAwait(false);
        }

        public async Task Delete(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                return;
            }

            foreach (var entity in entities)
            {
                await Delete(entity).ConfigureAwait(false);
            }
        }

        public async Task Delete(Expression<Func<T, bool>> where)
        {
            await Delete(await Get(where).ConfigureAwait(false)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // ReSharper disable once InconsistentNaming
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposeCts.Cancel();
                _disposeCts.Dispose();
                Context?.Dispose();
            }
        }

        private async Task loadChildProperties(IReadOnlyCollection<string> childProperties, IQueryable<T> result)
        {
            if (childProperties == null)
            {
                return;
            }

            foreach (var child in childProperties)
            {
                await result.Include(child).LoadAsync(_disposeCts.Token).ConfigureAwait(false);
            }
        }
    }
}
