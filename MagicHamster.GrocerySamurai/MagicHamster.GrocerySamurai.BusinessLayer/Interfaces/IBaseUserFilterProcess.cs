﻿using System;
using System.Collections.Generic;
using MagicHamster.GrocerySamurai.Model.Common;

namespace MagicHamster.GrocerySamurai.BusinessLayer.Interfaces
{
    public interface IBaseUserFilterProcess<T> : IBaseProcess<T>
        where T : UserFilter
    {
        List<T> GetAllByUser(string userId, Func<T, object> orderBy = null,
            List<string> childProperties = null, int pageSize = 0, bool noTracking = false);
    }
}