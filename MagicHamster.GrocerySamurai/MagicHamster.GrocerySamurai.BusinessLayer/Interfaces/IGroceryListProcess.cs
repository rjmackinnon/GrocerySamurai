using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.Model.Entities;

namespace MagicHamster.GrocerySamurai.BusinessLayer.Interfaces
{
    public interface IGroceryListProcess
    {
        Task<List<GroceryList>> GetAllByStore(int storeId, Func<GroceryList, object> orderBy = null, List<string> childProperties = null, int pageSize = 0, bool noTracking = false);
    }
}