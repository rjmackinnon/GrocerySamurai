namespace MagicHamster.GrocerySamurai.DataAccess.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.Model.Common;

    public interface IRepository<T>
        where T : Entity
    {
        Task<T> Get(int id, List<string> childProperties = null, bool noTracking = false);

        Task<IQueryable<T>> Get(Expression<Func<T, bool>> where = null, List<string> childProperties = null, bool noTracking = false);

        Task Add(T entity);

        Task Add(IEnumerable<T> entities);

        Task Update(T entity);

        Task Update(IEnumerable<T> entities);

        Task Update(int id);

        Task Update(Expression<Func<T, bool>> where);

        Task Delete(T entity);

        Task Delete(IEnumerable<T> entities);

        Task Delete(int id);

        Task Delete(Expression<Func<T, bool>> where);
    }
}
