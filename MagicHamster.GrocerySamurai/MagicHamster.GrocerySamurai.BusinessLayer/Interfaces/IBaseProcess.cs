using System;
using System.Collections.Generic;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;

namespace MagicHamster.GrocerySamurai.BusinessLayer.Interfaces
{
    public interface IBaseProcess<T>
        where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        List<T> GetAll(Func<T, object> orderBy = null, List<string> childProperties = null, int pageSize = 0, bool noTracking = false);
        T GetById(int recordId, List<string> childProperties = null, bool noTracking = false);
        void UpdateRecord(T record);
        void AddRecord(T record);
        void DeleteRecord(int matchRecordId);
        int Save();
    }
}