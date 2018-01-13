using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.Model.Entities;

namespace MagicHamster.GrocerySamurai.BusinessLayer.Processes
{
    public sealed class GroceryListProcess : BaseProcess<GroceryList>, IGroceryListProcess
    {
        public GroceryListProcess(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<GroceryList>> GetAllByStore(int storeId, Func<GroceryList, object> orderBy = null, 
            List<string> childProperties = null, int pageSize = 0, bool noTracking = false)
        {
            return await getByFilter(l=> l.StoreId == storeId, orderBy, childProperties, pageSize, noTracking);
        }
    }
}
