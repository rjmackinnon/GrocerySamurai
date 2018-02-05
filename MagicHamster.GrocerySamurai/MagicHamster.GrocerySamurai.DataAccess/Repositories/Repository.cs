namespace MagicHamster.GrocerySamurai.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Model.Common;

    public class Repository<T> : IRepository<T>, IDisposable
        where T : Entity
    {
        private readonly CancellationTokenSource _disposeCts = new CancellationTokenSource();

        internal Repository(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        ~Repository()
        {
            Dispose(false);
        }

        private DbContext context { get; }

        public async Task<T> Get(int id, List<string> childProperties = null, bool noTracking = false)
        {
            var result = context.Set<T>().AsQueryable();

            if (noTracking)
            {
                result = result.AsNoTracking();
            }

            await loadChildProperties(childProperties, result).ConfigureAwait(false);

            return await result.FirstOrDefaultAsync(r => r.Id == id, _disposeCts.Token).ConfigureAwait(false);
        }

        public async Task<IQueryable<T>> Get(Expression<Func<T, bool>> where = null, List<string> childProperties = null, bool noTracking = false)
        {
            var result = context.Set<T>().AsQueryable();

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
            return context.Set<T>().AddAsync(entity, _disposeCts.Token);
        }

        public Task Add(IEnumerable<T> entities)
        {
            return context.Set<T>().AddRangeAsync(entities, _disposeCts.Token);
        }

        public Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
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
            context.Set<T>().Remove(entity);
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
            if (!disposing)
            {
                return;
            }

            _disposeCts.Cancel();
            _disposeCts.Dispose();
            context?.Dispose();
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
