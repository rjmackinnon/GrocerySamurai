﻿namespace MagicHamster.GrocerySamurai.BusinessLayer.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Model.Common;

    public interface IBaseUserFilterProcess<T> : IBaseProcess<T>
        where T : UserFilter
    {
        Task<List<T>> GetAllByUser(
            string userId,
            Expression<Func<T, object>> orderBy = null,
            List<string> childProperties = null,
            int pageSize = 0,
            bool noTracking = false);
    }
}