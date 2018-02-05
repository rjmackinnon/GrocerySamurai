namespace MagicHamster.GrocerySamurai.BusinessLayer.Processes
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using DataAccess.Interfaces;
    using Interfaces;
    using Model.Common;

    public class BaseUserFilterProcess<T> : BaseProcess<T>, IBaseUserFilterProcess<T>
        where T : UserFilter
    {
        public BaseUserFilterProcess(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public virtual Task<List<T>> GetAllByUser(
            string userId,
            Expression<Func<T, object>> orderBy = null,
            List<string> childProperties = null,
            int pageSize = 0,
            bool noTracking = false)
        {
            return getByFilter(u => u.UserId == userId, orderBy, childProperties, pageSize, noTracking)
;
        }
    }
}
