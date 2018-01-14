using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;

namespace MagicHamster.GrocerySamurai.BusinessLayer.Processes
{
    public class BaseUserFilterProcess<T> : BaseProcess<T>, IBaseUserFilterProcess<T>
        where T : UserFilter
    {
        public BaseUserFilterProcess(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public virtual async Task<List<T>> GetAllByUser(string userId, Expression<Func<T, object>> orderBy = null,
            List<string> childProperties = null, int pageSize = 0, bool noTracking = false)
        {
            return await getByFilter(u => u.UserId == userId, orderBy, childProperties, pageSize, noTracking);
        }
    }
}
