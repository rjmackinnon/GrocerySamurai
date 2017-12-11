using System;
using System.Collections.Generic;
using System.Linq;
using MagicHamster.GrocerySamurai.Model.Common;

namespace MagicHamster.GrocerySamurai.DataAccess.Interfaces
{
    public interface IRepository<T>
        where T : Entity
    {
        IQueryable<T> Get(List<string> childProperties = null);

        T Get(int id, List<string> childProperties = null);

        IQueryable<T> Get(Func<T, bool> where, List<string> childProperties = null);

        void Add(T entity);

        void Add(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Update(int id);

        void Update(Func<T, bool> where);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        void Delete(int id);

        void Delete(Func<T, bool> where);
    }
}
