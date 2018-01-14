using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.Model.Common;

namespace MagicHamster.GrocerySamurai.BusinessLayer.Interfaces
{
    public interface IBaseUserFilterProcess<T> : IBaseProcess<T>
        where T : UserFilter
    {
        Task<List<T>> GetAllByUser(string userId, Expression<Func<T, object>> orderBy = null,
            List<string> childProperties = null, int pageSize = 0, bool noTracking = false);
    }
}