using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace MagicHamster.GrocerySamurai.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>, IDisposable
        where T : Entity
    {
        private DbContext Context { get; }

        private readonly  CancellationTokenSource _disposeCts = new CancellationTokenSource();

        internal Repository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T> Get(int id, List<string> childProperties = null, bool noTracking = false)
        {
            var result = Context.Set<T>().AsQueryable();

            if (noTracking)
            {
                result = result.AsNoTracking();
            }

            await loadChildProperties(childProperties, result);

            return await result.FirstOrDefaultAsync(r => r.Id == id, _disposeCts.Token);
        }

        private async Task loadChildProperties(IReadOnlyCollection<string> childProperties, IQueryable<T> result)
        {
            if (childProperties == null)
            {
                return;
            }

            foreach (var child in childProperties)
            {
                await result.Include(child).LoadAsync(_disposeCts.Token);
            }
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

            await loadChildProperties(childProperties, result);

            return result;
        }

        public async Task Add(T entity)
        {
            await Context.Set<T>().AddAsync(entity, _disposeCts.Token);
        }

        public async Task Add(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities, _disposeCts.Token);
        }

        public Task Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task Update(int id)
        {
            await Update(await Get(id));
        }

        public async Task Update(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                return;
            }

            foreach (var entity in entities)
            {
                await Update(entity);
            }
        }

        public async Task Update(Expression<Func<T, bool>> where)
        {
            await Update(await Get(where));
        }

        public Task Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            await Delete(await Get(id));
        }

        public async Task Delete(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                return;
            }

            foreach (var entity in entities)
            {
                await Delete(entity);
            }
        }

        public async Task Delete(Expression<Func<T, bool>> where)
        {
            await Delete(await Get(where));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _disposeCts.Cancel();
            Context?.Dispose();
        }
    }
}
