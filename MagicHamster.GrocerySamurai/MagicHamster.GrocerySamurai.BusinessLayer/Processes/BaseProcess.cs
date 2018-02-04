using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
            // Possible deadlock issue here, but having a static repository does not appeal.
            repository = UnitOfWork.GetRepository<T>().Result;
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T, object>> orderBy = null, 
            List<string> childProperties = null, int pageSize = 0, bool noTracking = false)
        {
            return await getByFilter(null, orderBy, childProperties, pageSize, noTracking);
        }

        protected async Task<List<T>> getByFilter(Expression<Func<T, bool>> criteria, 
            Expression<Func<T, object>> orderBy, List<string> childProperties, int pageSize, bool noTracking)
        {
            var result = await repository.Get(criteria, childProperties, noTracking);
            if (orderBy != null)
            {
                result = result.OrderBy(orderBy);
            }
            return pageSize <= 0 ? result.ToList() : result.Take(pageSize).ToList();
        }

        internal virtual async Task<IQueryable> getAsQueryble(Expression<Func<T, bool>> criteria, 
            List<string> childProperties = null)
        {
            return await repository.Get(criteria, childProperties);
        }

        public async Task<T> GetById(int recordId, List<string> childProperties = null, bool noTracking = false)
        {
            return await repository.Get(recordId, childProperties, noTracking);
        }

        public async Task UpdateRecord(T record)
        {
            await repository.Update(record);
        }

        public async Task AddRecord(T record)
        {
            await repository.Add(record);
        }

        public async Task DeleteRecord(int matchRecordId)
        {
            await repository.Delete(matchRecordId);
        }

        public async Task<int> Save()
        {
            return await UnitOfWork.Save();
        }
    }
}
