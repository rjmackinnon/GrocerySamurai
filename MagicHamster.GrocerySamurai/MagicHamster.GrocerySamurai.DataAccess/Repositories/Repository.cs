using System;
using System.Collections.Generic;
using System.Linq;
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

            childProperties?.ForEach(async c => await result.Include(c).LoadAsync(_disposeCts.Token));

            return await result.FirstOrDefaultAsync(r => r.Id == id, _disposeCts.Token);
        }

        public Task<IQueryable<T>> Get(Func<T, bool> where = null, List<string> childProperties = null, bool noTracking = false)
        {
            var result = Context.Set<T>().AsQueryable();

            if (where != null)
            {
                // ReSharper disable once PossibleUnintendedQueryableAsEnumerable
                result = result.Where(where).AsQueryable();
            }

            if (noTracking)
            {
                result = result.AsNoTracking();
            }

            childProperties?.ForEach(async c => await result.Include(c).LoadAsync(_disposeCts.Token));
            return Task.FromResult(result);
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

        public Task Update(IEnumerable<T> entities)
        {
            entities?.ToList().ForEach(async e => await Update(e));
            return Task.CompletedTask;
        }

        public async Task Update(Func<T, bool> where)
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

        public Task Delete(IEnumerable<T> entities)
        {
            entities?.ToList().ForEach(async e => await Delete(e));
            return Task.CompletedTask;
        }

        public async Task Delete(Func<T, bool> where)
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
