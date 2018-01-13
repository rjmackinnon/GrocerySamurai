using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;

namespace MagicHamster.GrocerySamurai.BusinessLayer.Interfaces
{
    public interface IBaseProcess<T>
        where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        Task<List<T>> GetAll(Func<T, object> orderBy = null, List<string> childProperties = null, int pageSize = 0, bool noTracking = false);
        Task<T> GetById(int recordId, List<string> childProperties = null, bool noTracking = false);
        Task UpdateRecord(T record);
        Task AddRecord(T record);
        Task DeleteRecord(int matchRecordId);
        Task<int> Save();
    }
}