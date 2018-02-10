namespace MagicHamster.GrocerySamurai.BusinessLayer.Processes
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using DataAccess.Interfaces;
    using Interfaces;
    using JetBrains.Annotations;
    using Model.Entities;

    [UsedImplicitly]
    public sealed class GroceryListProcess : BaseProcess<GroceryList>, IGroceryListProcess
    {
        public GroceryListProcess(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Task<List<GroceryList>> GetAllByStore(
            int storeId,
            Expression<Func<GroceryList, object>> orderBy = null,
            List<string> childProperties = null,
            int pageSize = 0,
            bool noTracking = false)
        {
            return getByFilter(l => l.StoreId == storeId, orderBy, childProperties, pageSize, noTracking);
        }
    }
}
