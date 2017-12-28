using System;
using System.Collections.Generic;
using System.Linq;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace MagicHamster.GrocerySamurai.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>, IDisposable
        where T : Entity
    {
        public DbContext Context { get; }

        internal Repository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public T Get(int id, List<string> childProperties = null, bool noTracking = false)
        {
            var result = Context.Set<T>().AsQueryable();

            if (noTracking)
            {
                result = result.AsNoTracking();
            }

            childProperties?.ForEach(c => result.Include(c));

            return result.FirstOrDefault(r => r.Id == id);
        }

        public IQueryable<T> Get(Func<T, bool> where = null, List<string> childProperties = null, bool noTracking = false)
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

            childProperties?.ForEach(c => result.Include(c).Load());
            return result;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(int id)
        {
            Update(Get(id));
        }

        public void Update(IEnumerable<T> entities)
        {
            entities?.ToList().ForEach(Update);
        }

        public void Update(Func<T, bool> where)
        {
            Update(Get(where));
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Delete(int id)
        {
            Delete(Get(id));
        }

        public void Delete(IEnumerable<T> entities)
        {
            entities?.ToList().ForEach(Delete);
        }

        public void Delete(Func<T, bool> where)
        {
            Delete(Get(where));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
