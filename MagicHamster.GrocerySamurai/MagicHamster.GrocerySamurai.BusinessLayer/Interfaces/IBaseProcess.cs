namespace MagicHamster.GrocerySamurai.BusinessLayer.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
    using MagicHamster.GrocerySamurai.Model.Common;

    public interface IBaseProcess<T>
        where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<List<T>> GetAll(Expression<Func<T, object>> orderBy = null, List<string> childProperties = null, int pageSize = 0, bool noTracking = false);

        Task<T> GetById(int recordId, List<string> childProperties = null, bool noTracking = false);

        Task UpdateRecord(T record);

        Task AddRecord(T record);

        Task DeleteRecord(int matchRecordId);

        Task<int> Save();
    }
}