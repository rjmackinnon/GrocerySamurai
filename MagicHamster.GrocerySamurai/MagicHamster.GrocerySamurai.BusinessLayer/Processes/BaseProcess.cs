using System;
using System.Collections.Generic;
using System.Linq;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;

namespace MagicHamster.GrocerySamurai.BusinessLayer.Processes
{
    public class BaseProcess<T> : IBaseProcess<T>
        where T : Entity
    {
        public IUnitOfWork UnitOfWork { get; }

        protected readonly IRepository<T> repository;

        public BaseProcess(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            repository = UnitOfWork.GetRepository<T>();
        }

        public virtual List<T> GetAll(Func<T, object> orderBy = null, List<string> childProperties = null, int pageSize = 0, bool noTracking = false)
        {
            var result = repository.Get(null, childProperties, noTracking);
            if (orderBy != null)
            {
                result = result.AsEnumerable().OrderBy(orderBy).AsQueryable();
            }
            return pageSize <= 0 ? result.ToList() : result.Take(pageSize).ToList();
        }

        internal virtual IQueryable getAsQueryble(Func<T, bool> criteria, List<string> childProperties = null)
        {
            return repository.Get(criteria, childProperties);
        }

        public T GetById(int recordId, List<string> childProperties = null, bool noTracking = false)
        {
            return repository.Get(recordId, childProperties, noTracking);
        }

        public void UpdateRecord(T record)
        {
            repository.Update(record);
        }

        public void AddRecord(T record)
        {
            repository.Add(record);
        }

        public void DeleteRecord(int matchRecordId)
        {
            repository.Delete(matchRecordId);
        }

        public int Save()
        {
            return UnitOfWork.Save();
        }
    }
}
