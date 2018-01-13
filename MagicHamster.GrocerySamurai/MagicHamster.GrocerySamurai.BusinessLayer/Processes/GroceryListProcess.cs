using System;
using System.Collections.Generic;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.Model.Entities;

namespace MagicHamster.GrocerySamurai.BusinessLayer.Processes
{
    public class GroceryListProcess : BaseProcess<GroceryList>, IGroceryListProcess
    {
        public GroceryListProcess(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public virtual List<GroceryList> GetAllByStore(int storeId, Func<GroceryList, object> orderBy = null, List<string> childProperties = null, int pageSize = 0, bool noTracking = false)
        {
            return getByFilter(l=> l.StoreId == storeId, orderBy, childProperties, pageSize, noTracking);
        }
    }
}
