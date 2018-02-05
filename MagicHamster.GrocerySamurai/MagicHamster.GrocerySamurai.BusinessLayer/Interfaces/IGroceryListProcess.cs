namespace MagicHamster.GrocerySamurai.BusinessLayer.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.Model.Entities;

    public interface IGroceryListProcess
    {
        Task<List<GroceryList>> GetAllByStore(
            int storeId,
            Expression<Func<GroceryList, object>> orderBy = null,
            List<string> childProperties = null,
            int pageSize = 0,
            bool noTracking = false);
    }
}