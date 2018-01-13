using System;
using System.Collections.Generic;
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

        public virtual List<T> GetAllByUser(string userId, Func<T, object> orderBy = null,
            List<string> childProperties = null, int pageSize = 0, bool noTracking = false)
        {
            return getByFilter(u => u.UserId == userId, orderBy, childProperties, pageSize, noTracking);
        }
    }
}
