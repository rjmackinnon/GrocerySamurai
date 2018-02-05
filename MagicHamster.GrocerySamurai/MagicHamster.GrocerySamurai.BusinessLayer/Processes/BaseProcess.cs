namespace MagicHamster.GrocerySamurai.BusinessLayer.Processes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
    using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
    using MagicHamster.GrocerySamurai.Model.Common;

    public class BaseProcess<T> : IBaseProcess<T>
        where T : Entity
    {
        private readonly IRepository<T> _repository;

        public BaseProcess(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;

            // Possible deadlock issue here, but having a static repository does not appeal.
            _repository = UnitOfWork.GetRepository<T>().Result;
        }

        public IUnitOfWork UnitOfWork { get; }

        public virtual Task<List<T>> GetAll(
            Expression<Func<T, object>> orderBy = null,
            List<string> childProperties = null,
            int pageSize = 0,
            bool noTracking = false)
        {
            return getByFilter(null, orderBy, childProperties, pageSize, noTracking);
        }

        public Task<T> GetById(int recordId, List<string> childProperties = null, bool noTracking = false)
        {
            return _repository.Get(recordId, childProperties, noTracking);
        }

        public Task UpdateRecord(T record)
        {
            return _repository.Update(record);
        }

        public Task AddRecord(T record)
        {
            return _repository.Add(record);
        }

        public Task DeleteRecord(int matchRecordId)
        {
            return _repository.Delete(matchRecordId);
        }

        public Task<int> Save()
        {
            return UnitOfWork.Save();
        }

        internal virtual async Task<IQueryable> getAsQueryble(
            Expression<Func<T, bool>> criteria,
            List<string> childProperties = null)
        {
            return await _repository.Get(criteria, childProperties).ConfigureAwait(false);
        }

        protected async Task<List<T>> getByFilter(
            Expression<Func<T, bool>> criteria,
            Expression<Func<T, object>> orderBy,
            List<string> childProperties,
            int pageSize,
            bool noTracking)
        {
            var result = await _repository.Get(criteria, childProperties, noTracking).ConfigureAwait(false);
            if (orderBy != null)
            {
                result = result.OrderBy(orderBy);
            }

            return pageSize <= 0 ? result.ToList() : result.Take(pageSize).ToList();
        }
    }
}
