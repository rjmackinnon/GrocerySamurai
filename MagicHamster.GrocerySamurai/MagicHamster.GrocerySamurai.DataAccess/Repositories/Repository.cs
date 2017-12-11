using System;
using System.Collections.Generic;
using System.Linq;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace MagicHamster.GrocerySamurai.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        private DbContext context;

        public Repository()
        {
        }

        public IQueryable<T> Get(List<string> childProperties = null)
        {
            var result = context.Set<T>().AsQueryable();
            childProperties?.ForEach(c => result.Include(c));
            return result;
        }

        public T Get(int id, List<string> childProperties = null)
        {
            var result = context.Set<T>();
            childProperties?.ForEach(c => result.Include(c));
            return result.Find(id);
        }

        public IQueryable<T> Get(Func<T, bool> where, List<string> childProperties = null)
        {
            var result = context.Set<T>().Where(where).AsQueryable();
            childProperties?.ForEach(c => result.Include(c));
            return result;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            foreach (var e in entities)
            {
                Add(e);
            }
        }

        public void Update(T entity)
        {
            // TODO: Look this up
        }

        public void Update(int id)
        {
            Update(Get(id));
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var e in entities)
            {
                Update(e);
            }
        }

        public void Update(Func<T, bool> where)
        {
            Update(Get(where));
        }

        public void Delete(T entity)
        {
            // TODO: Look this up
        }

        public void Delete(int id)
        {
            Delete(Get(id));
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var e in entities)
            {
                Delete(e);
            }
        }

        public void Delete(Func<T, bool> where)
        {
            Delete(Get(where));
        }
    }
}
